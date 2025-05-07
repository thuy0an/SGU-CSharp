using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.Models.PhieuMuon;
using System;
using System.Collections.Generic;

namespace sgu_c_sharf_backend.Repositories
{
    public class PhieuMuonRepository
    {
        private readonly string _connectionString;

        public PhieuMuonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public PhieuMuonDetailDTO GetById(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                    SELECT 
                        p.Id AS Id,
                        p.IdThanhVien AS IdThanhVien,
                        tv.HoTen AS TenThanhVien,
                        p.NgayTao AS NgayTao, 
                        tt.TrangThai AS TrangThai
                    FROM PhieuMuon p
                    LEFT JOIN TrangThaiPhieuMuon tt ON tt.Id = (
                        SELECT ttp.Id 
                        FROM TrangThaiPhieuMuon ttp
                        WHERE ttp.IdPhieuMuon = p.Id
                        ORDER BY ttp.ThoiGianCapNhat DESC
                        LIMIT 1
                    )
                    LEFT JOIN ThanhVien tv ON tv.Id = p.IdThanhVien
                    WHERE p.Id = @Id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new PhieuMuonDetailDTO
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    TenThanhVien = reader.GetString("TenThanhVien"),
                    NgayTao = reader.GetDateTime("NgayTao"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiPhieuMuonEnum.HUY
                                : Enum.TryParse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiPhieuMuonEnum.HUY
                };
            }

            return null;
        }

