using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    [Table("PhieuMuon")]
    public class PhieuMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ThanhVien")]
        public int IdThanhVien { get; set; }

        [Required]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Optional: Add the latest status field (TrangThaiMoiNhat)
        public string? TrangThaiMoiNhat { get; set; }  // Nullable for dynamic retrieval
    }
    public class PhieuMuonUpdateDTO
    {
        [Required]
        public int Id { get; set; }  
        
        [Required]
        public int IdThanhVien { get; set; } 
        
    }

    public class PhieuMuonListDTO
    {
        public int Id { get; set; }
        public int IdThanhVien { get; set; }
        public string TenThanhVien { get; set; } // To display member's name
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
        public DateTime ThoiGianLapPhieu { get; set; }
    }

    public class PhieuMuonDetailDTO
    {
        public int Id { get; set; }
        public int IdThanhVien { get; set; }
        public string TenThanhVien { get; set; } 
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
        public DateTime ThoiGianLapPhieu { get; set; }
        

    }

    public class PhieuMuonCreateDTO
    {
        [Required]
        public int IdThanhVien { get; set; }

        // Optional: You can include NgayTao if needed
        // This could also be handled in the controller or service
        // [Required] if you want to set it from the input.
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }

    // Enum for TrangThaiPhieuMuon
    public enum TrangThaiPhieuMuonEnum
    {
        HUY,
        XACNHAN,
        DANGSUDUNG,
        DATRATHIETBI
    }
}
