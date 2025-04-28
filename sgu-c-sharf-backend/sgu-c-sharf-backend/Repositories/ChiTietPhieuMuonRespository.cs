using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Models.PhieuMuon;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace sgu_c_sharf_backend.Repositories
{
    public class ChiTietPhieuMuonRepository
    {
        private readonly string _connectionString;

        public ChiTietPhieuMuonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<ChiTietPhieuMuon?> GetById(int id)
        {
            List<ChiTietPhieuMuon?> chiTietPhieuMuons = new List<ChiTietPhieuMuon?>();
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT IdPhieuMuon, IdDauThietBi, ThoiGianMuon, ThoiGianTra, TrangThai FROM ChiTietPhieuMuon WHERE IdPhieuMuon = @IdPhieuMuon";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuMuon", id);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var chiTiet = new ChiTietPhieuMuon
                {
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    IdDauThietBi = reader.GetInt32("IdDauThietBi"),
                    ThoiGianMuon = reader.GetDateTime("ThoiGianMuon"),
                    ThoiGianTra = reader.IsDBNull("ThoiGianTra") ? null : reader.GetDateTime("ThoiGianTra"),
                    TrangThai = Enum.Parse<TrangThaiChiTietPhieuMuonEnum>(reader.GetString("TrangThai"))
                };

                chiTietPhieuMuons.Add(chiTiet);
            }

            return chiTietPhieuMuons;
        }

        public ChiTietPhieuMuon? GetByIdsAsync(int idPhieuMuon, int idDauThietBi)
        {
            ChiTietPhieuMuon? chiTiet = null;
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT IdPhieuMuon, IdDauThietBi, ThoiGianMuon, ThoiGianTra, TrangThai FROM ChiTietPhieuMuon WHERE IdPhieuMuon = @IdPhieuMuon AND IdDauThietBi = @IdDauThietBi";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuMuon", idPhieuMuon);
            command.Parameters.AddWithValue("@IdDauThietBi", idDauThietBi);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                chiTiet = new ChiTietPhieuMuon
                {
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    IdDauThietBi = reader.GetInt32("IdDauThietBi"),
                    ThoiGianMuon = reader.GetDateTime("ThoiGianMuon"),
                    ThoiGianTra = reader.IsDBNull("ThoiGianTra") ? null : reader.GetDateTime("ThoiGianTra"),
                    TrangThai = Enum.Parse<TrangThaiChiTietPhieuMuonEnum>(reader.GetString("TrangThai"))
                };
            }

            return chiTiet;
        }

        public IEnumerable<ChiTietPhieuMuon> GetAllAsync()
        {
            var chiTietPhieuMuons = new List<ChiTietPhieuMuon>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT IdPhieuMuon, IdDauThietBi, ThoiGianMuon, ThoiGianTra, TrangThai FROM ChiTietPhieuMuon";

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                chiTietPhieuMuons.Add(new ChiTietPhieuMuon
                {
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    IdDauThietBi = reader.GetInt32("IdDauThietBi"),
                    ThoiGianMuon = reader.GetDateTime("ThoiGianMuon"),
                    ThoiGianTra = reader.IsDBNull("ThoiGianTra") ? null : reader.GetDateTime("ThoiGianTra"),
                    TrangThai = Enum.Parse<TrangThaiChiTietPhieuMuonEnum>(reader.GetString("TrangThai"))
                });
            }

            return chiTietPhieuMuons;
        }

        public void AddAsync(ChiTietPhieuMuon entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO ChiTietPhieuMuon (IdPhieuMuon, IdDauThietBi, ThoiGianMuon, ThoiGianTra, TrangThai) VALUES (@IdPhieuMuon, @IdDauThietBi, @ThoiGianMuon, @ThoiGianTra, @TrangThai)";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuMuon", entity.IdPhieuMuon);
            command.Parameters.AddWithValue("@IdDauThietBi", entity.IdDauThietBi);
            command.Parameters.AddWithValue("@ThoiGianMuon", entity.ThoiGianMuon);
            command.Parameters.AddWithValue("@ThoiGianTra", entity.ThoiGianTra.HasValue ? entity.ThoiGianTra : DBNull.Value);
            command.Parameters.AddWithValue("@TrangThai", entity.TrangThai);

            command.ExecuteNonQuery();
        }

        public void UpdateAsync(ChiTietPhieuMuon entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "UPDATE ChiTietPhieuMuon SET ThoiGianMuon = @ThoiGianMuon, ThoiGianTra = @ThoiGianTra, TrangThai = @TrangThai WHERE IdPhieuMuon = @IdPhieuMuon AND IdDauThietBi = @IdDauThietBi";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuMuon", entity.IdPhieuMuon);
            command.Parameters.AddWithValue("@IdDauThietBi", entity.IdDauThietBi);
            command.Parameters.AddWithValue("@ThoiGianMuon", entity.ThoiGianMuon);
            command.Parameters.AddWithValue("@ThoiGianTra", entity.ThoiGianTra.HasValue ? entity.ThoiGianTra : DBNull.Value);
            command.Parameters.AddWithValue("@TrangThai", entity.TrangThai);

            command.ExecuteNonQuery();
        }
    }
}