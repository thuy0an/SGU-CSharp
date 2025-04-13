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
                SELECT Id, IdThanhVien, TrangThai, NgayTao
                FROM PhieuMuon
                WHERE Id = @Id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new PhieuMuon
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    TrangThai = Enum.Parse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai")),
                    NgayTao = reader.GetDateTime("NgayTao")
                };
            }

            return null;
        }

        public List<PhieuMuon> GetAll()
        {
            var list = new List<PhieuMuon>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT Id, IdThanhVien, TrangThai, NgayTao FROM PhieuMuon";

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new PhieuMuon
                {
                    Id = reader.GetInt32("Id"),
                    IdThanhVien = reader.GetInt32("IdThanhVien"),
                    TrangThai = Enum.Parse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai")),
                    NgayTao = reader.GetDateTime("NgayTao")
                });
            }

            return list;
        }

        public List<PhieuMuon> GetAllPaging(int page, int limit)
        {
            var list = new List<PhieuMuon>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            // Tính toán vị trí bắt đầu của dữ liệu cho trang hiện tại
            int offset = (page - 1) * limit;

            // Sử dụng LIMIT và OFFSET để phân trang
            string query = "SELECT Id, IdThanhVien, TrangThai, NgayTao FROM PhieuMuon LIMIT @Limit OFFSET @Offset";

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
                    TrangThai = Enum.Parse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai")),
                    NgayTao = reader.GetDateTime("NgayTao")
                });
            }

            return list;
        }

        public int Add(PhieuMuon entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                INSERT INTO PhieuMuon (IdThanhVien, TrangThai, NgayTao)
                VALUES (@IdThanhVien, @TrangThai, @NgayTao);
                SELECT LAST_INSERT_ID();";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdThanhVien", entity.IdThanhVien);
            command.Parameters.AddWithValue("@TrangThai", entity.TrangThai);
            command.Parameters.AddWithValue("@NgayTao", entity.NgayTao);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public int UpdateTrangThai(PhieuMuon phieuMuon)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "UPDATE PhieuMuon SET TrangThai = @TrangThai WHERE Id = @Id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrangThai", phieuMuon.TrangThai);
            command.Parameters.AddWithValue("@Id", phieuMuon.Id);

            return Convert.ToInt32( command.ExecuteNonQuery());
        }
    }
}
