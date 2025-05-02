using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class PhieuMuonUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdThanhVien { get; set; }

    }

    public class PhieuMuonDetailDTO
    {
        public int Id { get; set; }
        public int IdThanhVien { get; set; }
        public string TenThanhVien { get; set; } = string.Empty;
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
        public DateTime NgayTao { get; set; }


    }

    public class PhieuMuonCreateDTO
    {
        [Required]
        public int IdThanhVien { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;
    }

    public class ChiTietPhieuMuonCreateDTO
    {
        [Required]
        public int IdPhieuMuon { get; set; }

        [Required]
        public int IdDauThietBi { get; set; }

        public DateTime ThoiGianMuon { get; set; } = DateTime.Now;

        public TrangThaiChiTietPhieuMuonEnum TrangThai { get; set; } = TrangThaiChiTietPhieuMuonEnum.DANGMUON;
    }
    public class ChiTietPhieuMuonDetailDTO
    {
        public int IdPhieuMuon { get; set; }
        public int IdDauThietBi { get; set; }

        public TrangThaiChiTietPhieuMuonEnum TrangThai { get; set; }
        public DateTime? ThoiGianMuon { get; set; }
        public DateTime? ThoiGianTra { get; set; }
    }

    public class ChiTietPhieuMuonUpdateDTO
    {
        [Required]
        public int IdPhieuMuon { get; set; }

        [Required]
        public int IdDauThietBi { get; set; }

        public DateTime? ThoiGianTra { get; set; }
        public TrangThaiChiTietPhieuMuonEnum? TrangThai { get; set; }
    }

    public class ChiTietPhieuMuonDeleteDTO
    {
        [Required]
        public int IdPhieuMuon { get; set; }

        [Required]
        public int IdDauThietBi { get; set; }
    }

    public class TrangThaiPhieuMuonCreateDTO
    {
        [Required]
        public int IdPhieuMuon { get; set; }

        [Required]
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }

        [Required]
        public DateTime ThoiGianCapNhat { get; set; } = DateTime.Now;
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
        HUY,
        DATCHO,
        DANGSUDUNG,
        DATRATHIETBI
    }
    public enum TrangThaiChiTietPhieuMuonEnum
    {
        DANGMUON,
        DATRATHIETBI,
        DATHATLAC
    }

    public class PhieuMuonPagingResponse
    {
        public List<PhieuMuonDetailDTO> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

}
