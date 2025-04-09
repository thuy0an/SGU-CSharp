using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    public class PhieuMuonUpdateDTO
    {
        [Required]
        public int IdThanhVien { get; set; }

        [Required]
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
    }
}