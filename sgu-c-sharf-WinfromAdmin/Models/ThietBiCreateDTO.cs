using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class ThietBiCreateDTO
    {
        [Required]
        public string TenThietBi { get; set; }

        [Required]
        public int IdLoaiThietBi { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Số lượng đầu thiết bị phải từ 1 đến 100.")]
        public int SoLuongDauThietBi { get; set; }
    }
}