using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.ThietBi
{
    public class ThietBiCreateForm
    {
        [Required]
        [MaxLength(255)]
        public string TenThietBi { get; set; }

        [Required]
        public int IdLoaiThietBi { get; set; }
    }
}