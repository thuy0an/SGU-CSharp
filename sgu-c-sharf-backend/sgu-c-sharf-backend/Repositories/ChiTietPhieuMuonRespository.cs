using MySql.Muona.MySqlClient;
using sgu_c_sharf_backend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace sgu_c_sharf_backend.Repositories
{
    public class ChiTietPhieuMuonRepository 
    {
        private readonly string _connectionString;

        public ChiTietPhieuMuonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public ChiTietPhieuMuon? GetByIdAsync(int id)
        {
            throw new NotImplementedException("Không thể lấy ChiTietPhieuMuon bằng một ID duy nhất.");
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
                    ThoiGianMuon = reader.Get,
                    ThoiGianTra = reader,
                    TrangThai = reader
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
                    ThoiGianMuon = reader.Get,
                    ThoiGianTra = reader,
                    TrangThai = reader
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
            command.Parameters.AddWithValue("@ThoiGianMuon", entity.IdPhieuMuon);
            command.Parameters.AddWithValue("@ThoiGianTra", entity.IdDauThietBi);
            command.Parameters.AddWithValue("@TrangThai", entity.IdPhieuMuon);
            command.ExecuteNonQuery();
        }

        public void UpMuoneAsync(ChiTietPhieuMuon entity)
        {
            throw new NotImplementedException("Không hỗ trợ cập nhật ChiTietPhieuMuon.");
        }

       
    }
}