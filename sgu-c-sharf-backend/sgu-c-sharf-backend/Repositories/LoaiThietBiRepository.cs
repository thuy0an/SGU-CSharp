using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Models;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.LoaiThietBi;
using sgu_c_sharf_backend.Models.ThanhVien;
using sgu_c_sharf_backend.Models.ThietBi; // Import IConfiguration

namespace sgu_c_sharf_backend.Repositories
{
    public class LoaiThietBiRepository
    {
        private readonly string _connectionString;

        public LoaiThietBiRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); // Lấy từ config

        }

        public List<LoaiThietBi> GetAllLoaiThietBiNoPaging()
        {
            List<LoaiThietBi> list = new List<LoaiThietBi>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TenLoaiThietBi FROM LoaiThietBi WHERE DaXoa = FALSE";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LoaiThietBi
                        {
                            Id = reader.GetInt32("Id"),
                            TenLoaiThietBi = reader.GetString("TenLoaiThietBi")
                        });
                    }
                }
            }

            return list;
        }


        public PagedResult<LoaiThietBi> GetAllLoaiThietBi(int pageNumber, int pageSize, string? search, bool? daXoa,
            string? sortBy, string? sortDirection)
        {
            var loaiThietBiList = new List<LoaiThietBi>();
            int totalRecords = 0;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            // Xây dựng câu truy vấn COUNT(*) để lấy tổng số bản ghi theo bộ lọc
            var countQuery = new StringBuilder("SELECT COUNT(*) FROM LoaiThietBi WHERE 1=1");
            if (!string.IsNullOrEmpty(search))
            {
                countQuery.Append(" AND TenLoaiThietBi LIKE @search");
            }

            if (daXoa.HasValue)
            {
                countQuery.Append(" AND DaXoa = @daXoa");
            }

            using (var countCommand = new MySqlCommand(countQuery.ToString(), connection))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    countCommand.Parameters.AddWithValue("@search", $"%{search}%");
                }

                if (daXoa.HasValue)
                {
                    countCommand.Parameters.AddWithValue("@daXoa", daXoa.Value);
                }

                totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
            }

            // Xây dựng truy vấn lấy dữ liệu có phân trang và sắp xếp
            var query = new StringBuilder("SELECT * FROM LoaiThietBi WHERE 1=1");
            if (!string.IsNullOrEmpty(search))
            {
                query.Append(" AND TenLoaiThietBi LIKE @search");
            }

            if (daXoa.HasValue)
            {
                query.Append(" AND DaXoa = @daXoa");
            }

            // Kiểm tra sắp xếp
            string validSortColumn = "Id"; // Mặc định sắp xếp theo Id
            if (!string.IsNullOrEmpty(sortBy))
            {
                var allowedColumns = new HashSet<string> { "Id", "TenLoaiThietBi", "DaXoa" };
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

            if (daXoa.HasValue)
            {
                command.Parameters.AddWithValue("@daXoa", daXoa.Value);
            }

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                loaiThietBiList.Add(new LoaiThietBi
                {
                    Id = reader.GetInt32("Id"),
                    TenLoaiThietBi = reader.GetString("TenLoaiThietBi"),
                    DaXoa = reader.GetBoolean("DaXoa")
                });
            }

            return new PagedResult<LoaiThietBi>(loaiThietBiList, totalRecords, pageNumber, pageSize);
        }


        public LoaiThietBi GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TenLoaiThietBi, DaXoa FROM LoaiThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LoaiThietBi
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        };
                    }

                    return null;
                }
            }
        }

        public LoaiThietBi? Create(LoaiThietBi loaiThietBi)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
        
                // Thực hiện INSERT và lấy ID ngay sau đó
                string sql = "INSERT INTO LoaiThietBi (TenLoaiThietBi) VALUES (@TenLoaiThietBi); SELECT LAST_INSERT_ID();";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenLoaiThietBi", loaiThietBi.TenLoaiThietBi);

                // Lấy ID của bản ghi vừa chèn
                var id = Convert.ToInt32(command.ExecuteScalar());

                loaiThietBi.Id = id;
                return loaiThietBi;
            }
        }


        public LoaiThietBi? Update(LoaiThietBi loaiThietBi)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE LoaiThietBi SET TenLoaiThietBi = @TenLoaiThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", loaiThietBi.Id);
                command.Parameters.AddWithValue("@TenLoaiThietBi", loaiThietBi.TenLoaiThietBi);
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0 ? loaiThietBi : null;

            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE LoaiThietBi SET DaXoa = 1 WHERE Id = @Id"; // Soft Delete
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}