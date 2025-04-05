// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Text;
// using Microsoft.Extensions.Configuration;
// using MySql.Data.MySqlClient;
// using sgu_c_sharf_backend.Models;
// using sgu_c_sharf_backend.Models.LoaiThietBi;
// using sgu_c_sharf_backend.Models.ThietBi;
//
// namespace sgu_c_sharf_backend.Repositories
// {
//     public class DauThietBiRepository
//     {
//         private readonly string _connectionString;
//
//         public DauThietBiRepository(IConfiguration configuration)
//         {
//             _connectionString = configuration.GetConnectionString("DefaultConnection");
//         }
//
//         public DauThietBi? GetById(int id)
//         {
//             DauThietBi? dauThietBi = null;
//
//             try
//             {
//                 using var connection = new MySqlConnection(_connectionString);
//                 connection.Open();
//
//                 string query = @"
//                     SELECT 
//                         DB.Id, 
//                         DB.TrangThai, 
//                         DB.ThoiGianMua, 
//                         DB.IdThietBi,
//                         TB.TenThietBi, 
//                         LTB.TenLoaiThietBi
//                     FROM DauThietBi DB
//                     INNER JOIN ThietBi TB ON DB.IdThietBi = TB.Id
//                     INNER JOIN LoaiThietBi LTB ON TB.IdLoaiThietBi = LTB.Id
//                     WHERE DB.Id = @Id";
//
//                 using var command = new MySqlCommand(query, connection);
//                 command.Parameters.AddWithValue("@Id", id);
//
//                 using var reader = command.ExecuteReader();
//                 if (reader.Read())
//                 {
//                     dauThietBi = new DauThietBi
//                     {
//                         Id = reader.GetInt32("Id"),
//                         TrangThai = Enum.Parse<TrangThaiDauThietBiEnum>(reader.GetString("TrangThai")),
//                         ThoiGianMua = reader.GetDateTime("ThoiGianMua"),
//                         IdThietBi = reader.GetInt32("IdThietBi"),
//                         ThietBi = new ThietBi
//                         {
//                             Id = reader.GetInt32("IdThietBi"), //Lấy luôn ID thiết bị
//                             TenThietBi = reader.GetString("TenThietBi"),
//                             LoaiThietBi = new LoaiThietBi
//                             {
//                                 TenLoaiThietBi = reader.GetString("TenLoaiThietBi")
//                             }
//                         }
//                     };
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Ghi log lỗi
//                 Console.WriteLine($"Lỗi khi lấy DauThietBi theo ID: {ex.Message}");
//                 return null; // Hoặc throw
//             }
//
//             return dauThietBi;
//         }
//
//         public IEnumerable<DauThietBi> GetAll()
//         {
//             List<DauThietBi> dauThietBis = new List<DauThietBi>();
//
//             try
//             {
//                 using var connection = new MySqlConnection(_connectionString);
//                 connection.Open();
//
//                 string query = @"
//                     SELECT 
//                         DB.Id, 
//                         DB.TrangThai, 
//                         DB.ThoiGianMua, 
//                         DB.IdThietBi,
//                         TB.TenThietBi, 
//                         LTB.TenLoaiThietBi
//                     FROM DauThietBi DB
//                     INNER JOIN ThietBi TB ON DB.IdThietBi = TB.Id
//                     INNER JOIN LoaiThietBi LTB ON TB.IdLoaiThietBi = LTB.Id";
//
//                 using var command = new MySqlCommand(query, connection);
//
//                 using var reader = command.ExecuteReader();
//                 while (reader.Read())
//                 {
//                     dauThietBis.Add(new DauThietBi
//                     {
//                         Id = reader.GetInt32("Id"),
//                         TrangThai = Enum.Parse<TrangThaiDauThietBiEnum>(reader.GetString("TrangThai")),
//                         ThoiGianMua = reader.GetDateTime("ThoiGianMua"),
//                         IdThietBi = reader.GetInt32("IdThietBi"),
//                          ThietBi = new ThietBi
//                         {
//                             Id = reader.GetInt32("IdThietBi"), //Lấy luôn ID thiết bị
//                             TenThietBi = reader.GetString("TenThietBi"),
//                             LoaiThietBi = new LoaiThietBi
//                             {
//                                 TenLoaiThietBi = reader.GetString("TenLoaiThietBi")
//                             }
//                         }
//                     });
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Ghi log lỗi
//                 Console.WriteLine($"Lỗi khi lấy danh sách DauThietBi: {ex.Message}");
//                 return new List<DauThietBi>(); // Hoặc throw
//             }
//
//             return dauThietBis;
//         }
//
//         public void Add(DauThietBiCreateForm dauThietBiCreateForm)
//         {
//             try
//             {
//                 using var connection = new MySqlConnection(_connectionString);
//                 connection.Open();
//
//                 string query = @"INSERT INTO DauThietBi (TrangThai, ThoiGianMua, IdThietBi) 
//                                 VALUES (@TrangThai, @ThoiGianMua, @IdThietBi)";
//
//                 using var command = new MySqlCommand(query, connection);
//                 command.Parameters.AddWithValue("@TrangThai", dauThietBiCreateForm.TrangThai.ToString());
//                 command.Parameters.AddWithValue("@ThoiGianMua", dauThietBiCreateForm.ThoiGianMua);
//                 command.Parameters.AddWithValue("@IdThietBi", dauThietBiCreateForm.IdThietBi);
//
//                 command.ExecuteNonQuery();
//             }
//             catch (Exception ex)
//             {
//                 // Ghi log lỗi
//                 Console.WriteLine($"Lỗi khi thêm DauThietBi: {ex.Message}");
//                 // Hoặc throw
//             }
//         }
//
//         public void Update(DauThietBiUpdateForm dauThietBiUpdateForm)
//         {
//             try
//             {
//                 using var connection = new MySqlConnection(_connectionString);
//                 connection.Open();
//
//                 string query = @"UPDATE DauThietBi 
//                                 SET TrangThai = @TrangThai, 
//                                     ThoiGianMua = @ThoiGianMua, 
//                                     IdThietBi = @IdThietBi 
//                                 WHERE Id = @Id";
//
//                 using var command = new MySqlCommand(query, connection);
//                 command.Parameters.AddWithValue("@Id", dauThietBiUpdateForm.Id); //Use the ID from the form
//                 command.Parameters.AddWithValue("@TrangThai", dauThietBiUpdateForm.TrangThai.ToString());
//                 command.Parameters.AddWithValue("@ThoiGianMua", dauThietBiUpdateForm.ThoiGianMua);
//                 command.Parameters.AddWithValue("@IdThietBi", dauThietBiUpdateForm.IdThietBi);
//
//                 command.ExecuteNonQuery();
//             }
//             catch (Exception ex)
//             {
//                 // Ghi log lỗi
//                 Console.WriteLine($"Lỗi khi cập nhật DauThietBi: {ex.Message}");
//                 // Hoặc throw
//             }
//         }
//
//         public IEnumerable<DauThietBi> Search(string? trangThai, DateTime? thoiGianMuaStart, DateTime? thoiGianMuaEnd, int? idThietBi)
//         {
//             List<DauThietBi> dauThietBis = new List<DauThietBi>();
//
//             try
//             {
//                 using var connection = new MySqlConnection(_connectionString);
//                 connection.Open();
//
//                 StringBuilder queryBuilder = new StringBuilder(@"
//                     SELECT 
//                         DB.Id, 
//                         DB.TrangThai, 
//                         DB.ThoiGianMua, 
//                         DB.IdThietBi,
//                         TB.TenThietBi, 
//                         LTB.TenLoaiThietBi
//                     FROM DauThietBi DB
//                     INNER JOIN ThietBi TB ON DB.IdThietBi = TB.Id
//                     INNER JOIN LoaiThietBi LTB ON TB.IdLoaiThietBi = LTB.Id
//                     WHERE 1=1");
//
//                 List<MySqlParameter> parameters = new List<MySqlParameter>();
//
//                 if (!string.IsNullOrEmpty(trangThai))
//                 {
//                     queryBuilder.Append(" AND DB.TrangThai = @TrangThai");
//                     parameters.Add(new MySqlParameter("@TrangThai", trangThai));
//                 }
//
//                 if (thoiGianMuaStart.HasValue)
//                 {
//                     queryBuilder.Append(" AND DB.ThoiGianMua >= @ThoiGianMuaStart");
//                     parameters.Add(new MySqlParameter("@ThoiGianMuaStart", thoiGianMuaStart.Value));
//                 }
//
//                 if (thoiGianMuaEnd.HasValue)
//                 {
//                     queryBuilder.Append(" AND DB.ThoiGianMua <= @ThoiGianMuaEnd");
//                     parameters.Add(new MySqlParameter("@ThoiGianMuaEnd", thoiGianMuaEnd.Value));
//                 }
//
//                 if (idThietBi.HasValue)
//                 {
//                     queryBuilder.Append(" AND DB.IdThietBi = @IdThietBi");
//                     parameters.Add(new MySqlParameter("@IdThietBi", idThietBi.Value));
//                 }
//
//                 using var command = new MySqlCommand(queryBuilder.ToString(), connection);
//                 command.Parameters.AddRange(parameters.ToArray());
//
//                 using var reader = command.ExecuteReader();
//                 while (reader.Read())
//                 {
//                     dauThietBis.Add(new DauThietBi
//                     {
//                         Id = reader.GetInt32("Id"),
//                         TrangThai = Enum.Parse<TrangThaiDauThietBiEnum>(reader.GetString("TrangThai")),
//                         ThoiGianMua = reader.GetDateTime("ThoiGianMua"),
//                         IdThietBi = reader.GetInt32("IdThietBi"),
//                          ThietBi = new ThietBi
//                         {
//                             Id = reader.GetInt32("IdThietBi"), //Lấy luôn ID thiết bị
//                             TenThietBi = reader.GetString("TenThietBi"),
//                             LoaiThietBi = new LoaiThietBi
//                             {
//                                 TenLoaiThietBi = reader.GetString("TenLoaiThietBi")
//                             }
//                         }
//                     });
//                 }
//             }
//              catch (Exception ex)
//             {
//                 // Ghi log lỗi
//                 Console.WriteLine($"Lỗi khi tìm kiếm DauThietBi: {ex.Message}");
//                 return new List<DauThietBi>(); // Hoặc throw
//             }
//
//             return dauThietBis;
//         }
//
//         public int UpdateByCondition(
//             string? trangThaiCondition,
//             DateTime? thoiGianMuaStartCondition,
//             DateTime? thoiGianMuaEndCondition,
//             int? idThietBiCondition,
//             DauThietBiUpdateForm updateValues)
//         {
//              int rowsAffected = 0;
//             try
//             {
//                 using var connection = new MySqlConnection(_connectionString);
//                 connection.Open();
//
//                 StringBuilder queryBuilder = new StringBuilder("UPDATE DauThietBi SET ");
//                 List<string> setClauses = new List<string>();
//                 List<MySqlParameter> parameters = new List<MySqlParameter>();
//
//                 if (updateValues != null)
//                 {
//                     setClauses.Add("TrangThai = @NewTrangThai");
//                     parameters.Add(new MySqlParameter("@NewTrangThai", updateValues.TrangThai.ToString()));
//
//                     setClauses.Add("ThoiGianMua = @NewThoiGianMua");
//                     parameters.Add(new MySqlParameter("@NewThoiGianMua", updateValues.ThoiGianMua));
//
//                     setClauses.Add("IdThietBi = @NewIdThietBi");
//                     parameters.Add(new MySqlParameter("@NewIdThietBi", updateValues.IdThietBi));
//                 }
//
//                 queryBuilder.Append(string.Join(", ", setClauses));
//
//                 queryBuilder.Append(" WHERE 1=1");
//
//                 if (!string.IsNullOrEmpty(trangThaiCondition))
//                 {
//                     queryBuilder.Append(" AND TrangThai = @TrangThaiCondition");
//                     parameters.Add(new MySqlParameter("@TrangThaiCondition", trangThaiCondition));
//                 }
//
//                 if (thoiGianMuaStartCondition.HasValue)
//                 {
//                     queryBuilder.Append(" AND ThoiGianMua >= @ThoiGianMuaStartCondition");
//                     parameters.Add(new MySqlParameter("@ThoiGianMuaStartCondition", thoiGianMuaStartCondition.Value));
//                 }
//
//                 if (thoiGianMuaEndCondition.HasValue)
//                 {
//                     queryBuilder.Append(" AND ThoiGianMua <= @ThoiGianMuaEndCondition");
//                     parameters.Add(new MySqlParameter("@ThoiGianMuaEndCondition", thoiGianMuaEndCondition.Value));
//                 }
//
//                 if (idThietBiCondition.HasValue)
//                 {
//                     queryBuilder.Append(" AND IdThietBi = @IdThietBiCondition");
//                     parameters.Add(new MySqlParameter("@IdThietBiCondition", idThietBiCondition.Value));
//                 }
//
//                 using var command = new MySqlCommand(queryBuilder.ToString(), connection);
//                 command.Parameters.AddRange(parameters.ToArray());
//
//                 rowsAffected = command.ExecuteNonQuery();
//             }
//             catch (Exception ex)
//             {
//                 // Ghi log lỗi
//                 Console.WriteLine($"Lỗi khi cập nhật theo điều kiện DauThietBi: {ex.Message}");
//                 //Hoặc throw
//             }
//             return rowsAffected;
//         }
//     }
// }