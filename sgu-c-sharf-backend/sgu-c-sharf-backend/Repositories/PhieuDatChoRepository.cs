using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgu_c_sharf_backend.Models.PhieuDatCho;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.ApiResponse;
namespace sgu_c_sharf_backend.Repositories

{
    public class PhieuDatChoRepository
    {
        private readonly string _connectionString;

        public PhieuDatChoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); // Lấy từ config
        }

        public List<PhieuDatCho> GetAllPhieuDatChoNoPaging(){
            List<PhieuDatCho> listPDC = new List<PhieuDatCho>();
            using (MySqlConnection connect = new MySqlConnection(_connectionString)){
                connect.Open();
                string sql = "Select Id, IdThanhVien, TrangThai, ThoigianDat, ThoiGianLapPhieu From phieudatcho";
                MySqlCommand command = new MySqlCommand(sql, connect);
                using (MySqlDataReader reader = command.ExecuteReader()){
                    while (reader.Read()){
                        listPDC.Add(new PhieuDatCho{
                            Id = reader.GetInt32("Id"),
                            IdThanhVien = reader.GetInt32("IdThanhVien"),
                            TrangThai = Enum.Parse<TrangThaiPhieuDatChoEnum>(reader.GetString("TrangThai")),
                            ThoiGianDat = reader.GetDateTime("ThoiGianDat"),
                            ThoiGianLapPhieu = reader.GetDateTime("ThoiGianLapPhieu")
                        });
                    }
                }

            }
            return listPDC;
        }

        public PhieuDatCho? GetById(int id){
            PhieuDatCho cur = new PhieuDatCho();
            using (MySqlConnection connect = new MySqlConnection(_connectionString)){
                connect.Open();
                string sql = "Select Id, IdThanhVien, TrangThai, ThoigianDat, ThoiGianLapPhieu From phieudatcho Where Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Id", id);
                using (MySqlDataReader reader = command.ExecuteReader()){
                    if (reader.Read()){
                        cur.Id = reader.GetInt32("Id");
                        cur.IdThanhVien = reader.GetInt32("IdThanhVien");
                        cur.TrangThai = Enum.Parse<TrangThaiPhieuDatChoEnum>(reader.GetString("TrangThai"));
                        cur.ThoiGianDat = reader.GetDateTime("ThoiGianDat");
                        cur.ThoiGianLapPhieu = reader.GetDateTime("ThoiGianLapPhieu");
                    }
                }
            }
            return cur.Id != 0 ? cur : null;
        }

        public PhieuDatCho? Create(PhieuDatCho pdc){
            using (MySqlConnection connect = new MySqlConnection(_connectionString)){
                connect.Open();
                string sql = "Insert into phieudatcho(IdThanhVien, TrangThai, ThoiGianDat, ThoiGianLapPhieu) Values(@IdThanhVien, @TrangThai, @ThoiGianDat, @ThoiGianLapPhieu); Select LAST_INSERT_ID();";
                MySqlCommand command = new MySqlCommand(sql, connect);
                command.Parameters.AddWithValue("@IdThanhVien", pdc.IdThanhVien);
                command.Parameters.AddWithValue("@TrangThai", pdc.TrangThai.ToString());
        command.Parameters.AddWithValue("@ThoiGianDat", pdc.ThoiGianDat.ToString("yyyy-MM-ddTHH:mm:ss"));
        command.Parameters.AddWithValue("@ThoiGianLapPhieu", pdc.ThoiGianLapPhieu.ToString("yyyy-MM-ddTHH:mm:ss"));
                int newId = Convert.ToInt32(command.ExecuteScalar());
                pdc.Id = newId;
                return pdc;
            }
        }
        public PhieuDatCho? Update(PhieuDatCho pdc){
            using (MySqlConnection connect = new MySqlConnection(_connectionString)){
                connect.Open();
                string sql = "Update phieudatcho Set TrangThai = @TrangThai Where Id= @Id";
                MySqlCommand command = new MySqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Id", pdc.Id);
                command.Parameters.AddWithValue("@TrangThai", pdc.TrangThai.ToString());
                return command.ExecuteNonQuery() > 0 ? pdc : null;
            }
        }
        public bool Delete(int id){
            using (MySqlConnection connect = new MySqlConnection(_connectionString)){
                connect.Open();
                string sql = "Update phieudatcho Set TrangThai = @TrangThai  Where Id= @Id";
                MySqlCommand command = new MySqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@TrangThai", "HUY");
                return command.ExecuteNonQuery()>0? true: false;
            }
        }
    }
}