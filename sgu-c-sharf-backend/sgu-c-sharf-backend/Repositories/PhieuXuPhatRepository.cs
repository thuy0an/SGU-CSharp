using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Interfaces;
using sgu_c_sharf_backend.Models;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.Models.PhieuXuPhat; // Import IConfiguration

namespace sgu_c_sharf_backend.Repositories
{
    public class PhieuXuPhatRepository : IPhieuXuPhatRepository
    {
        private readonly string _connectionString;

        public PhieuXuPhatRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public PhieuXuPhat GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TrangThai, NgayViPham, MoTa, ThoiHanXuPhat, MucPhat, IdThanhVien FROM PhieuXuPhat WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PhieuXuPhat
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrangThai = (TrangThaiPhieuXuPhatEnum)Enum.Parse(typeof(TrangThaiPhieuXuPhatEnum), reader["TrangThai"].ToString()),
                            NgayViPham = Convert.ToDateTime(reader["NgayViPham"]),
                            MoTa = reader["MoTa"].ToString(),
                            ThoiHanXuPhat = reader["ThoiHanXuPhat"] == DBNull.Value ? null : Convert.ToInt32(reader["ThoiHanXuPhat"]),
                            MucPhat = reader["MucPhat"] == DBNull.Value ? null : Convert.ToInt32(reader["MucPhat"]),
                            IdThanhVien = reader["IdThanhVien"] == DBNull.Value ? null : Convert.ToInt32(reader["IdThanhVien"])
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<PhieuXuPhat> GetAll()
        {
            List<PhieuXuPhat> phieuXuPhats = new List<PhieuXuPhat>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, TrangThai, NgayViPham, MoTa, ThoiHanXuPhat, MucPhat, IdThanhVien FROM PhieuXuPhat";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        phieuXuPhats.Add(new PhieuXuPhat
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrangThai = (TrangThaiPhieuXuPhatEnum)Enum.Parse(typeof(TrangThaiPhieuXuPhatEnum), reader["TrangThai"].ToString()),
                            NgayViPham = Convert.ToDateTime(reader["NgayViPham"]),
                            MoTa = reader["MoTa"].ToString(),
                            ThoiHanXuPhat = reader["ThoiHanXuPhat"] == DBNull.Value ? null : Convert.ToInt32(reader["ThoiHanXuPhat"]),
                            MucPhat = reader["MucPhat"] == DBNull.Value ? null : Convert.ToInt32(reader["MucPhat"]),
                            IdThanhVien = reader["IdThanhVien"] == DBNull.Value ? null : Convert.ToInt32(reader["IdThanhVien"])
                        });
                    }
                }
            }
            return phieuXuPhats;
        }

        public void Add(PhieuXuPhatCreateForm phieuXuPhatCreateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO PhieuXuPhat (TrangThai, NgayViPham, MoTa, ThoiHanXuPhat, MucPhat, IdThanhVien) VALUES (@TrangThai, @NgayViPham, @MoTa, @ThoiHanXuPhat, @MucPhat, @IdThanhVien)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TrangThai", phieuXuPhatCreateForm.TrangThai.ToString());
                command.Parameters.AddWithValue("@NgayViPham", phieuXuPhatCreateForm.NgayViPham);
                command.Parameters.AddWithValue("@MoTa", phieuXuPhatCreateForm.MoTa);
                command.Parameters.AddWithValue("@ThoiHanXuPhat", phieuXuPhatCreateForm.ThoiHanXuPhat.HasValue ? (object)phieuXuPhatCreateForm.ThoiHanXuPhat.Value : DBNull.Value);
                command.Parameters.AddWithValue("@MucPhat", phieuXuPhatCreateForm.MucPhat.HasValue ? (object)phieuXuPhatCreateForm.MucPhat.Value : DBNull.Value);
                 command.Parameters.AddWithValue("@IdThanhVien", phieuXuPhatCreateForm.IdThanhVien.HasValue ? (object)phieuXuPhatCreateForm.IdThanhVien.Value : DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, PhieuXuPhatUpdateForm phieuXuPhatUpdateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE PhieuXuPhat SET TrangThai = @TrangThai, NgayViPham = @NgayViPham, MoTa = @MoTa, ThoiHanXuPhat = @ThoiHanXuPhat, MucPhat = @MucPhat, IdThanhVien = @IdThanhVien WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@TrangThai", phieuXuPhatUpdateForm.TrangThai.ToString());
                command.Parameters.AddWithValue("@NgayViPham", phieuXuPhatUpdateForm.NgayViPham);
                command.Parameters.AddWithValue("@MoTa", phieuXuPhatUpdateForm.MoTa);
                 command.Parameters.AddWithValue("@ThoiHanXuPhat", phieuXuPhatUpdateForm.ThoiHanXuPhat.HasValue ? (object)phieuXuPhatUpdateForm.ThoiHanXuPhat.Value : DBNull.Value);
                command.Parameters.AddWithValue("@MucPhat", phieuXuPhatUpdateForm.MucPhat.HasValue ? (object)phieuXuPhatUpdateForm.MucPhat.Value : DBNull.Value);
                command.Parameters.AddWithValue("@IdThanhVien", phieuXuPhatUpdateForm.IdThanhVien.HasValue ? (object)phieuXuPhatUpdateForm.IdThanhVien.Value : DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM PhieuXuPhat WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<PhieuXuPhat> Search(string? trangThai, DateTime? ngayViPhamStart, DateTime? ngayViPhamEnd, string? moTa, int? thoiHanXuPhat, int? mucPhat, int? idThanhVien)
        {
            List<PhieuXuPhat> phieuXuPhats = new List<PhieuXuPhat>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT Id, TrangThai, NgayViPham, MoTa, ThoiHanXuPhat, MucPhat, IdThanhVien FROM PhieuXuPhat WHERE 1=1";
                List<string> conditions = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(trangThai))
                {
                    conditions.Add("TrangThai = @TrangThai");
                    parameters.Add(new MySqlParameter("@TrangThai", trangThai));
                }

                if (ngayViPhamStart.HasValue)
                {
                    conditions.Add("NgayViPham >= @NgayViPhamStart");
                    parameters.Add(new MySqlParameter("@NgayViPhamStart", ngayViPhamStart.Value));
                }

                if (ngayViPhamEnd.HasValue)
                {
                    conditions.Add("NgayViPham <= @NgayViPhamEnd");
                    parameters.Add(new MySqlParameter("@NgayViPhamEnd", ngayViPhamEnd.Value));
                }

                if (!string.IsNullOrEmpty(moTa))
                {
                    conditions.Add("MoTa LIKE @MoTa");
                    parameters.Add(new MySqlParameter("@MoTa", "%" + moTa + "%"));
                }
                  if (thoiHanXuPhat.HasValue)
                {
                    conditions.Add("ThoiHanXuPhat = @ThoiHanXuPhat");
                    parameters.Add(new MySqlParameter("@ThoiHanXuPhat", thoiHanXuPhat.Value));
                }
                  if (mucPhat.HasValue)
                {
                    conditions.Add("MucPhat = @MucPhat");
                    parameters.Add(new MySqlParameter("@MucPhat", mucPhat.Value));
                }

                if (idThanhVien.HasValue)
                {
                    conditions.Add("IdThanhVien = @IdThanhVien");
                    parameters.Add(new MySqlParameter("@IdThanhVien", idThanhVien.Value));
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
                         phieuXuPhats.Add(new PhieuXuPhat
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrangThai = (TrangThaiPhieuXuPhatEnum)Enum.Parse(typeof(TrangThaiPhieuXuPhatEnum), reader["TrangThai"].ToString()),
                            NgayViPham = Convert.ToDateTime(reader["NgayViPham"]),
                            MoTa = reader["MoTa"].ToString(),
                            ThoiHanXuPhat = reader["ThoiHanXuPhat"] == DBNull.Value ? null : Convert.ToInt32(reader["ThoiHanXuPhat"]),
                            MucPhat = reader["MucPhat"] == DBNull.Value ? null : Convert.ToInt32(reader["MucPhat"]),
                            IdThanhVien = reader["IdThanhVien"] == DBNull.Value ? null : Convert.ToInt32(reader["IdThanhVien"])
                        });
                    }
                }
            }
            return phieuXuPhats;
        }
    }
}