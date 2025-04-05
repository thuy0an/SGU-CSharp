using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.ThietBi
{
    public class LoaiThietBiUpdateForm
    {
        [Required]
        [MaxLength(255)]
        public string tenLoaiThietBi { get; set; }
    }
}