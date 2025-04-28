using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Models.PhieuMuon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace sgu_c_sharf_backend.Repositories
{
    public class TrangThaiPhieuMuonRepository
    {
        private readonly string _connectionString;

        public TrangThaiPhieuMuonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<TrangThaiPhieuMuon>> GetByPhieuMuonIdAsync(int idPhieuMuon)
        {
            var list = new List<TrangThaiPhieuMuon>();

            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = @"SELECT Id, IdPhieuMuon, TrangThai, ThoiGianCapNhat 
                             FROM TrangThaiPhieuMuon 
                             WHERE IdPhieuMuon = @idPhieuMuon
                             ORDER BY ThoiGianCapNhat DESC";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idPhieuMuon", idPhieuMuon);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new TrangThaiPhieuMuon
                {
                    Id = reader.GetInt32("Id"),
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    TrangThai = (TrangThaiPhieuMuonEnum)reader.GetInt32("TrangThai"),
                    ThoiGianCapNhat = reader.GetDateTime("ThoiGianCapNhat")
                });
            }

            return list;
        }

        public async Task AddAsync(TrangThaiPhieuMuon entity)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = @"INSERT INTO TrangThaiPhieuMuon (IdPhieuMuon, TrangThai, ThoiGianCapNhat)
                             VALUES (@IdPhieuMuon, @TrangThai, @ThoiGianCapNhat)";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@IdPhieuMuon", entity.IdPhieuMuon);
            cmd.Parameters.AddWithValue("@TrangThai", (int)entity.TrangThai);
            cmd.Parameters.AddWithValue("@ThoiGianCapNhat", entity.ThoiGianCapNhat);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = "DELETE FROM TrangThaiPhieuMuon WHERE Id = @Id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
