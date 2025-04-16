using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Repositories
{
    public class ThietBiRepository
    {
        private readonly string _connectionString;

        public ThietBiRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public ThietBiDetailDTO GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT tb.Id, tb.TenThietBi, ltb.TenLoaiThietBi, tb.DaXoa
                    FROM ThietBi tb
                    INNER JOIN LoaiThietBi ltb ON tb.IdLoaiThietBi = ltb.Id AND ltb.DaXoa = 0
                    WHERE tb.Id = @Id AND tb.DaXoa = 0";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ThietBiDetailDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<ThietBiListDTO> GetAll()
        {
            List<ThietBiListDTO> thietBis = new List<ThietBiListDTO>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT tb.Id, tb.TenThietBi, ltb.TenLoaiThietBi, tb.DaXoa
                    FROM ThietBi tb
                    INNER JOIN LoaiThietBi ltb ON tb.IdLoaiThietBi = ltb.Id AND ltb.DaXoa = 0
                    WHERE tb.DaXoa = 0";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thietBis.Add(new ThietBiListDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
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
                // Kiểm tra IdLoaiThietBi hợp lệ
                string checkLoaiSql = "SELECT COUNT(*) FROM LoaiThietBi WHERE Id = @IdLoaiThietBi AND DaXoa = 0";
                MySqlCommand checkLoaiCommand = new MySqlCommand(checkLoaiSql, connection);
                checkLoaiCommand.Parameters.AddWithValue("@IdLoaiThietBi", thietBiCreateForm.IdLoaiThietBi);
                int loaiCount = Convert.ToInt32(checkLoaiCommand.ExecuteScalar());

                if (loaiCount == 0)
                    throw new Exception("Loại thiết bị không tồn tại hoặc đã bị xóa.");

                // Kiểm tra TenThietBi không trùng
                string checkDuplicateSql = "SELECT COUNT(*) FROM ThietBi WHERE TenThietBi = @TenThietBi AND DaXoa = 0";
                MySqlCommand checkDuplicateCommand = new MySqlCommand(checkDuplicateSql, connection);
                checkDuplicateCommand.Parameters.AddWithValue("@TenThietBi", thietBiCreateForm.TenThietBi);
                int duplicateCount = Convert.ToInt32(checkDuplicateCommand.ExecuteScalar());

                if (duplicateCount > 0)
                    throw new Exception("Tên thiết bị đã tồn tại.");

                string sql = "INSERT INTO ThietBi (TenThietBi, IdLoaiThietBi, DaXoa) VALUES (@TenThietBi, @IdLoaiThietBi, 0)";
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
                // Kiểm tra IdLoaiThietBi hợp lệ
                string checkLoaiSql = "SELECT COUNT(*) FROM LoaiThietBi WHERE Id = @IdLoaiThietBi AND DaXoa = 0";
                MySqlCommand checkLoaiCommand = new MySqlCommand(checkLoaiSql, connection);
                checkLoaiCommand.Parameters.AddWithValue("@IdLoaiThietBi", thietBiUpdateForm.IdLoaiThietBi);
                int loaiCount = Convert.ToInt32(checkLoaiCommand.ExecuteScalar());

                if (loaiCount == 0)
                    throw new Exception("Loại thiết bị không tồn tại hoặc đã bị xóa.");

                // Kiểm tra TenThietBi không trùng (ngoại trừ bản ghi hiện tại)
                string checkDuplicateSql = "SELECT COUNT(*) FROM ThietBi WHERE TenThietBi = @TenThietBi AND DaXoa = 0 AND Id != @Id";
                MySqlCommand checkDuplicateCommand = new MySqlCommand(checkDuplicateSql, connection);
                checkDuplicateCommand.Parameters.AddWithValue("@TenThietBi", thietBiUpdateForm.TenThietBi);
                checkDuplicateCommand.Parameters.AddWithValue("@Id", id);
                int duplicateCount = Convert.ToInt32(checkDuplicateCommand.ExecuteScalar());

                if (duplicateCount > 0)
                    throw new Exception("Tên thiết bị đã tồn tại.");

                string sql = "UPDATE ThietBi SET TenThietBi = @TenThietBi, IdLoaiThietBi = @IdLoaiThietBi WHERE Id = @Id AND DaXoa = 0";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@TenThietBi", thietBiUpdateForm.TenThietBi);
                command.Parameters.AddWithValue("@IdLoaiThietBi", thietBiUpdateForm.IdLoaiThietBi);
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                    throw new Exception("Thiết bị không tồn tại hoặc đã bị xóa.");
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE ThietBi SET DaXoa = 1 WHERE Id = @Id AND DaXoa = 0";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                    throw new Exception("Thiết bị không tồn tại hoặc đã bị xóa.");
            }
        }

        public IEnumerable<ThietBiListDTO> Search(string tenThietBi, int? idLoaiThietBi)
        {
            List<ThietBiListDTO> thietBis = new List<ThietBiListDTO>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT tb.Id, tb.TenThietBi, ltb.TenLoaiThietBi, tb.DaXoa
                    FROM ThietBi tb
                    INNER JOIN LoaiThietBi ltb ON tb.IdLoaiThietBi = ltb.Id AND ltb.DaXoa = 0
                    WHERE tb.DaXoa = 0";
                List<string> conditions = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(tenThietBi))
                {
                    conditions.Add("tb.TenThietBi LIKE @TenThietBi");
                    parameters.Add(new MySqlParameter("@TenThietBi", "%" + tenThietBi + "%"));
                }

                if (idLoaiThietBi.HasValue)
                {
                    conditions.Add("tb.IdLoaiThietBi = @IdLoaiThietBi");
                    parameters.Add(new MySqlParameter("@IdLoaiThietBi", idLoaiThietBi.Value));
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
                        thietBis.Add(new ThietBiListDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        });
                    }
                }
            }
            return thietBis;
        }
    }
}