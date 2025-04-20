using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    [Table("TrangThaiPhieuMuon")]
    public class TrangThaiPhieuMuonCreateDTO
    {
        [Required]
        public int IdPhieuMuon { get; set; }

        [Required]
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }

        [Required]
        public DateTime ThoiGianCapNhat { get; set; } = DateTime.Now;
    }
}
