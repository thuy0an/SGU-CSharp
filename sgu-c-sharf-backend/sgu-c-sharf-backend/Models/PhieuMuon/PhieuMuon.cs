using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models
{
    [Table("PhieuMuon")]
    public class PhieuMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }

        [Required]
        public DateTime NgayTao { get; set; }
    }
    public enum TrangThaiPhieuMuonEnum
    {
        HUY,
        DANGSUDUNG,
        DATRATHIETBI
    }
}