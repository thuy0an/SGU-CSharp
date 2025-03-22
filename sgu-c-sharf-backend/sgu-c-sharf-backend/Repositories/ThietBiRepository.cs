using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Interfaces;
using sgu_c_sharf_backend.Models; // Chú ý: đã sửa namespace
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.Models.ThietBi; // Import IConfiguration

namespace sgu_c_sharf_backend.Repositories
{
    public class ThietBiRepository : IThietBiRepository
    {
        private readonly string _connectionString;
        private readonly IDauThietBiRepository _dauThietBiRepository; // Sửa kiểu dữ liệu

        public ThietBiRepository(IConfiguration configuration, IDauThietBiRepository dauThietBiRepository)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ IConfiguration
            _dauThietBiRepository = dauThietBiRepository; // Gán giá trị
        }

        public ThietBi GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TenThietBi, IdLoaiThietBi, DaXoa FROM ThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ThietBi
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            IdLoaiThietBi = Convert.ToInt32(reader["IdLoaiThietBi"]),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<ThietBi> GetAll()
        {
            List<ThietBi> thietBis = new List<ThietBi>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TenThietBi, IdLoaiThietBi, DaXoa FROM ThietBi";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thietBis.Add(new ThietBi
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            IdLoaiThietBi = Convert.ToInt32(reader["IdLoaiThietBi"]),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        });
                    }
                }
            }
            return thietBis;
        }

        public void Add(ThietBiCreateForm thietBiCreateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO ThietBi (TenThietBi, IdLoaiThietBi) VALUES (@TenThietBi, @IdLoaiThietBi)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenThietBi", thietBiCreateForm.TenThietBi);
                command.Parameters.AddWithValue("@IdLoaiThietBi", thietBiCreateForm.IdLoaiThietBi);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, ThietBiUpdateForm thietBiUpdateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE ThietBi SET TenThietBi = @TenThietBi, IdLoaiThietBi = @IdLoaiThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@TenThietBi", thietBiUpdateForm.TenThietBi);
                command.Parameters.AddWithValue("@IdLoaiThietBi", thietBiUpdateForm.IdLoaiThietBi);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ThietBi> Search(string? tenThietBi, int? idLoaiThietBi, bool? daXoa)
        {
            List<ThietBi> thietBis = new List<ThietBi>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT Id, TenThietBi, IdLoaiThietBi, DaXoa FROM ThietBi WHERE 1=1";
                List<string> conditions = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(tenThietBi))
                {
                    conditions.Add("TenThietBi LIKE @TenThietBi");
                    parameters.Add(new MySqlParameter("@TenThietBi", "%" + tenThietBi + "%")); // Sử dụng LIKE để tìm kiếm gần đúng
                }

                if (idLoaiThietBi.HasValue)
                {
                    conditions.Add("IdLoaiThietBi = @IdLoaiThietBi");
                    parameters.Add(new MySqlParameter("@IdLoaiThietBi", idLoaiThietBi.Value));
                }

                if (daXoa.HasValue)
                {
                    conditions.Add("DaXoa = @DaXoa");
                    parameters.Add(new MySqlParameter("@DaXoa", daXoa.Value));
                }

                if (conditions.Count > 0)
                {
                    sql += " AND " + string.Join(" AND ", conditions);
                }

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddRange(parameters.ToArray());

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thietBis.Add(new ThietBi
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            IdLoaiThietBi = Convert.ToInt32(reader["IdLoaiThietBi"]),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        });
                    }
                }
            }
            return thietBis;
        }

        public int UpdateByCondition(string? tenThietBiCondition, int? idLoaiThietBiCondition, bool? daXoaCondition, ThietBiUpdateForm updateValues)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "UPDATE ThietBi SET ";
                List<string> setClauses = new List<string>();
                List<string> whereClauses = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Xây dựng mệnh đề SET
                setClauses.Add("TenThietBi = @NewTenThietBi");
                parameters.Add(new MySqlParameter("@NewTenThietBi", updateValues.TenThietBi));

                setClauses.Add("IdLoaiThietBi = @NewIdLoaiThietBi");
                parameters.Add(new MySqlParameter("@NewIdLoaiThietBi", updateValues.IdLoaiThietBi));

                sql += string.Join(", ", setClauses);

                // Xây dựng mệnh đề WHERE
                sql += " WHERE 1=1";
                if (!string.IsNullOrEmpty(tenThietBiCondition))
                {
                    whereClauses.Add("TenThietBi LIKE @TenThietBiCondition");
                    parameters.Add(new MySqlParameter("@TenThietBiCondition", "%" + tenThietBiCondition + "%")); // Dùng LIKE cho tìm kiếm gần đúng
                }
                if (idLoaiThietBiCondition.HasValue)
                {
                    whereClauses.Add("IdLoaiThietBi = @IdLoaiThietBiCondition");
                    parameters.Add(new MySqlParameter("@IdLoaiThietBiCondition", idLoaiThietBiCondition.Value));
                }
                if (daXoaCondition.HasValue)
                {
                    whereClauses.Add("DaXoa = @DaXoaCondition");
                    parameters.Add(new MySqlParameter("@DaXoaCondition", daXoaCondition.Value));
                }

                if (whereClauses.Count > 0)
                {
                    sql += " AND " + string.Join(" AND ", whereClauses);
                }

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddRange(parameters.ToArray());

                return command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
          
            _dauThietBiRepository.UpdateByCondition(
                null,       // trangThaiCondition
                null,       // thoiGianMuaStartCondition
                null,       // thoiGianMuaEndCondition
                id,   // idThietBiCondition,
                null  // Các giá trị cần cập nhật
            );

              using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE ThietBi SET DaXoa = 1 WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}