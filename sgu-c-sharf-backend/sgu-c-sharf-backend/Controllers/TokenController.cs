using System;
using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.ApiResponse;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/otp")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _otpService;

        public OTPController(IOTPService otpService)
        {
            _otpService = otpService ?? throw new ArgumentNullException(nameof(otpService));
        }

        // Lấy OTP theo Token (không dùng form-data vì là GET)
        [HttpGet("token/{token}")]
        public ActionResult<OTP> GetByToken(string token)
        {
            try
            {
                var result = _otpService.GetByTokenAsync(token).Result;
                if (result == null)
                {
                    return NotFound(new { Message = "Không tìm thấy OTP với token này" });
                }
                return Ok(ApiResponse<OTP>.Ok(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Xác thực token (sử dụng form-data)
        [HttpPost("validate")]
        public ActionResult<bool> ValidateToken([FromForm] ValidateTokenRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Token) || string.IsNullOrEmpty(request.LoaiOTP))
                {
                    return BadRequest(new { Message = "Dữ liệu không hợp lệ: Token hoặc LoaiOTP không được để trống" });
                }

                var isValid = _otpService.ValidateTokenAsync(request.Token, request.LoaiOTP).Result;
                return Ok(ApiResponse<bool>.Ok(isValid));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Gửi OTP qua email (sử dụng form-data)
        [HttpPost("send")]
        public ActionResult<string> SendOTP([FromForm] SendOTPRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.LoaiOTP))
                {
                    return BadRequest(new { Message = "Dữ liệu không hợp lệ: Email hoặc LoaiOTP không được để trống" });
                }

                var token = _otpService.SendOtpByEmailAsync(request.LoaiOTP, request.Email).Result;
                var response = new
                {
                    Message = "OTP đã được gửi thành công",
                    Status = 200,
                    Token = token
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

    // Request model cho ValidateToken
    public class ValidateTokenRequest
    {
        public string Token { get; set; }
        public string LoaiOTP { get; set; }
    }

    // Request model cho SendOTP
    public class SendOTPRequest
    {
        public string LoaiOTP { get; set; }
        public string Email { get; set; }
    }
}