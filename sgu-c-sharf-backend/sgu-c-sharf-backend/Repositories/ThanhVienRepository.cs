using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Models;

namespace sgu_c_sharf_backend.Repositories
{
    public class ThanhVienRepository
    {
        private readonly string _connectionString;

        public ThanhVienRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<ThanhVien> GetAll()
        {
            var members = new List<ThanhVien>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM ThanhVien", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                members.Add(new ThanhVien
                {
                    Id = reader.GetInt32("Id"),
                    HoTen = reader.GetString("HoTen"),
                    NgaySinh = reader.GetDateTime("NgaySinh"),
                    Email = reader.GetString("Email"),
                    SoDienThoai = reader.GetString("SoDienThoai"),
                    TrangThai = Enum.Parse<TrangThaiEnum>(reader.GetString("TrangThai")),
                    MatKhau = reader.GetString("MatKhau"),
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy")
                });
            }

            return members;
        }

        public ThanhVien? GetById(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM ThanhVien WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new ThanhVien
                {
                    Id = reader.GetInt32("Id"),
                    HoTen = reader.GetString("HoTen"),
                    NgaySinh = reader.GetDateTime("NgaySinh"),
                    Email = reader.GetString("Email"),
                    SoDienThoai = reader.GetString("SoDienThoai"),
                    TrangThai = (TrangThaiEnum)reader.GetInt32("TrangThai"),
                    MatKhau = reader.GetString("MatKhau"),
                    ThoiGianDangKy = reader.GetDateTime("ThoiGianDangKy")
                };
            }

            return null;
        }

        public void Create(ThanhVien thanhVien)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand(
                "INSERT INTO ThanhVien (HoTen, NgaySinh, Email, SoDienThoai, TrangThai, MatKhau, ThoiGianDangKy) " +
                "VALUES (@HoTen, @NgaySinh, @Email, @SoDienThoai, @TrangThai, @MatKhau, @ThoiGianDangKy)", 
                connection);

            command.Parameters.AddWithValue("@HoTen", thanhVien.HoTen);
            command.Parameters.AddWithValue("@NgaySinh", thanhVien.NgaySinh);
            command.Parameters.AddWithValue("@Email", thanhVien.Email);
            command.Parameters.AddWithValue("@SoDienThoai", thanhVien.SoDienThoai);
            command.Parameters.AddWithValue("@TrangThai", (int)thanhVien.TrangThai);
            command.Parameters.AddWithValue("@MatKhau", thanhVien.MatKhau);
            command.Parameters.AddWithValue("@ThoiGianDangKy", thanhVien.ThoiGianDangKy);

            command.ExecuteNonQuery();
        }
    }
}
