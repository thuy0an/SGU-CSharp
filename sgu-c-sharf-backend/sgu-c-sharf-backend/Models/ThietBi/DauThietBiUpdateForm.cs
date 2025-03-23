using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.ThietBi
{
    public class DauThietBiUpdateForm
    {
        [Required]
        public TrangThaiDauThietBiEnum TrangThai { get; set; }

        [Required]
        public DateTime ThoiGianMua { get; set; }

        [Required]
        public int IdThietBi { get; set; } 
        
        [Required]
        public int Id { get; set; } 
    }
}