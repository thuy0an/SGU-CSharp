namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    public class PhieuMuonListDTO
    {
        public int Id { get; set; }
        public int IdThanhVien { get; set; }
        public string HoTenThanhVien { get; set; } // Để hiển thị tên thành viên
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
        public DateTime ThoiGianLapPhieu { get; set; }
    }
}