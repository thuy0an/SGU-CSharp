using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Repositories
{
    public class DauThietBiRepository
    {
        private readonly string _connectionString;

        public DauThietBiRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DauThietBiDetailResponseDto GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT dt.Id, dt.TrangThai, dt.ThoiGianMua, dt.IdThietBi, 
                           tb.TenThietBi, tb.IdLoaiThietBi, ltb.TenLoaiThietBi
                    FROM DauThietBi dt
                    INNER JOIN ThietBi tb ON dt.IdThietBi = tb.Id AND tb.DaXoa = 0
                    INNER JOIN LoaiThietBi ltb ON tb.IdLoaiThietBi = ltb.Id AND ltb.DaXoa = 0
                    WHERE dt.Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DauThietBiDetailResponseDto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrangThai = (TrangThaiDauThietBiEnum)Enum.Parse(typeof(TrangThaiDauThietBiEnum), reader["TrangThai"].ToString()),
                            ThoiGianMua = Convert.ToDateTime(reader["ThoiGianMua"]),
                            IdThietBi = Convert.ToInt32(reader["IdThietBi"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            IdLoaiThietBi = Convert.ToInt32(reader["IdLoaiThietBi"]),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<DauThietBiListDTO> GetAll()
        {
            List<DauThietBiListDTO> dauThietBis = new List<DauThietBiListDTO>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT dt.Id, dt.TrangThai, dt.ThoiGianMua, dt.IdThietBi
                    FROM DauThietBi dt
                    INNER JOIN ThietBi tb ON dt.IdThietBi = tb.Id AND tb.DaXoa = 0";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dauThietBis.Add(new DauThietBiListDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrangThai = (TrangThaiDauThietBiEnum)Enum.Parse(typeof(TrangThaiDauThietBiEnum), reader["TrangThai"].ToString()),
                            ThoiGianMua = Convert.ToDateTime(reader["ThoiGianMua"]),
                            IdThietBi = Convert.ToInt32(reader["IdThietBi"])
                        });
                    }
                }
            }
            return dauThietBis;
        }

        public void Add(DauThietBiCreateForm form)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                // Kiểm tra IdThietBi hợp lệ
                string checkThietBiSql = "SELECT COUNT(*) FROM ThietBi WHERE Id = @IdThietBi AND DaXoa = 0";
                MySqlCommand checkThietBiCommand = new MySqlCommand(checkThietBiSql, connection);
                checkThietBiCommand.Parameters.AddWithValue("@IdThietBi", form.IdThietBi);
                int thietBiCount = Convert.ToInt32(checkThietBiCommand.ExecuteScalar());

                if (thietBiCount == 0)
                    throw new Exception("Thiết bị không tồn tại hoặc đã bị xóa.");

                string sql = "INSERT INTO DauThietBi (TrangThai, ThoiGianMua, IdThietBi) VALUES (@TrangThai, @ThoiGianMua, @IdThietBi)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TrangThai", form.TrangThai.ToString());
                command.Parameters.AddWithValue("@ThoiGianMua", form.ThoiGianMua);
                command.Parameters.AddWithValue("@IdThietBi", form.IdThietBi);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, DauThietBiUpdateForm form)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                // Kiểm tra IdThietBi hợp lệ
                string checkThietBiSql = "SELECT COUNT(*) FROM ThietBi WHERE Id = @IdThietBi AND DaXoa = 0";
                MySqlCommand checkThietBiCommand = new MySqlCommand(checkThietBiSql, connection);
                checkThietBiCommand.Parameters.AddWithValue("@IdThietBi", form.IdThietBi);
                int thietBiCount = Convert.ToInt32(checkThietBiCommand.ExecuteScalar());

                if (thietBiCount == 0)
                    throw new Exception("Thiết bị không tồn tại hoặc đã bị xóa.");

                string sql = "UPDATE DauThietBi SET TrangThai = @TrangThai, ThoiGianMua = @IdThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@TrangThai", form.TrangThai.ToString());
                command.Parameters.AddWithValue("@ThoiGianMua", form.ThoiGianMua);
                command.Parameters.AddWithValue("@IdThietBi", form.IdThietBi);
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                    throw new Exception("Đầu thiết bị không tồn tại.");
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM DauThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                    throw new Exception("Đầu thiết bị không tồn tại.");
            }
        }

        public IEnumerable<DauThietBiListDTO> Search(int? idThietBi, string trangThai)
        {
            List<DauThietBiListDTO> dauThietBis = new List<DauThietBiListDTO>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT dt.Id, dt.TrangThai, dt.ThoiGianMua, dt.IdThietBi
                    FROM DauThietBi dt
                    INNER JOIN ThietBi tb ON dt.IdThietBi = tb.Id AND tb.DaXoa = 0
                    WHERE 1=1";
                List<string> conditions = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (idThietBi.HasValue)
                {
                    conditions.Add("dt.IdThietBi = @IdThietBi");
                    parameters.Add(new MySqlParameter("@IdThietBi", idThietBi.Value));
                }

                if (!string.IsNullOrEmpty(trangThai))
                {
                    conditions.Add("dt.TrangThai = @TrangThai");
                    parameters.Add(new MySqlParameter("@TrangThai", trangThai));
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
                        dauThietBis.Add(new DauThietBiListDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrangThai = (TrangThaiDauThietBiEnum)Enum.Parse(typeof(TrangThaiDauThietBiEnum), reader["TrangThai"].ToString()),
                            ThoiGianMua = Convert.ToDateTime(reader["ThoiGianMua"]),
                            IdThietBi = Convert.ToInt32(reader["IdThietBi"])
                        });
                    }
                }
            }
            return dauThietBis;
        }
    }
}