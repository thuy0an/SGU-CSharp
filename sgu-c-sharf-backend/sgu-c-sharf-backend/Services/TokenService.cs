using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Repositories;
using Microsoft.Extensions.Logging; // Đã có namespace cho ILogger

namespace sgu_c_sharf_backend.Services
{
    public interface IOTPService
    {
        Task<OTP> GetByTokenAsync(string token);
        Task AddAsync(OTPCreateDTO otpCreateDTO);
        Task<bool> IsTokenValidAsync(string token);
        Task<bool> ValidateTokenAsync(string token, string loaiOTP);
        Task<OtpResponse> SendOtpByEmailAsync(string loaiOTP, string email);
    }

    public class OTPService : IOTPService
    {
        private readonly IOTPRepository _repository;
        private readonly EmailSettings _emailSettings;
        private readonly ThanhVienService _thanhVienService; // Đổi thành interface
        private readonly ILogger<OTPService> _logger; // Thêm field _logger

        public OTPService(
            IOTPRepository repository,
            IOptions<EmailSettings> emailSettings,
            ThanhVienService thanhVienService, // Thêm dependency ThanhVienService
            ILogger<OTPService> logger) // Thêm ILogger vào constructor
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _emailSettings = emailSettings.Value ?? throw new ArgumentNullException(nameof(emailSettings));
            _thanhVienService = thanhVienService ?? throw new ArgumentNullException(nameof(thanhVienService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OTP> GetByTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            var otp = await _repository.GetByTokenAsync(token);
            if (otp == null)
                throw new KeyNotFoundException($"OTP với Token {token} không tồn tại.");
            return otp;
        }

        public async Task AddAsync(OTPCreateDTO otpCreateDTO)
        {
            if (otpCreateDTO == null)
                throw new ArgumentNullException(nameof(otpCreateDTO));

            if (string.IsNullOrEmpty(otpCreateDTO.Token))
                throw new ArgumentException("Token không được để trống.");

            if (otpCreateDTO.NgayHetHan <= DateTime.Now)
                throw new ArgumentException("Ngày hết hạn phải lớn hơn thời gian hiện tại.");

            var otp = new OTP
            {
                Token = otpCreateDTO.Token,
                NgayHetHan = otpCreateDTO.NgayHetHan,
                LoaiOTP = otpCreateDTO.LoaiOTP,
                IdThanhVien = otpCreateDTO.IdThanhVien,
                NgayTao = DateTime.Now
            };

            await _repository.AddAsync(otp);
        }

        public async Task<bool> IsTokenValidAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            var otp = await _repository.GetByTokenAsync(token);
            if (otp == null) return false;

            return otp.NgayHetHan > DateTime.Now;
        }

        public async Task<bool> ValidateTokenAsync(string token, string loaiOTP)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            if (string.IsNullOrEmpty(loaiOTP))
                throw new ArgumentNullException(nameof(loaiOTP));

            var otp = await _repository.GetByTokenAsync(token);
            if (otp == null) return false;

            return otp.LoaiOTP.Equals(loaiOTP, StringComparison.OrdinalIgnoreCase) && otp.NgayHetHan > DateTime.Now;
        }

        public async Task<OtpResponse> SendOtpByEmailAsync(string loaiOTP, string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email), "Email không được để trống.");

            if (string.IsNullOrEmpty(loaiOTP))
                throw new ArgumentNullException(nameof(loaiOTP), "Loại OTP không được để trống.");

            var user = _thanhVienService.FindUserByEmail(email);
            if (user == null)
            {
                var errorMessage = $"Không tìm thấy người dùng với email: {email}";
                _logger.LogWarning(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }
            var id = user.Id;

            var token = GenerateRandomToken(6);
            var otp = new OTP
            {
                Token = token,
                NgayHetHan = DateTime.Now.AddDays(1),
                LoaiOTP = loaiOTP,
                IdThanhVien = id,
                NgayTao = DateTime.Now
            };

            try
            {
                await _repository.AddAsync(otp);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Lỗi khi thêm OTP vào cơ sở dữ liệu cho email: {email}, LoaiOTP: {loaiOTP}. Chi tiết: {ex.Message}";
                _logger.LogError(ex, errorMessage);
                throw new InvalidOperationException(errorMessage, ex);
            }

            try
            {
                await SendEmailAsync(email, token, loaiOTP);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Lỗi khi gửi email OTP tới: {email}, LoaiOTP: {loaiOTP}. Chi tiết: {ex.Message}";
                _logger.LogError(ex, errorMessage);
                throw new InvalidOperationException(errorMessage, ex);
            }

            return new OtpResponse()
            {
                Token = token,
                IdThanhVien = id
            };
        }

        private string GenerateRandomToken(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private async Task SendEmailAsync(string toEmail, string token, string loaiOTP)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Thư quán của nhóm 8", _emailSettings.FromEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = $"Your OTP for {loaiOTP}";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>Your OTP Code</h1><p>Your OTP code is: <strong>{token}</strong><br>Valid for 24 hours.</p>"
            };

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }

    public class OtpResponse
    {
        public string Token { get; set; }
        public int IdThanhVien { get; set; }
    }
}