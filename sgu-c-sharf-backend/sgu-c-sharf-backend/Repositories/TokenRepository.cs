using System.Data;
using Dapper;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.ThanhVien;

namespace sgu_c_sharf_backend.Repositories
{
    public interface IOTPRepository
    {
        Task<OTP> GetByTokenAsync(string token);
        Task AddAsync(OTP otp);
    }

    public class OTPRepository : IOTPRepository
    {
        private readonly IDbConnection _connection;

        public OTPRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<OTP> GetByTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token), "Token không được để trống.");

            const string sql = @"
                                    SELECT o.*
                                    FROM OTP o
                                    WHERE o.Token = @Token";

            var result = await _connection.QueryAsync<OTP>(sql, new { Token = token });
            var otp = result.FirstOrDefault();

            return otp;
        }

        public async Task AddAsync(OTP otp)
        {
            if (otp == null)
                throw new ArgumentNullException(nameof(otp));

            const string sql = @"
                INSERT INTO OTP (Token, NgayTao, NgayHetHan, LoaiOTP, IdThanhVien)
                VALUES (@Token, @NgayTao, @NgayHetHan, @LoaiOTP, @IdThanhVien);
                SELECT LAST_INSERT_ID();"; // Thay SCOPE_IDENTITY() bằng LAST_INSERT_ID()

            var id = await _connection.ExecuteScalarAsync<uint>(sql, otp);
            otp.Id = id; // Gán Id cho đối tượng sau khi insert
        }
    }
}