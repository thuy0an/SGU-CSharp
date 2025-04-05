namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class ThanhVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public TrangThaiEnum TrangThai { get; set; }
        public QuyenEnum Quyen { get; set; }
        public string MatKhau { get; set; }
        public DateTime ThoiGianDangKy { get; set; }
    }

    public enum TrangThaiEnum
    {
        HOATDONG = 0,
        DINHCHI = 1,
        CAM = 2
    }

    public enum QuyenEnum
    {
        ADMIN = 0,
        USER = 1
    }
}
