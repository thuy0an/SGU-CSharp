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

        public int GetTotalCount(DateTime? fromDate, DateTime? toDate, TrangThaiPhieuMuonEnum? trangThai)
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
                WHERE 1=1
            ";

            if (fromDate.HasValue)
                query += " AND p.NgayTao >= @FromDate ";

            if (toDate.HasValue)
                query += " AND p.NgayTao <= @ToDate ";

            if (trangThai.HasValue)
                query += " AND t.TrangThai = @TrangThai ";

            using var command = new MySqlCommand(query, connection);

            if (fromDate.HasValue)
                command.Parameters.AddWithValue("@FromDate", fromDate.Value);

            if (toDate.HasValue)
                command.Parameters.AddWithValue("@ToDate", toDate.Value);

            if (trangThai.HasValue)
                command.Parameters.AddWithValue("@TrangThai", trangThai.Value.ToString());

            return Convert.ToInt32(command.ExecuteScalar());
        }


        public (List<PhieuMuonDetailDTO> items, int currentPage, int totalPages) GetAllPaging(int page, int limit, DateTime? fromDate, DateTime? toDate, TrangThaiPhieuMuonEnum? trangThai)
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

            query += " ORDER BY p.Id DESC LIMIT @Limit OFFSET @Offset;";

            using var command = new MySqlCommand(query, connection);

            if (fromDate.HasValue)
                command.Parameters.AddWithValue("@FromDate", fromDate.Value);

            if (toDate.HasValue)
                command.Parameters.AddWithValue("@ToDate", toDate.Value);

            if (trangThai.HasValue)
                command.Parameters.AddWithValue("@TrangThai", trangThai.Value.ToString());

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

            // Gọi hàm đếm tổng
            int totalCount = GetTotalCount(fromDate, toDate, trangThai);
            int totalPages = (int)Math.Ceiling((double)totalCount / limit);

            return (list, page, totalPages);
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

    }
}