        public List<PhieuMuonDetailDTO> GetAllByAccountId(int accountId)
        {
            var list = new List<PhieuMuonDetailDTO>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                        SELECT 
                            p.Id AS Id,
                            p.IdThanhVien AS IdThanhVien,
                            tv.HoTen AS TenThanhVien,
                            p.NgayTao AS NgayTao, 
                            t.TrangThai AS TrangThai
                        FROM PhieuMuon p
                        LEFT JOIN (
                            SELECT IdPhieuMuon, TrangThai
                            FROM TrangThaiPhieuMuon t1
                            WHERE ThoiGianCapNhat = (
                                SELECT MAX(ThoiGianCapNhat)
                                FROM TrangThaiPhieuMuon t2
                                WHERE t2.IdPhieuMuon = t1.IdPhieuMuon
                            )
                        ) t ON p.Id = t.IdPhieuMuon
                        LEFT JOIN ThanhVien tv ON tv.Id = p.IdThanhVien
                        WHERE p.`IdThanhVien` =  @IdThanhVien;";

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@IdThanhVien", accountId);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new PhieuMuonDetailDTO
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    TenThanhVien = reader.GetString("TenThanhVien"),
                    NgayTao = reader.GetDateTime("NgayTao"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiPhieuMuonEnum.HUY
                                : Enum.TryParse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiPhieuMuonEnum.HUY
                });
            }

            return list;
        }

        public List<PhieuMuonDetailDTO> GetAll()
        {
            var list = new List<PhieuMuonDetailDTO>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                        SELECT 
                            p.Id AS Id,
                            p.IdThanhVien AS IdThanhVien,
                            tv.HoTen AS TenThanhVien,
                            p.NgayTao AS NgayTao, 
                            t.TrangThai AS TrangThai
                        FROM PhieuMuon p
                        LEFT JOIN (
                            SELECT IdPhieuMuon, TrangThai
                            FROM TrangThaiPhieuMuon t1
                            WHERE ThoiGianCapNhat = (
                                SELECT MAX(ThoiGianCapNhat)
                                FROM TrangThaiPhieuMuon t2
                                WHERE t2.IdPhieuMuon = t1.IdPhieuMuon
                            )
                        ) t ON p.Id = t.IdPhieuMuon
                        LEFT JOIN ThanhVien tv ON tv.Id = p.IdThanhVien;";

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new PhieuMuonDetailDTO
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    TenThanhVien = reader.GetString("TenThanhVien"),
                    NgayTao = reader.GetDateTime("NgayTao"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiPhieuMuonEnum.HUY
                                : Enum.TryParse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiPhieuMuonEnum.HUY
                });
            }

            return list;
        }


        private int GetTotalCount(DateTime? fromDate, DateTime? toDate, TrangThaiPhieuMuonEnum? trangThai, string? keyword)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                        SELECT COUNT(*) 
                        FROM PhieuMuon p
                        LEFT JOIN (
                            SELECT IdPhieuMuon, TrangThai
                            FROM TrangThaiPhieuMuon t1
                            WHERE ThoiGianCapNhat = (
                                SELECT MAX(ThoiGianCapNhat)
                                FROM TrangThaiPhieuMuon t2
                                WHERE t2.IdPhieuMuon = t1.IdPhieuMuon
                            )
                        ) t ON p.Id = t.IdPhieuMuon
                        LEFT JOIN ThanhVien tv ON tv.Id = p.IdThanhVien
                        WHERE 1=1
                    ";

            if (fromDate.HasValue)
                query += " AND p.NgayTao >= @FromDate ";

            if (toDate.HasValue)
                query += " AND p.NgayTao <= @ToDate ";

            if (trangThai.HasValue)
                query += " AND t.TrangThai = @TrangThai ";

            if (!string.IsNullOrWhiteSpace(keyword))
                query += " AND (tv.HoTen LIKE @Keyword OR p.Id LIKE @Keyword OR p.IdThanhVien LIKE @Keyword) ";

            using var command = new MySqlCommand(query, connection);

            if (fromDate.HasValue)
                command.Parameters.AddWithValue("@FromDate", fromDate.Value);
            if (toDate.HasValue)
                command.Parameters.AddWithValue("@ToDate", toDate.Value);
            if (trangThai.HasValue)
                command.Parameters.AddWithValue("@TrangThai", trangThai.Value.ToString());
            if (!string.IsNullOrWhiteSpace(keyword))
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

            return Convert.ToInt32(command.ExecuteScalar());
        }


        public PhieuMuonPagingResponse GetAllPaging(int page, int limit, DateTime? fromDate, DateTime? toDate, TrangThaiPhieuMuonEnum? trangThai, string? keyword = null)
        {
            var list = new List<PhieuMuonDetailDTO>();
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            int offset = (page - 1) * limit;

            string query = @"
                        SELECT 
                            p.Id AS Id,
                            p.IdThanhVien AS IdThanhVien,
                            tv.HoTen AS TenThanhVien,
                            p.NgayTao AS NgayTao, 
                            t.TrangThai AS TrangThai
                        FROM PhieuMuon p
                        LEFT JOIN (
                            SELECT IdPhieuMuon, TrangThai
                            FROM TrangThaiPhieuMuon t1
                            WHERE ThoiGianCapNhat = (
                                SELECT MAX(ThoiGianCapNhat)
                                FROM TrangThaiPhieuMuon t2
                                WHERE t2.IdPhieuMuon = t1.IdPhieuMuon
                            )
                        ) t ON p.Id = t.IdPhieuMuon
                        LEFT JOIN ThanhVien tv ON tv.Id = p.IdThanhVien
                        WHERE 1=1
                    ";

            if (fromDate.HasValue)
                query += " AND p.NgayTao >= @FromDate ";

            if (toDate.HasValue)
                query += " AND p.NgayTao <= @ToDate ";

            if (trangThai.HasValue)
                query += " AND t.TrangThai = @TrangThai ";

            if (!string.IsNullOrWhiteSpace(keyword))
                query += " AND (tv.HoTen LIKE @Keyword OR p.Id LIKE @Keyword OR p.IdThanhVien LIKE @Keyword) ";

            query += " ORDER BY p.Id DESC LIMIT @Limit OFFSET @Offset;";

            using var command = new MySqlCommand(query, connection);

            if (fromDate.HasValue)
                command.Parameters.AddWithValue("@FromDate", fromDate.Value);
            if (toDate.HasValue)
                command.Parameters.AddWithValue("@ToDate", toDate.Value);
            if (trangThai.HasValue)
                command.Parameters.AddWithValue("@TrangThai", trangThai.Value.ToString());
            if (!string.IsNullOrWhiteSpace(keyword))
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

            command.Parameters.AddWithValue("@Limit", limit);
            command.Parameters.AddWithValue("@Offset", offset);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PhieuMuonDetailDTO
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    TenThanhVien = reader.GetString("TenThanhVien"),
                    NgayTao = reader.GetDateTime("NgayTao"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiPhieuMuonEnum.HUY
                                : Enum.TryParse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiPhieuMuonEnum.HUY
                });
            }

            // Cập nhật phần đếm tổng cũng truyền keyword
            int totalCount = GetTotalCount(fromDate, toDate, trangThai, keyword);
            int totalPages = (int)Math.Ceiling((double)totalCount / limit);

            return new PhieuMuonPagingResponse
            {
                Items = list,
                CurrentPage = page,
                TotalPages = totalPages
            };
        }

        public int Add(PhieuMuonCreateDTO entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                INSERT INTO PhieuMuon (IdThanhVien, NgayTao)
                VALUES (@IdThanhVien, @NgayTao);
                SELECT LAST_INSERT_ID();";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdThanhVien", entity.IdThanhVien);
            command.Parameters.AddWithValue("@NgayTao", entity.NgayTao);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public bool Update(PhieuMuonUpdateDTO entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
            UPDATE PhieuMuon
            SET IdThanhVien = @IdThanhVien
            WHERE Id = @Id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@IdThanhVien", entity.IdThanhVien);

            return command.ExecuteNonQuery() > 0;
        }
        public List<PhieuMuonChiTietDTO> GetPhieuMuonChiTietById(int idPhieuMuon)
        {
            var list = new List<PhieuMuonChiTietDTO>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"
SELECT
    pm.Id AS PhieuMuonId,
    pm.NgayTao AS NgayTaoPhieuMuon,
    
    tv.Id AS ThanhVienId,
    tv.HoTen AS TenThanhVien,
    tv.Email,
    tv.SoDienThoai,
    
    tpm.Id AS TrangThaiPhieuMuonId,
    tpm.TrangThai AS TrangThaiPhieuMuon,
    tpm.ThoiGianCapNhat AS ThoiGianCapNhatTrangThai,
    
    ctpm.IdDauThietBi,
    ctpm.ThoiGianMuon,
    ctpm.ThoiGianTra,
    ctpm.TrangThai AS TrangThaiChiTietPhieuMuon,
    
    dtb.TrangThai AS TrangThaiDauThietBi,
    dtb.ThoiGianMua,
    
    tb.TenThietBi,
    tb.AnhMinhHoa
FROM PhieuMuon pm
INNER JOIN ThanhVien tv ON pm.IdThanhVien = tv.Id
LEFT JOIN TrangThaiPhieuMuon tpm ON pm.Id = tpm.IdPhieuMuon
LEFT JOIN ChiTietPhieuMuon ctpm ON pm.Id = ctpm.IdPhieuMuon
LEFT JOIN DauThietBi dtb ON ctpm.IdDauThietBi = dtb.Id
LEFT JOIN ThietBi tb ON dtb.IdThietBi = tb.Id
WHERE pm.Id = @IdPhieuMuon;
";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPhieuMuon", idPhieuMuon);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new PhieuMuonChiTietDTO
                            {
                                PhieuMuonId = reader.GetInt32("PhieuMuonId"),
                                NgayTaoPhieuMuon = reader.GetDateTime("NgayTaoPhieuMuon"),

                                ThanhVienId = reader.GetInt32("ThanhVienId"),
                                TenThanhVien = reader.GetString("TenThanhVien"),
                                Email = reader.GetString("Email"),
                                SoDienThoai = reader.GetString("SoDienThoai"),

                                TrangThaiPhieuMuonId = reader.IsDBNull(reader.GetOrdinal("TrangThaiPhieuMuonId")) ? (int?)null : reader.GetInt32("TrangThaiPhieuMuonId"),
                                TrangThaiPhieuMuon = reader.IsDBNull(reader.GetOrdinal("TrangThaiPhieuMuon")) ? null : reader.GetString("TrangThaiPhieuMuon"),
                                ThoiGianCapNhatTrangThai = reader.IsDBNull(reader.GetOrdinal("ThoiGianCapNhatTrangThai")) ? (DateTime?)null : reader.GetDateTime("ThoiGianCapNhatTrangThai"),

                                IdDauThietBi = reader.IsDBNull(reader.GetOrdinal("IdDauThietBi")) ? (int?)null : reader.GetInt32("IdDauThietBi"),
                                ThoiGianMuon = reader.IsDBNull(reader.GetOrdinal("ThoiGianMuon")) ? (DateTime?)null : reader.GetDateTime("ThoiGianMuon"),
                                ThoiGianTra = reader.IsDBNull(reader.GetOrdinal("ThoiGianTra")) ? (DateTime?)null : reader.GetDateTime("ThoiGianTra"),
                                TrangThaiChiTietPhieuMuon = reader.IsDBNull(reader.GetOrdinal("TrangThaiChiTietPhieuMuon")) ? null : reader.GetString("TrangThaiChiTietPhieuMuon"),

                                TrangThaiDauThietBi = reader.IsDBNull(reader.GetOrdinal("TrangThaiDauThietBi")) ? null : reader.GetString("TrangThaiDauThietBi"),
                                ThoiGianMua = reader.IsDBNull(reader.GetOrdinal("ThoiGianMua")) ? (DateTime?)null : reader.GetDateTime("ThoiGianMua"),

                                TenThietBi = reader.IsDBNull(reader.GetOrdinal("TenThietBi")) ? null : reader.GetString("TenThietBi"),
                                AnhMinhHoa = reader.IsDBNull(reader.GetOrdinal("AnhMinhHoa")) ? null : reader.GetString("AnhMinhHoa")
                            };

                            list.Add(dto);
                        }
                    }
                }
            }

            return list;
        }

    }

}
