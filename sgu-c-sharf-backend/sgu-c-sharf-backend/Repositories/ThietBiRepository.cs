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

        public List<ThietBiListAvailabilityDTO> GetAllWithAvailability()
        {
            List<ThietBiListAvailabilityDTO> thietBis = new List<ThietBiListAvailabilityDTO>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                                    SELECT 
                            tb.Id, 
                            tb.TenThietBi, 
                            ltb.TenLoaiThietBi, 
                            COALESCE(COUNT(CASE WHEN dtb.TrangThai = 'KHADUNG' THEN 1 END), 0) AS SoLuongKhaDung
                        FROM ThietBi tb
                        INNER JOIN LoaiThietBi ltb ON tb.IdLoaiThietBi = ltb.Id AND ltb.DaXoa = 0
                        LEFT JOIN DauThietBi dtb ON dtb.IdThietBi = tb.Id
                        WHERE tb.DaXoa = 0
                        GROUP BY tb.Id, tb.TenThietBi, ltb.TenLoaiThietBi
                        HAVING SoLuongKhaDung > 0";

                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thietBis.Add(new ThietBiListAvailabilityDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
                            SoLuongKhaDung = Convert.ToInt32(reader["SoLuongKhaDung"])
                        });
                    }
                }
            }

            return thietBis;
        }

        public ThietBiListAvailabilityDTO GetByIdWithAvailability(int id)
        {
            ThietBiListAvailabilityDTO thietBi = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                        SELECT 
                            tb.Id, 
                            tb.TenThietBi, 
                            ltb.TenLoaiThietBi, 
                            COALESCE(COUNT(CASE WHEN dtb.TrangThai = 'KHADUNG' THEN 1 END), 0) AS SoLuongKhaDung
                        FROM ThietBi tb
                        INNER JOIN LoaiThietBi ltb ON tb.IdLoaiThietBi = ltb.Id AND ltb.DaXoa = 0
                        LEFT JOIN DauThietBi dtb ON dtb.IdThietBi = tb.Id
                        WHERE tb.DaXoa = 0 AND tb.Id = @id
                        GROUP BY tb.Id, tb.TenThietBi, ltb.TenLoaiThietBi";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        thietBi = new ThietBiListAvailabilityDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TenThietBi = reader["TenThietBi"].ToString(),
                            TenLoaiThietBi = reader["TenLoaiThietBi"].ToString(),
                            SoLuongKhaDung = Convert.ToInt32(reader["SoLuongKhaDung"])
                        };
                    }
                }
            }

            return thietBi;
        }

        public void Add(ThietBiCreateForm thietBiCreateForm)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Kiểm tra IdLoaiThietBi hợp lệ
                    string checkLoaiSql = "SELECT COUNT(*) FROM LoaiThietBi WHERE Id = @IdLoaiThietBi AND DaXoa = 0";
                    MySqlCommand checkLoaiCommand = new MySqlCommand(checkLoaiSql, connection, transaction);
                    checkLoaiCommand.Parameters.AddWithValue("@IdLoaiThietBi", thietBiCreateForm.IdLoaiThietBi);
                    int loaiCount = Convert.ToInt32(checkLoaiCommand.ExecuteScalar());

                    if (loaiCount == 0)
                        throw new Exception("Loại thiết bị không tồn tại hoặc đã bị xóa.");

                    // Kiểm tra TenThietBi không trùng
                    string checkDuplicateSql = "SELECT COUNT(*) FROM ThietBi WHERE TenThietBi = @TenThietBi AND DaXoa = 0";
                    MySqlCommand checkDuplicateCommand = new MySqlCommand(checkDuplicateSql, connection, transaction);
                    checkDuplicateCommand.Parameters.AddWithValue("@TenThietBi", thietBiCreateForm.TenThietBi);
                    int duplicateCount = Convert.ToInt32(checkDuplicateCommand.ExecuteScalar());

                    if (duplicateCount > 0)
                        throw new Exception("Tên thiết bị đã tồn tại.");

                    // Thêm thiết bị
                    string insertThietBiSql = "INSERT INTO ThietBi (TenThietBi, IdLoaiThietBi, DaXoa, AnhMinhHoa) VALUES (@TenThietBi, @IdLoaiThietBi, 0, @AnhMinhHoa); SELECT LAST_INSERT_ID();";
                    MySqlCommand insertThietBiCommand = new MySqlCommand(insertThietBiSql, connection, transaction);
                    insertThietBiCommand.Parameters.AddWithValue("@TenThietBi", thietBiCreateForm.TenThietBi);
                    insertThietBiCommand.Parameters.AddWithValue("@IdLoaiThietBi", thietBiCreateForm.IdLoaiThietBi);
                    insertThietBiCommand.Parameters.AddWithValue("@AnhMinhHoa",thietBiCreateForm.AnhMinhHoa);
                    int thietBiId = Convert.ToInt32(insertThietBiCommand.ExecuteScalar());

                    // Thêm các đầu thiết bị
                    string insertDauThietBiSql = "INSERT INTO DauThietBi (TrangThai, ThoiGianMua, IdThietBi) VALUES (@TrangThai, @ThoiGianMua, @IdThietBi)";
                    MySqlCommand insertDauThietBiCommand = new MySqlCommand(insertDauThietBiSql, connection, transaction);

                    for (int i = 1; i <= thietBiCreateForm.SoLuongDauThietBi; i++)
                    {
                        insertDauThietBiCommand.Parameters.Clear();
                        insertDauThietBiCommand.Parameters.AddWithValue("@TrangThai", TrangThaiDauThietBiEnum.KHADUNG.ToString());
                        insertDauThietBiCommand.Parameters.AddWithValue("@ThoiGianMua", DateTime.Now);
                        insertDauThietBiCommand.Parameters.AddWithValue("@IdThietBi", thietBiId);
                        insertDauThietBiCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public void ThemDauThietBi(int idThietBi, int soLuong)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string insertSql = "INSERT INTO DauThietBi (TrangThai, ThoiGianMua, IdThietBi) VALUES (@TrangThai, @ThoiGianMua, @IdThietBi)";
                    MySqlCommand insertCommand = new MySqlCommand(insertSql, connection, transaction);

                    for (int i = 0; i < soLuong; i++)
                    {
                        insertCommand.Parameters.Clear();
                        insertCommand.Parameters.AddWithValue("@TrangThai", TrangThaiDauThietBiEnum.KHADUNG.ToString());
                        insertCommand.Parameters.AddWithValue("@ThoiGianMua", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@IdThietBi", idThietBi);
                        insertCommand.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
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

        public IEnumerable<DauThietBiListDTO> GetDauThietBiByThietBiId(int idThietBi)
        {
            List<DauThietBiListDTO> dauThietBis = new List<DauThietBiListDTO>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT dtb.Id, dtb.TrangThai, dtb.ThoiGianMua, dtb.IdThietBi
                    FROM DauThietBi dtb
                    WHERE dtb.IdThietBi = @IdThietBi";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@IdThietBi", idThietBi);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string trangThaiString = reader["TrangThai"].ToString();
                        if (!Enum.TryParse<TrangThaiDauThietBiEnum>(trangThaiString, true, out var trangThai))
                        {
                            throw new Exception($"Giá trị TrangThai không hợp lệ: {trangThaiString}");
                        }

                        dauThietBis.Add(new DauThietBiListDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrangThai = trangThai,
                            ThoiGianMua = Convert.ToDateTime(reader["ThoiGianMua"]),
                            IdThietBi = Convert.ToInt32(reader["IdThietBi"])
                        });
                    }
                }
            }
            return dauThietBis;
        }

        public HinhAnhThietBi? GetHinhAnhById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT Id, AnhMinhHoa
                    FROM ThietBi
                    WHERE Id = @Id AND DaXoa = 0";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HinhAnhThietBi
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            AnhMinhHoa = reader["AnhMinhHoa"].ToString()
                        };
                    }
                    return null;
                }
            }
        }
    }
}