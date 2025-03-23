using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.PhieuDatCho
{
    public class PhieuDatChoCreateDTO
    {
        [Required]
        public int IdThanhVien { get; set; }

        [Required]
        public TrangThaiPhieuDatChoEnum TrangThai { get; set; }
    }
}