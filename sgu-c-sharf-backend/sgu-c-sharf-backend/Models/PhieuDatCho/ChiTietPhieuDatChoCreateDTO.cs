using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.PhieuDatCho
{
    public class ChiTietPhieuDatChoCreateDTO
    {
        [Required]
        public int IdPhieuDat { get; set; }

        [Required]
        public int IdDauThietBi { get; set; }
    }
}