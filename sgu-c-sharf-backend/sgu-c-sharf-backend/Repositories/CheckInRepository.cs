using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgu_c_sharf_backend.Models.ThanhVien;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Repositories
{
    public class CheckInRepository
    {
        private readonly string _connectionString;
        public CheckInRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); // Lấy từ config
        }

        // get All with id thanh vien
        public List<CheckIn> GetAll(int id){
            List<CheckIn> listCheck = new List<CheckIn>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString)){
               connection.Open();
                string sql = "Select Id, ThoiGianCheckIn, IdThanhVien From checkin WHERE IdThanhVien = @IdThanhVien";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@IdThanhVien", id);
                using (MySqlDataReader reader = command.ExecuteReader()){
                    while( reader.Read()){
                        listCheck.Add( new CheckIn{
                            Id = reader.GetInt32("Id"),
                            ThoiGianCheckIn = reader.GetDateTime("ThoiGianCheckIn"),
                            IdThanhVien = reader.GetInt32("IdThanhVien")
                        });
                    }
                }
            }
            return listCheck;
        }

        public List<CheckIn> GetAll(){
            List<CheckIn> listCheck = new List<CheckIn>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString)){
               connection.Open();
                string sql = "Select Id, ThoiGianCheckIn, IdThanhVien From checkin";
                MySqlCommand command = new MySqlCommand(sql, connection);
                using (MySqlDataReader reader = command.ExecuteReader()){
                    while( reader.Read()){
                        listCheck.Add( new CheckIn{
                            Id = reader.GetInt32("Id"),
                            ThoiGianCheckIn = reader.GetDateTime("ThoiGianCheckIn"),
                            IdThanhVien = reader.GetInt32("IdThanhVien")
                        });
                    }
                }
            }
            return listCheck;
        }

        // insert
        public bool Create(CheckIn checkIn){
            using (MySqlConnection connection = new MySqlConnection(_connectionString)){
                connection.Open();
                string sql= "Insert into CheckIn (ThoiGianCheckIn, IdThanhVien) values (@ThoiGianCheckIn, @IdThanhVien)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ThoiGianCheckIn", checkIn.ThoiGianCheckIn);
                command.Parameters.AddWithValue("@IdThanhVien", checkIn.IdThanhVien);
                return command.ExecuteNonQuery() > 0;
            }
        }
            
    }

}