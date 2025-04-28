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

        [Range(1, 100, ErrorMessage = "Số lượng đầu thiết bị phải từ 1 đến 100.")]
        public int SoLuongDauThietBi { get; set; } = 1; // Mặc định là 1 nếu không cung cấp
    }
}