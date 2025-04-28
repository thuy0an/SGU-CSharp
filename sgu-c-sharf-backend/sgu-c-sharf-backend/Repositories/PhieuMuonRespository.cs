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

        public PhieuMuon? GetById(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                SELECT 
                    p.Id, p.IdThanhVien, p.NgayTao, 
                    t.TrangThai AS TrangThaiMoiNhat
                FROM PhieuMuon p
                LEFT JOIN (
                    SELECT IdPhieuMuon, TrangThai
                    FROM TrangThaiPhieuMuon
                    WHERE ThoiGianCapNhat = (SELECT MAX(ThoiGianCapNhat) FROM TrangThaiPhieuMuon WHERE IdPhieuMuon = p.Id)
                ) t ON p.Id = t.IdPhieuMuon
                WHERE p.Id = @Id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new PhieuMuon
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    NgayTao = reader.GetDateTime("NgayTao"),
                    TrangThaiMoiNhat = reader.IsDBNull(reader.GetOrdinal("TrangThaiMoiNhat")) ? null : reader.GetString("TrangThaiMoiNhat")
                };
            }

            return null;
        }

        public List<PhieuMuon> GetAll()
        {
            var list = new List<PhieuMuon>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                SELECT 
                    p.Id, p.IdThanhVien, p.NgayTao, 
                    t.TrangThai AS TrangThaiMoiNhat
                FROM PhieuMuon p
                LEFT JOIN (
                    SELECT IdPhieuMuon, TrangThai
                    FROM TrangThaiPhieuMuon
                    WHERE ThoiGianCapNhat = (SELECT MAX(ThoiGianCapNhat) FROM TrangThaiPhieuMuon WHERE IdPhieuMuon = p.Id)
                ) t ON p.Id = t.IdPhieuMuon";

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new PhieuMuon
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    NgayTao = reader.GetDateTime("NgayTao"),
                    TrangThaiMoiNhat = reader.IsDBNull(reader.GetOrdinal("TrangThaiMoiNhat")) ? null : reader.GetString("TrangThaiMoiNhat")
                });
            }

            return list;
        }

        public List<PhieuMuon> GetAllPaging(int page, int limit)
        {
            var list = new List<PhieuMuon>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            int offset = (page - 1) * limit;

            string query = @"
                SELECT 
                    p.Id, p.IdThanhVien, p.NgayTao, 
                    t.TrangThai AS TrangThaiMoiNhat
                FROM PhieuMuon p
                LEFT JOIN (
                    SELECT IdPhieuMuon, TrangThai
                    FROM TrangThaiPhieuMuon
                    WHERE ThoiGianCapNhat = (SELECT MAX(ThoiGianCapNhat) FROM TrangThaiPhieuMuon WHERE IdPhieuMuon = p.Id)
                ) t ON p.Id = t.IdPhieuMuon
                LIMIT @Limit OFFSET @Offset";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Limit", limit);
            command.Parameters.AddWithValue("@Offset", offset);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new PhieuMuon
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    NgayTao = reader.GetDateTime("NgayTao"),
                    TrangThaiMoiNhat = reader.IsDBNull(reader.GetOrdinal("TrangThaiMoiNhat")) ? null : reader.GetString("TrangThaiMoiNhat")
                });
            }

            return list;
        }

        public int Add(PhieuMuon entity)
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

        public int Update(PhieuMuon entity)
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

            return Convert.ToInt32(command.ExecuteNonQuery());
        }
    }
}
