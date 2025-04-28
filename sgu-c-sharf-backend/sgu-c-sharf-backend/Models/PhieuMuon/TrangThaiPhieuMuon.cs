using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    [Table("TrangThaiPhieuMuon")]
    public class TrangThaiPhieuMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("PhieuMuon")]
        public int IdPhieuMuon { get; set; }

        [Required]
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }

        [Required]
        public DateTime ThoiGianCapNhat { get; set; } = DateTime.Now;

        public virtual PhieuMuon PhieuMuon { get; set; }
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
    
}