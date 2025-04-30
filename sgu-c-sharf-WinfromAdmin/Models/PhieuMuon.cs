using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class PhieuMuon
    {
        public int Id { get; set; }
        public int IdThanhVien { get; set; }
        public string TenThanhVien { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; }
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
    }
    public class ChiTietPhieuMuon
    {
        public int IdPhieuMuon { get; set; }
        public int IdDauThietBi { get; set; }
        public string TenDauThietBi { get; set; } = string.Empty;
        public TrangThaiChiTietPhieuMuonEnum TrangThai { get; set; }
        public DateTime ThoiGianMuon { get; set; }
        public DateTime ThoiGianTra { get; set; }
    }
    public class TrangThaiPhieuMuonDetailDTO
    {
        public int Id { get; set; }
        public int IdPhieuMuon { get; set; }
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
    }
    public enum TrangThaiPhieuMuonEnum
    {
        HUY = 0,
        XACNHAN = 1,
        DANGSUDUNG = 2,
        DATRATHIETBI = 3
    }
    public enum TrangThaiChiTietPhieuMuonEnum
    {
        DANGMUON = 0,
        DATRATHIETBI = 1,
        DATHATLAC = 2
    }

    public class ChiTietPhieuMuonCreateDTO
    {
        public int IdPhieuMuon { get; set; }
        public int IdDauThietBi { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayMuon { get; set; }
    }

    public class ChiTietPhieuMuonUpdateDTO
    {
        public int IdPhieuMuon { get; set; }
        public int IdDauThietBi { get; set; }
        public int SoLuong { get; set; }
        public DateTime? NgayTra { get; set; }
    }
    public class PhieuMuonCreateDTO
    {
        public int IdThanhVien { get; set; }
    }

    public class PhieuMuonPagingResponse
    {
        public List<PhieuMuon> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
    public class TrangThaiPhieuMuon
    {
        public int Id { get; set; }

        public int IdPhieuMuon { get; set; }

        public TrangThaiPhieuMuonEnum TrangThai { get; set; }

        public DateTime ThoiGianCapNhat { get; set; }
    }
}
