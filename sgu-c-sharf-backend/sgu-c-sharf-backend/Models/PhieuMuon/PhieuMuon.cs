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
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }

        [Required]
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
    public enum TrangThaiPhieuMuonEnum
    {
        HUY,
        DANGSUDUNG,
        DATRATHIETBI
    }
}