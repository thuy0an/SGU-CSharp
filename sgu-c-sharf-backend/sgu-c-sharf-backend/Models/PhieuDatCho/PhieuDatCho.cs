using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models
{
    [Table("PhieuDatCho")]
    public class PhieuDatCho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ThanhVien")]
        public int IdThanhVien { get; set; }

        public virtual ThanhVien.ThanhVien ThanhVien { get; set; } // Navigation property

        [Required]
        public TrangThaiPhieuDatChoEnum TrangThai { get; set; }

        [Required]
        public DateTime ThoiGianDat { get; set; } = DateTime.Now;

        [Required]
        public DateTime ThoiGianLapPhieu { get; set; } = DateTime.Now;
    }
    public enum TrangThaiPhieuDatChoEnum
    {
        HUY,
        DANGCHO,
        DANGSUDUNG,
        DATRACHO
    }
}