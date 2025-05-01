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

        public List<ChiTietPhieuMuonDetailDTO> GetAllByPhieuMuonId(int idPhieuMuon)
        {
            var list = new List<ChiTietPhieuMuonDetailDTO>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                    SELECT 
                        c.IdPhieuMuon,
                        c.IdDauThietBi,
                        d.Ten AS TenDauThietBi,
                        c.TrangThai,
                        c.ThoiGianMuon,
                        c.ThoiGianTra
                    FROM ChiTietPhieuMuon c
                    LEFT JOIN DauThietBi d ON d.Id = c.IdDauThietBi
                    WHERE c.IdPhieuMuon = @IdPhieuMuon";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuMuon", idPhieuMuon);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var dto = new ChiTietPhieuMuonDetailDTO
                {
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    IdDauThietBi = reader.GetInt32("IdDauThietBi"),
                    TenDauThietBi = reader.IsDBNull(reader.GetOrdinal("TenDauThietBi"))
                                    ? "(Không có tên)"
                                    : reader.GetString("TenDauThietBi"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiChiTietPhieuMuonEnum.DATHATLAC
                                : Enum.TryParse<TrangThaiChiTietPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiChiTietPhieuMuonEnum.DATHATLAC,
                    ThoiGianMuon = reader.IsDBNull(reader.GetOrdinal("ThoiGianMuon"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime("ThoiGianMuon"),
                    ThoiGianTra = reader.IsDBNull(reader.GetOrdinal("ThoiGianTra"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime("ThoiGianTra")
                };

                list.Add(dto);
            }

            return list;
        }

        public ChiTietPhieuMuonDetailDTO? GetByPhieuMuonIdAndDauThietBiId(int idPhieuMuon, int idDauThietBi)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = @"
                SELECT 
                    c.IdPhieuMuon,
                    c.IdDauThietBi,
                    d.Ten AS TenDauThietBi,
                    c.ThoiGianMuon,
                    c.ThoiGianTra,
                    c.TrangThai
                FROM ChiTietPhieuMuon c
                LEFT JOIN DauThietBi d ON d.Id = c.IdDauThietBi
                WHERE c.IdPhieuMuon = @IdPhieuMuon AND c.IdDauThietBi = @IdDauThietBi";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPhieuMuon", idPhieuMuon);
            command.Parameters.AddWithValue("@IdDauThietBi", idDauThietBi);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new ChiTietPhieuMuonDetailDTO
                {
                    IdPhieuMuon = reader.GetInt32("IdPhieuMuon"),
                    IdDauThietBi = reader.GetInt32("IdDauThietBi"),
                    TenDauThietBi = reader.IsDBNull(reader.GetOrdinal("TenDauThietBi"))
                                    ? "(Không có tên)"
                                    : reader.GetString("TenDauThietBi"),
                    ThoiGianMuon = reader.IsDBNull(reader.GetOrdinal("ThoiGianMuon"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime("ThoiGianMuon"),
                    ThoiGianTra = reader.IsDBNull(reader.GetOrdinal("ThoiGianTra"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime("ThoiGianTra"),
                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai"))
                                ? TrangThaiChiTietPhieuMuonEnum.DATHATLAC
                                : Enum.TryParse<TrangThaiChiTietPhieuMuonEnum>(reader.GetString("TrangThai"), true, out var result)
                                    ? result
                                    : TrangThaiChiTietPhieuMuonEnum.DATHATLAC
                };
            }

            return null;
        }

        public bool Add(List<ChiTietPhieuMuonCreateDTO> entities)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                string query = @"INSERT INTO ChiTietPhieuMuon 
                         (IdPhieuMuon, IdDauThietBi, ThoiGianMuon, ThoiGianTra, TrangThai) 
                         VALUES (@IdPhieuMuon, @IdDauThietBi, @ThoiGianMuon, @TrangThai)";

                foreach (var entity in entities)
                {
                    using var command = new MySqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@IdPhieuMuon", entity.IdPhieuMuon);
                    command.Parameters.AddWithValue("@IdDauThietBi", entity.IdDauThietBi);
                    command.Parameters.AddWithValue("@ThoiGianMuon", entity.ThoiGianMuon);
                    command.Parameters.AddWithValue("@TrangThai", entity.TrangThai.ToString());

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool Update(List<ChiTietPhieuMuonUpdateDTO> entities)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            if(IsPhieuMuonEditable(connection, entities[0].IdPhieuMuon)){
                return false;
            }

            using var transaction = connection.BeginTransaction();

            try
            {
                foreach (var entity in entities)
                {
                    string query = @"UPDATE ChiTietPhieuMuon 
                             SET ThoiGianTra = @ThoiGianTra, 
                                 TrangThai = @TrangThai 
                             WHERE IdPhieuMuon = @IdPhieuMuon AND IdDauThietBi = @IdDauThietBi";

                    using var command = new MySqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@IdPhieuMuon", entity.IdPhieuMuon);
                    command.Parameters.AddWithValue("@IdDauThietBi", entity.IdDauThietBi);
                    command.Parameters.AddWithValue("@ThoiGianTra", entity.ThoiGianTra ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TrangThai", entity.TrangThai.ToString());

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        private bool IsPhieuMuonEditable(MySqlConnection connection, int idPhieuMuon)
        {
            string query = @"
                SELECT TrangThai 
                FROM TrangThaiPhieuMuon 
                WHERE IdPhieuMuon = @IdPhieuMuon 
                ORDER BY ThoiGianCapNhat DESC 
                LIMIT 1";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@IdPhieuMuon", idPhieuMuon);

            var result = cmd.ExecuteScalar();
            if (result == null) return false;

            var trangThaiStr = result.ToString();
            return trangThaiStr == TrangThaiPhieuMuonEnum.HUY.ToString() ||
                   trangThaiStr == TrangThaiPhieuMuonEnum.DATCHO.ToString();
        }

        public bool Delete(List<ChiTietPhieuMuonDeleteDTO> entities)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            if(IsPhieuMuonEditable(connection, entities[0].IdPhieuMuon)){
                return false;
            }

            using var transaction = connection.BeginTransaction();

            try
            {
                foreach (var entity in entities)
                {
                    string query = "DELETE FROM ChiTietPhieuMuon WHERE IdPhieuMuon = @IdPhieuMuon AND IdDauThietBi = @IdDauThietBi";

                    using var command = new MySqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@IdPhieuMuon", entity.IdPhieuMuon);
                    command.Parameters.AddWithValue("@IdDauThietBi", entity.IdDauThietBi);

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}