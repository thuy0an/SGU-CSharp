using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Models;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.Models.ThietBi; // Import IConfiguration

namespace sgu_c_sharf_backend.Repositories
{
    public class LoaiThietBiRepository 
    {
        private readonly string _connectionString;

        public LoaiThietBiRepository(IConfiguration configuration,ThietBiRepository thietBiRepository)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); // Lấy từ config

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

        public IEnumerable<LoaiThietBi> GetAll()
        {
            List<LoaiThietBi> loaiThietBis = new List<LoaiThietBi>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TenLoaiThietBi, DaXoa FROM LoaiThietBi";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loaiThietBis.Add(new LoaiThietBi
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        });
                    }
                }
            }
            return loaiThietBis;
        }

        public void Add(LoaiThietBiCreateForm loaiThietBiCreateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO LoaiThietBi (TenLoaiThietBi) VALUES (@TenLoaiThietBi)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenLoaiThietBi", loaiThietBiCreateForm.TenLoaiThietBi);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, LoaiThietBiUpdateForm loaiThietBiUpdateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE LoaiThietBi SET TenLoaiThietBi = @TenLoaiThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@TenLoaiThietBi", loaiThietBiUpdateForm.TenLoaiThietBi);
                command.ExecuteNonQuery();
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

        public IEnumerable<LoaiThietBi> Search(string? tenLoaiThietBi, bool? daXoa)
        {
            List<LoaiThietBi> loaiThietBis = new List<LoaiThietBi>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT Id, TenLoaiThietBi, DaXoa FROM LoaiThietBi WHERE 1=1";
                List<string> conditions = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(tenLoaiThietBi))
                {
                    conditions.Add("TenLoaiThietBi LIKE @TenLoaiThietBi");
                    parameters.Add(new MySqlParameter("@TenLoaiThietBi", "%" + tenLoaiThietBi + "%"));
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
                        loaiThietBis.Add(new LoaiThietBi
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
                            DaXoa = Convert.ToBoolean(reader["DaXoa"])
                        });
                    }
                }
            }
            return loaiThietBis;
        }

    }
}