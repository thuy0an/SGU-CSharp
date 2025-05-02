using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    [Table("ChiTietPhieuMuon")]
    public class ChiTietPhieuMuon
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("PhieuMuon")]
        public int IdPhieuMuon { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("DauThietBi")]
        public int IdDauThietBi { get; set; }

        [Required]
        public DateTime ThoiGianMuon { get; set; } = DateTime.Now;

        [Required]
        public DateTime? ThoiGianTra { get; set; }

        [Required]
        public TrangThaiChiTietPhieuMuonEnum TrangThai { get; set; }

        public virtual PhieuMuon PhieuMuon { get; set; }
        public virtual sgu_c_sharf_backend.Models.ThietBi.DauThietBi DauThietBi { get; set; }
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

    public enum TrangThaiChiTietPhieuMuonEnum
    {
        DANGMUON,  
        DATRATHIETBI,  
        DATHATLAC  
    }
}
