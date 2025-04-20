using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    public class PhieuMuonCreateDTO
    {
        [Required]
        public int IdThanhVien { get; set; }
    }
}