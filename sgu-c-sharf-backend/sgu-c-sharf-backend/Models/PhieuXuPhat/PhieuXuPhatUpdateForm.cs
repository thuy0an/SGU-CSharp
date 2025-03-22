using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.PhieuXuPhat
{
    public class PhieuXuPhatUpdateForm
    {
        [Required]
        public TrangThaiPhieuXuPhatEnum TrangThai { get; set; }

        [Required]
        public DateTime NgayViPham { get; set; }

        [Required]
        [MaxLength(255)]
        public string MoTa { get; set; }

        public int? ThoiHanXuPhat { get; set; }

        public int? MucPhat { get; set; }
    }


}