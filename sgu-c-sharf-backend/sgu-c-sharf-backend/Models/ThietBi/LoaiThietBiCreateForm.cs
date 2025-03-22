using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.ThietBi
{
    public class LoaiThietBiCreateForm
    {
        [Required]
        [MaxLength(255)]
        public string TenLoaiThietBi { get; set; }
    }
}