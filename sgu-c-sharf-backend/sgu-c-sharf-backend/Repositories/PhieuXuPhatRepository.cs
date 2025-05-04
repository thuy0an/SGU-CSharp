using MySql.Data.MySqlClient;
using Dapper;
using sgu_c_sharf_backend.Models.PhieuXuPhat;
using System;

namespace sgu_c_sharf_backend.Repositories
{
    public class PhieuXuPhatRepository
    {
        private readonly string _connectionString;

        public PhieuXuPhatRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new ArgumentException("Connection string 'DefaultConnection' not found.");
        }

        public List<PhieuXuPhatDetailDTO> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"
                        SELECT pxp.Id, pxp.TrangThai, pxp.NgayViPham, pxp.MoTa,
                               pxp.ThoiHanXuPhat, pxp.MucPhat, pxp.IdThanhVien,
                               tv.HoTen AS TenThanhVien
                        FROM PhieuXuPhat pxp
                        INNER JOIN ThanhVien tv ON pxp.IdThanhVien = tv.Id
                        WHERE pxp.TrangThai != 'DAXOA';";
                    return connection.Query<PhieuXuPhatDetailDTO>(sql).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving list of violation tickets", ex);
                }
            }
        }

        public PhieuXuPhatPagingResponse GetAllPaging(int page, int limit, TrangThaiPhieuXuPhatEnum? trangThai, DateTime? fromDate, DateTime? toDate, string? keyword)
        {
            if (page < 1 || limit < 1)
            {
                throw new ArgumentException("Page and limit must be greater than 0");
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string countSql = @"
                        SELECT COUNT(*)
                        FROM PhieuXuPhat pxp
                        INNER JOIN ThanhVien tv ON pxp.IdThanhVien = tv.Id
                        WHERE pxp.TrangThai != 'DAXOA'
                        AND (@TrangThai IS NULL OR pxp.TrangThai = @TrangThai)
                        AND (@FromDate IS NULL OR pxp.NgayViPham >= @FromDate)
                        AND (@ToDate IS NULL OR pxp.NgayViPham <= @ToDate)
                        AND (@Keyword IS NULL OR pxp.MoTa LIKE CONCAT('%', @Keyword, '%') OR tv.HoTen LIKE CONCAT('%', @Keyword, '%') OR pxp.Id LIKE CONCAT('%', @Keyword, '%'));";

                    int totalItems = connection.ExecuteScalar<int>(countSql, new
                    {
                        TrangThai = trangThai?.ToString(),
                        FromDate = fromDate,
                        ToDate = toDate,
                        Keyword = keyword
                    });

                    string sql = @"
                        SELECT pxp.Id, pxp.TrangThai, pxp.NgayViPham, pxp.MoTa,
                               pxp.ThoiHanXuPhat, pxp.MucPhat, pxp.IdThanhVien,
                               tv.HoTen AS TenThanhVien
                        FROM PhieuXuPhat pxp
                        INNER JOIN ThanhVien tv ON pxp.IdThanhVien = tv.Id
                        WHERE pxp.TrangThai != 'DAXOA'
                        AND (@TrangThai IS NULL OR pxp.TrangThai = @TrangThai)
                        AND (@FromDate IS NULL OR pxp.NgayViPham >= @FromDate)
                        AND (@ToDate IS NULL OR pxp.NgayViPham <= @ToDate)
                        AND (@Keyword IS NULL OR pxp.MoTa LIKE CONCAT('%', @Keyword, '%') OR tv.HoTen LIKE CONCAT('%', @Keyword, '%') OR pxp.Id LIKE CONCAT('%', @Keyword, '%'))
                        ORDER BY pxp.Id
                        LIMIT @Offset, @Limit;";

                    var phieuXuPhats = connection.Query<PhieuXuPhatDetailDTO>(sql, new
                    {
                        TrangThai = trangThai?.ToString(),
                        FromDate = fromDate,
                        ToDate = toDate,
                        Keyword = keyword,
                        Offset = (page - 1) * limit,
                        Limit = limit
                    }).ToList();

                    return new PhieuXuPhatPagingResponse
                    {
                        Items = phieuXuPhats,
                        TotalItems = totalItems,
                        Page = page,
                        Limit = limit
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving paged list of violation tickets", ex);
                }
            }
        }

        public PhieuXuPhatDetailDTO? GetById(uint id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"
                        SELECT pxp.Id, pxp.TrangThai, pxp.NgayViPham, pxp.MoTa,
                               pxp.ThoiHanXuPhat, pxp.MucPhat, pxp.IdThanhVien,
                               tv.HoTen AS TenThanhVien
                        FROM PhieuXuPhat pxp
                        INNER JOIN ThanhVien tv ON pxp.IdThanhVien = tv.Id
                        WHERE pxp.Id = @Id AND pxp.TrangThai != 'DAXOA';";
                    return connection.QueryFirstOrDefault<PhieuXuPhatDetailDTO>(sql, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving violation ticket by ID", ex);
                }
            }
        }

        public uint Add(PhieuXuPhatCreateDTO phieuXuPhatCreateDTO)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"
                        INSERT INTO PhieuXuPhat (TrangThai, NgayViPham, MoTa, ThoiHanXuPhat, MucPhat, IdThanhVien)
                        VALUES (@TrangThai, @NgayViPham, @MoTa, @ThoiHanXuPhat, @MucPhat, @IdThanhVien);
                        SELECT LAST_INSERT_ID();";
                    var parameters = new
                    {
                        TrangThai = phieuXuPhatCreateDTO.TrangThai.ToString(),
                        NgayViPham = phieuXuPhatCreateDTO.NgayViPham,
                        MoTa = phieuXuPhatCreateDTO.MoTa,
                        ThoiHanXuPhat = phieuXuPhatCreateDTO.ThoiHanXuPhat,
                        MucPhat = phieuXuPhatCreateDTO.MucPhat,
                        IdThanhVien = phieuXuPhatCreateDTO.IdThanhVien
                    };
                    return connection.ExecuteScalar<uint>(sql, parameters);
                }
                catch (MySqlException ex) when (ex.Number == 1452) // Lỗi khóa ngoại
                {
                    throw new Exception("Invalid ThanhVien ID: The specified member does not exist", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding violation ticket: {ex.Message}", ex);
                }
            }
        }

        public bool Update(uint id, PhieuXuPhatUpdateDTO phieuXuPhatUpdateDTO)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Kiểm tra xem phiếu có tồn tại và chưa bị xóa không
                    string checkSql = "SELECT COUNT(*) FROM PhieuXuPhat WHERE Id = @Id AND TrangThai != 'DAXOA';";
                    int count = connection.ExecuteScalar<int>(checkSql, new { Id = id });
                    if (count == 0)
                    {
                        return false;
                    }

                    // Xây dựng câu lệnh UPDATE động
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);
                    var setClauses = new List<string>();

                    if (phieuXuPhatUpdateDTO.TrangThai.HasValue)
                    {
                        setClauses.Add("TrangThai = @TrangThai");
                        parameters.Add("@TrangThai", phieuXuPhatUpdateDTO.TrangThai.Value.ToString());
                    }
                    if (phieuXuPhatUpdateDTO.NgayViPham.HasValue)
                    {
                        setClauses.Add("NgayViPham = @NgayViPham");
                        parameters.Add("@NgayViPham", phieuXuPhatUpdateDTO.NgayViPham.Value);
                    }
                    if (!string.IsNullOrEmpty(phieuXuPhatUpdateDTO.MoTa))
                    {
                        setClauses.Add("MoTa = @MoTa");
                        parameters.Add("@MoTa", phieuXuPhatUpdateDTO.MoTa);
                    }
                    if (phieuXuPhatUpdateDTO.ThoiHanXuPhat.HasValue)
                    {
                        setClauses.Add("ThoiHanXuPhat = @ThoiHanXuPhat");
                        parameters.Add("@ThoiHanXuPhat", phieuXuPhatUpdateDTO.ThoiHanXuPhat.Value);
                    }
                    else if (phieuXuPhatUpdateDTO.ThoiHanXuPhat == null)
                    {
                        setClauses.Add("ThoiHanXuPhat = NULL");
                    }
                    if (phieuXuPhatUpdateDTO.MucPhat.HasValue)
                    {
                        setClauses.Add("MucPhat = @MucPhat");
                        parameters.Add("@MucPhat", phieuXuPhatUpdateDTO.MucPhat.Value);
                    }
                    else if (phieuXuPhatUpdateDTO.MucPhat == null)
                    {
                        setClauses.Add("MucPhat = NULL");
                    }
                    if (phieuXuPhatUpdateDTO.IdThanhVien.HasValue)
                    {
                        setClauses.Add("IdThanhVien = @IdThanhVien");
                        parameters.Add("@IdThanhVien", phieuXuPhatUpdateDTO.IdThanhVien.Value);
                    }

                    if (setClauses.Count == 0)
                    {
                        return false;
                    }

                    string sql = $"UPDATE PhieuXuPhat SET {string.Join(", ", setClauses)} WHERE Id = @Id;";
                    int rowsAffected = connection.Execute(sql, parameters);
                    return rowsAffected > 0;
                }
                catch (MySqlException ex) when (ex.Number == 1452) // Lỗi khóa ngoại
                {
                    throw new Exception("Invalid ThanhVien ID: The specified member does not exist", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating violation ticket: {ex.Message}", ex);
                }
            }
        }

        public bool Delete(uint id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"
                        UPDATE PhieuXuPhat
                        SET TrangThai = 'DAXOA'
                        WHERE Id = @Id AND TrangThai != 'DAXOA';";
                    int rowsAffected = connection.Execute(sql, new { Id = id });
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting violation ticket: {ex.Message}", ex);
                }
            }
        }
    }

    public class PhieuXuPhatPagingResponse
    {
        public List<PhieuXuPhatDetailDTO> Items { get; set; }
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}