using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace sgu_c_sharf_backend.Repositories
{
    public class ChiTietPhieuDatChoRepository 
    {
        private readonly string _connectionString;

        public ChiTietPhieuDatChoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public ChiTietPhieuDatCho? GetByIdAsync(int id)
        {
            throw new NotImplementedException("Không thể lấy ChiTietPhieuDatCho bằng một ID duy nhất.");
        }

        public ChiTietPhieuDatCho? GetByIdsAsync(int idPhieuDat, int idDauThietBi)
        {
            ChiTietPhieuDatCho? chiTiet = null;
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT IdPhieuDat, IdDauThietBi FROM ChiTietPhieuDatCho WHERE IdPhieuDat = @IdPhieuDat AND IdDauThietBi = @IdDauThietBi";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuDat", idPhieuDat);
            command.Parameters.AddWithValue("@IdDauThietBi", idDauThietBi);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                chiTiet = new ChiTietPhieuDatCho
                {
                    IdPhieuDat = reader.GetInt32("IdPhieuDat"),
                    IdDauThietBi = reader.GetInt32("IdDauThietBi")
                };
            }

            return chiTiet;
        }

        public IEnumerable<ChiTietPhieuDatCho> GetAllAsync()
        {
            var chiTietPhieuDatChos = new List<ChiTietPhieuDatCho>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT IdPhieuDat, IdDauThietBi FROM ChiTietPhieuDatCho";

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                chiTietPhieuDatChos.Add(new ChiTietPhieuDatCho
                {
                    IdPhieuDat = reader.GetInt32("IdPhieuDat"),
                    IdDauThietBi = reader.GetInt32("IdDauThietBi")
                });
            }

            return chiTietPhieuDatChos;
        }

        public void AddAsync(ChiTietPhieuDatCho entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO ChiTietPhieuDatCho (IdPhieuDat, IdDauThietBi) VALUES (@IdPhieuDat, @IdDauThietBi)";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuDat", entity.IdPhieuDat);
            command.Parameters.AddWithValue("@IdDauThietBi", entity.IdDauThietBi);

            command.ExecuteNonQuery();
        }

        public void UpdateAsync(ChiTietPhieuDatCho entity)
        {
            throw new NotImplementedException("Không hỗ trợ cập nhật ChiTietPhieuDatCho.");
        }

       
    }
}