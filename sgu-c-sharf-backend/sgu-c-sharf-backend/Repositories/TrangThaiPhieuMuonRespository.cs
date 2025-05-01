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

        public TrangThaiPhieuMuonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<TrangThaiPhieuMuonDetailDTO> GetByPhieuMuonId(int idPhieuMuon)
        {
            var list = new List<TrangThaiPhieuMuonDetailDTO>();

            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string query = @"
        SELECT Id, IdPhieuMuon, TrangThai, ThoiGianCapNhat 
        FROM TrangThaiPhieuMuon 
        WHERE IdPhieuMuon = @idPhieuMuon
        ORDER BY ThoiGianCapNhat DESC";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idPhieuMuon", idPhieuMuon);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new TrangThaiPhieuMuonDetailDTO
                {
                    Id = reader.GetInt32("Id"),
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiPhieuMuonEnum.HUY
                                : Enum.TryParse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiPhieuMuonEnum.HUY,
                    ThoiGianCapNhat = reader.GetDateTime("ThoiGianCapNhat")
                });
            }

            return list;
        }

        public TrangThaiPhieuMuonDetailDTO GetTrangThaiMoiNhat(int idPhieuMuon)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string query = @"SELECT Id, IdPhieuMuon, TrangThai, ThoiGianCapNhat
                     FROM TrangThaiPhieuMuon
                     WHERE IdPhieuMuon = @idPhieuMuon
                     ORDER BY ThoiGianCapNhat DESC
                     LIMIT 1";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idPhieuMuon", idPhieuMuon);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TrangThaiPhieuMuonDetailDTO
                {
                    Id = reader.GetInt32("Id"),
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiPhieuMuonEnum.HUY
                                : Enum.TryParse<TrangThaiPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiPhieuMuonEnum.HUY,
                    ThoiGianCapNhat = reader.GetDateTime("ThoiGianCapNhat")
                };
            }

            return null;
        }

        public bool Add(TrangThaiPhieuMuonCreateDTO entity)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string query = @"INSERT INTO TrangThaiPhieuMuon (IdPhieuMuon, TrangThai, ThoiGianCapNhat)
                     VALUES (@IdPhieuMuon, @TrangThai, @ThoiGianCapNhat)";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@IdPhieuMuon", entity.IdPhieuMuon);
            cmd.Parameters.AddWithValue("@TrangThai", entity.TrangThai.ToString());
            cmd.Parameters.AddWithValue("@ThoiGianCapNhat", entity.ThoiGianCapNhat);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
