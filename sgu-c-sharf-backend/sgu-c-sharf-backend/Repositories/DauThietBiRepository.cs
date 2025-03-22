using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Interfaces;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Repositories
{
    public class DauThietBiRepository : IDauThietBiRepository
    {
        private readonly string _connectionString;
        private IDauThietBiRepository _dauThietBiRepositoryImplementation;

        public DauThietBiRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DauThietBi GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TrangThai, ThoiGianMua, IdThietBi FROM DauThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (Enum.TryParse(reader["TrangThai"].ToString(), out TrangThaiDauThietBiEnum trangThai))
                        {
                            return new DauThietBi
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                TrangThai = trangThai,
                                ThoiGianMua = Convert.ToDateTime(reader["ThoiGianMua"]),
                                IdThietBi = Convert.ToInt32(reader["IdThietBi"])
                            };
                        }
                        else
                        {
                            // Log lỗi hoặc xử lý trường hợp enum không hợp lệ
                            Console.WriteLine($"Giá trị enum không hợp lệ: {reader["TrangThai"]}");
                            return null; // Hoặc throw exception
                        }
                    }

                    return null;
                }
            }
        }

        public IEnumerable<DauThietBi> GetAll()
        {
            List<DauThietBi> dauThietBis = new List<DauThietBi>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TrangThai, ThoiGianMua, IdThietBi FROM DauThietBi";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Enum.TryParse(reader["TrangThai"].ToString(), out TrangThaiDauThietBiEnum trangThai))
                        {
                            dauThietBis.Add(new DauThietBi
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                TrangThai = trangThai,
                                ThoiGianMua = Convert.ToDateTime(reader["ThoiGianMua"]),
                                IdThietBi = Convert.ToInt32(reader["IdThietBi"])
                            });
                        }
                        else
                        {
                            // Log lỗi hoặc xử lý trường hợp enum không hợp lệ
                            Console.WriteLine($"Giá trị enum không hợp lệ: {reader["TrangThai"]}");
                            continue; // Hoặc throw exception
                        }
                    }
                }
            }

            return dauThietBis;
        }

        public void Add(DauThietBiCreateForm dauThietBiCreateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql =
                    "INSERT INTO DauThietBi (TrangThai, ThoiGianMua, IdThietBi) VALUES (@TrangThai, @ThoiGianMua, @IdThietBi)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TrangThai", dauThietBiCreateForm.TrangThai.ToString());
                command.Parameters.AddWithValue("@ThoiGianMua", dauThietBiCreateForm.ThoiGianMua);
                command.Parameters.AddWithValue("@IdThietBi", dauThietBiCreateForm.IdThietBi);
                command.ExecuteNonQuery();
            }
        }

        public void Update(DauThietBiUpdateForm dauThietBiUpdateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql =
                    "UPDATE DauThietBi SET TrangThai = @TrangThai, ThoiGianMua = @ThoiGianMua, IdThietBi = @IdThietBi WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", dauThietBiUpdateForm.IdThietBi); // Sử dụng ID truyền vào
                command.Parameters.AddWithValue("@TrangThai", dauThietBiUpdateForm.TrangThai.ToString());
                command.Parameters.AddWithValue("@ThoiGianMua", dauThietBiUpdateForm.ThoiGianMua);
                command.Parameters.AddWithValue("@IdThietBi", dauThietBiUpdateForm.IdThietBi);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DauThietBi> Search(string trangThai, DateTime? thoiGianMuaStart, DateTime? thoiGianMuaEnd,
            int? idThietBi)
        {
            List<DauThietBi> dauThietBis = new List<DauThietBi>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT Id, TrangThai, ThoiGianMua, IdThietBi FROM DauThietBi WHERE 1=1";
                List<string> conditions = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(trangThai))
                {
                    conditions.Add("TrangThai = @TrangThai");
                    parameters.Add(new MySqlParameter("@TrangThai", trangThai));
                }

                if (thoiGianMuaStart.HasValue)
                {
                    conditions.Add("ThoiGianMua >= @ThoiGianMuaStart");
                    parameters.Add(new MySqlParameter("@ThoiGianMuaStart", thoiGianMuaStart.Value));
                }

                if (thoiGianMuaEnd.HasValue)
                {
                    conditions.Add("ThoiGianMua <= @ThoiGianMuaEnd");
                    parameters.Add(new MySqlParameter("@ThoiGianMuaEnd", thoiGianMuaEnd.Value));
                }

                if (idThietBi.HasValue)
                {
                    conditions.Add("IdThietBi = @IdThietBi");
                    parameters.Add(new MySqlParameter("@IdThietBi", idThietBi.Value));
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
                        if (Enum.TryParse(reader["TrangThai"].ToString(), out TrangThaiDauThietBiEnum trangThaiEnum))
                        {
                            dauThietBis.Add(new DauThietBi
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                TrangThai = trangThaiEnum,
                                ThoiGianMua = Convert.ToDateTime(reader["ThoiGianMua"]),
                                IdThietBi = Convert.ToInt32(reader["IdThietBi"])
                            });
                        }
                        else
                        {
                            // Log lỗi hoặc xử lý trường hợp enum không hợp lệ
                            Console.WriteLine($"Giá trị enum không hợp lệ: {reader["TrangThai"]}");
                            continue; // Hoặc throw exception
                        }
                    }
                }
            }

            return dauThietBis;
        }

        public int UpdateByCondition(
            string? trangThaiCondition,
            DateTime? thoiGianMuaStartCondition,
            DateTime? thoiGianMuaEndCondition,
            int? idThietBiCondition,
            DauThietBiUpdateForm? updateValues)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "UPDATE DauThietBi SET ";
                List<string> setClauses = new List<string>();
                List<string> whereClauses = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Xây dựng mệnh đề SET
                setClauses.Add("TrangThai = @NewTrangThai");
                parameters.Add(new MySqlParameter("@NewTrangThai", updateValues.TrangThai.ToString()));


                setClauses.Add("ThoiGianMua = @NewThoiGianMua");
                parameters.Add(new MySqlParameter("@NewThoiGianMua", updateValues.ThoiGianMua));


                setClauses.Add("IdThietBi = @NewIdThietBi");
                parameters.Add(new MySqlParameter("@NewIdThietBi", updateValues.IdThietBi));


                sql += string.Join(", ", setClauses);

                // Xây dựng mệnh đề WHERE
                sql += " WHERE 1=1";
                if (!string.IsNullOrEmpty(trangThaiCondition))
                {
                    whereClauses.Add("TrangThai = @TrangThaiCondition");
                    parameters.Add(new MySqlParameter("@TrangThaiCondition", trangThaiCondition));
                }

                if (thoiGianMuaStartCondition.HasValue)
                {
                    whereClauses.Add("ThoiGianMua >= @ThoiGianMuaStartCondition");
                    parameters.Add(new MySqlParameter("@ThoiGianMuaStartCondition", thoiGianMuaStartCondition.Value));
                }

                if (thoiGianMuaEndCondition.HasValue)
                {
                    whereClauses.Add("ThoiGianMua <= @ThoiGianMuaEndCondition");
                    parameters.Add(new MySqlParameter("@ThoiGianMuaEndCondition", thoiGianMuaEndCondition.Value));
                }

                if (idThietBiCondition.HasValue)
                {
                    whereClauses.Add("IdThietBi = @IdThietBiCondition");
                    parameters.Add(new MySqlParameter("@IdThietBiCondition", idThietBiCondition.Value));
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
    }
}