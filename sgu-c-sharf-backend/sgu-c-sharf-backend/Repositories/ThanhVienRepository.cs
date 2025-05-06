using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.ThanhVien;

namespace sgu_c_sharf_backend.Repositories
{
    public class ThanhVienRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ThanhVienRepository> _logger; // Inject ILogger

        public ThanhVienRepository(IConfiguration configuration, ILogger<ThanhVienRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }
        public PagedResult<ThanhVien> GetAll(int pageNumber, int pageSize, string? search, TrangThaiEnum? status, string? sortBy, string? sortDirection)
        {
            var members = new List<ThanhVien>();
            int totalRecords = 0;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            // Xây dựng câu truy vấn COUNT(*) để lấy tổng số bản ghi theo bộ lọc
            var countQuery = new StringBuilder("SELECT COUNT(*) FROM ThanhVien WHERE 1=1");
            if (!string.IsNullOrEmpty(search))
            {
                countQuery.Append(" AND (HoTen LIKE @search OR Email LIKE @search OR SoDienThoai LIKE @search)");
            }
            if (status.HasValue)
            {
                countQuery.Append(" AND TrangThai = @status");
            }

            using (var countCommand = new MySqlCommand(countQuery.ToString(), connection))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    countCommand.Parameters.AddWithValue("@search", $"%{search}%");
                }
                if (status.HasValue)
                {
                    countCommand.Parameters.AddWithValue("@status", status.ToString());
                }
                totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
            }

            // Xây dựng truy vấn lấy dữ liệu có phân trang và sắp xếp
            var query = new StringBuilder("SELECT * FROM ThanhVien WHERE 1=1");
            if (!string.IsNullOrEmpty(search))
            {
                query.Append(" AND (HoTen LIKE @search OR Email LIKE @search OR SoDienThoai LIKE @search)");
            }
            if (status.HasValue)
            {
                query.Append(" AND TrangThai = @status");
            }

            // Kiểm tra sắp xếp
            string validSortColumn = "Id"; // Mặc định sắp xếp theo thời gian đăng ký
            if (!string.IsNullOrEmpty(sortBy))
            {
                var allowedColumns = new HashSet<string> { "Id", "HoTen", "Email", "SoDienThoai", "ThoiGianDangKy" };
                if (allowedColumns.Contains(sortBy))
                {
                    validSortColumn = sortBy;
                }
            }

            string sortOrder = "ASC"; // Mặc định tăng dần
            if (!string.IsNullOrEmpty(sortDirection) && sortDirection.ToUpper() == "DESC")
            {
                sortOrder = "DESC";
            }

            query.Append($" ORDER BY {validSortColumn} {sortOrder}");
            query.Append(" LIMIT @pageSize OFFSET @offset");

            int offset = (pageNumber - 1) * pageSize;

            using var command = new MySqlCommand(query.ToString(), connection);
            command.Parameters.AddWithValue("@pageSize", pageSize);
            command.Parameters.AddWithValue("@offset", offset);

            if (!string.IsNullOrEmpty(search))
            {
                command.Parameters.AddWithValue("@search", $"%{search}%");
            }
            if (status.HasValue)
            {
                command.Parameters.AddWithValue("@status", status.ToString());
            }

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                members.Add(new ThanhVien
                {
                    Id = reader.GetInt32("Id"),
                    HoTen = reader.GetString("HoTen"),
                    NgaySinh = reader.GetDateTime("NgaySInh"),
                    Email = reader.GetString("Email"),
                    SoDienThoai = reader.GetString("SoDienThoai"),
                    TrangThai = Enum.Parse<TrangThaiEnum>(reader.GetString("TrangThai")),
                    MatKhau = reader.GetString("MatKhau"),
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy"),
                    Quyen = Enum.Parse<QuyenEnum>(reader.GetString("Quyen")),
                });
            }

            return new PagedResult<ThanhVien>(members, totalRecords, pageNumber, pageSize);
        }

        public ThanhVien? FindUserByEmail(string email)
        {
            ThanhVien? thanhVien = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            string query = "SELECT Id, HoTen, NgaySinh, Email, SoDienThoai, TrangThai, MatKhau, ThoiGianDangKy, Quyen FROM ThanhVien WHERE Email = @Email";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                thanhVien = new ThanhVien
                {
                    Id = reader.GetInt32("Id"),
                    HoTen = reader.GetString("HoTen"),
                    NgaySinh = reader.GetDateTime("NgaySinh"),
                    Email = reader.GetString("Email"),
                    SoDienThoai = reader.GetString("SoDienThoai"),
                    TrangThai = Enum.Parse<TrangThaiEnum>(reader.GetString("TrangThai")),
                    MatKhau = reader.GetString("MatKhau"),
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy"),
                    Quyen = Enum.Parse<QuyenEnum>(reader.GetString("Quyen")),
                };
            }

            return thanhVien;
        }
        public ThanhVien? GetById(int id)
        {
            ThanhVien? thanhVien = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT Id, HoTen, NgaySinh, Email, SoDienThoai, TrangThai, MatKhau, ThoiGianDangKy, Quyen FROM ThanhVien WHERE Id = @Id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                thanhVien = new ThanhVien
                {
                    Id = reader.GetInt32("Id"),
                    HoTen = reader.GetString("HoTen"),
                    NgaySinh = reader.GetDateTime("NgaySinh"),
                    Email = reader.GetString("Email"),
                    SoDienThoai = reader.GetString("SoDienThoai"),
                    TrangThai = Enum.Parse<TrangThaiEnum>(reader.GetString("TrangThai")),
                    MatKhau = reader.GetString("MatKhau"),
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy"),
                    Quyen = Enum.Parse<QuyenEnum>(reader.GetString("Quyen")),
                };
            }

            return thanhVien;
        }

        public ThanhVien? GetByEmail(string email)
        {
            ThanhVien? thanhVien = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT Id, HoTen, NgaySinh, Email, SoDienThoai, TrangThai, MatKhau, ThoiGianDangKy, Quyen FROM ThanhVien WHERE Email = @Email";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                thanhVien = new ThanhVien
                {
                    Id = reader.GetInt32("Id"),
                    HoTen = reader.GetString("HoTen"),
                    NgaySinh = reader.GetDateTime("NgaySinh"),
                    Email = reader.GetString("Email"),
                    SoDienThoai = reader.GetString("SoDienThoai"),
                    TrangThai = Enum.Parse<TrangThaiEnum>(reader.GetString("TrangThai")),
                    MatKhau = reader.GetString("MatKhau"),
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy"),
                    Quyen = Enum.Parse<QuyenEnum>(reader.GetString("Quyen")),
                };
            }

            return thanhVien;
        }

        public ThanhVien? Create(ThanhVien thanhVien)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"INSERT INTO ThanhVien (HoTen, NgaySinh, Email, SoDienThoai, TrangThai, MatKhau) 
                     VALUES (@HoTen, @NgaySinh, @Email, @SoDienThoai, @TrangThai, @MatKhau);
                     SELECT LAST_INSERT_ID();";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@HoTen", thanhVien.HoTen);
            command.Parameters.AddWithValue("@NgaySinh", thanhVien.NgaySinh);
            command.Parameters.AddWithValue("@Email", thanhVien.Email);
            command.Parameters.AddWithValue("@SoDienThoai", thanhVien.SoDienThoai);
            command.Parameters.AddWithValue("@TrangThai", thanhVien.TrangThai.ToString());
            command.Parameters.AddWithValue("@MatKhau", thanhVien.MatKhau);

            var id = command.ExecuteScalar();
            if (id != null)
            {
                thanhVien.Id = Convert.ToInt32(id);
                thanhVien.ThoiGianDangKy = DateTime.Now;
                return thanhVien;
            }

            return null;
        }

        public ThanhVien? Update(ThanhVien thanhVien)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"UPDATE ThanhVien 
                     SET 
                         HoTen = @HoTen, 
                         NgaySinh = @NgaySinh, 
                         SoDienThoai = @SoDienThoai, 
                         TrangThai = @TrangThai
                     WHERE Id = @Id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", thanhVien.Id);
            command.Parameters.AddWithValue("@HoTen", thanhVien.HoTen);
            command.Parameters.AddWithValue("@NgaySinh", thanhVien.NgaySinh);
            command.Parameters.AddWithValue("@SoDienThoai", thanhVien.SoDienThoai);

            // Truyền giá trị enum vào như chuỗi cho MySQL
            command.Parameters.AddWithValue("@TrangThai", thanhVien.TrangThai.ToString());


            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0 ? thanhVien : null;
        }
        public int CheckRoleAdmin(string password, string phoneOrEmail)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "Select Quyen From thanhvien Where MatKhau=@MatKhau And (Email=@PassOrEmail OR SoDienThoai=@PassOrEmail)";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@MatKhau", password);
            command.Parameters.AddWithValue("@PassOrEmail", phoneOrEmail);
            var res = command.ExecuteScalar();
            if (res == null)
                return 0;
            string quyen = res.ToString();
            if (quyen.Equals("ADMIN", StringComparison.OrdinalIgnoreCase))
                return 1;
            return 2;
        }
        public int Login(LoginRequest request)
        {
            int thanhVienId = -1;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                SELECT Id, MatKhau
                FROM ThanhVien
                WHERE Email = @Identifier OR SoDienThoai = @Identifier";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Identifier", request.Identifier);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32("Id");
                string hashedPasswordFromDb = reader.GetString("MatKhau");

                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"HashedPassword: {hashedPasswordFromDb}");

                // Khởi tạo password hasher
                var passwordHasher = new PasswordHasher<object>();

                // Tạo 1 đối tượng ThanhVien tạm (nếu cần cho generic)

                // So sánh password
                var result = passwordHasher.VerifyHashedPassword(new object(), hashedPasswordFromDb, request.MatKhau);

                if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    thanhVienId = id;
                }
            }

            return thanhVienId; // Trả -1 nếu không đúng
        }

        public bool IsEmailExists(string email)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT 1 FROM ThanhVien WHERE Email = @Email";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            using var reader = command.ExecuteReader();
            return reader.Read();
        }

        public bool ChangePassword(ChangePassword request)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            // 1. Lấy hashed password hiện tại từ DB
            string query = @"
                SELECT Id, MatKhau
                FROM ThanhVien
                WHERE Id = @Identifier";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Identifier", request.Identifier);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                string hashedPasswordFromDb = reader.GetString("MatKhau");

                var passwordHasher = new PasswordHasher<object>();
                var verifyResult = passwordHasher.VerifyHashedPassword(new object(), hashedPasswordFromDb, request.MatKhauCu);

                if (verifyResult == PasswordVerificationResult.Success || verifyResult == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    // 2. Nếu mật khẩu cũ đúng -> hash mật khẩu mới
                    string hashedNewPassword = passwordHasher.HashPassword(new object(), request.MatKhauMoi);

                    // 3. Update mật khẩu mới vào DB
                    reader.Close(); // đóng reader trước khi dùng connection

                    string updateQuery = "UPDATE ThanhVien SET MatKhau = @MatKhauMoi WHERE Id = @Id";
                    using var updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@MatKhauMoi", hashedNewPassword);
                    updateCommand.Parameters.AddWithValue("@Id", request.Identifier);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

            return false; // Đổi mật khẩu thất bại
        }

        public bool ForgotPassword(ForgotPassword request)
        {
            _logger.LogInformation($"ForgotPassword request received for Identifier: {request.Identifier}");

            using var connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                _logger.LogInformation("Database connection opened successfully.");

                var passwordHasher = new PasswordHasher<object>();
                string hashedNewPassword = passwordHasher.HashPassword(new object(), request.MatKhauMoi);
                _logger.LogDebug($"Hashed new password for Identifier: {request.Identifier}");

                string updateQuery = "UPDATE ThanhVien SET MatKhau = @MatKhauMoi WHERE Id = @Identifier";
                using var updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@MatKhauMoi", hashedNewPassword);
                updateCommand.Parameters.AddWithValue("@Identifier", request.Identifier);
                _logger.LogDebug($"Executing SQL: {updateQuery} with Identifier: {request.Identifier}");

                int rowsAffected = updateCommand.ExecuteNonQuery();
                _logger.LogInformation($"Rows affected for Identifier: {request.Identifier}: {rowsAffected}");

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                string errorMessage = $"Database error occurred while updating password for Identifier: {request.Identifier}";
                _logger.LogError(ex, errorMessage);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    _logger.LogInformation("Database connection closed.");
                }
            }
        }

    }
}