using System.Text;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.ThanhVien;
using sgu_c_sharf_backend.Services;

namespace sgu_c_sharf_backend.Repositories
{
    public class ThanhVienRepository
    {
        private readonly string _connectionString;

        public ThanhVienRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy")
                });
            }

            return new PagedResult<ThanhVien>(members, totalRecords, pageNumber, pageSize);
        }

        public ThanhVien? GetById(int id)
        {
            ThanhVien? thanhVien = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT Id, HoTen, NgaySinh, Email, SoDienThoai, TrangThai, MatKhau, ThoiGianDangKy FROM ThanhVien WHERE Id = @Id";

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
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy")
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


        
    }
}
