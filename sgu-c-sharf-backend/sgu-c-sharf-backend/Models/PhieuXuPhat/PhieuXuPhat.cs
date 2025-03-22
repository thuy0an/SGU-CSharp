using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.PhieuXuPhat
{
    [Table("PhieuXuPhat")]
    public class PhieuXuPhat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public TrangThaiPhieuXuPhatEnum TrangThai { get; set; }

        [Required]
        public DateTime NgayViPham { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(255)]
        public string MoTa { get; set; }

        public int? ThoiHanXuPhat { get; set; }

        public int? MucPhat { get; set; }

        // Foreign Key
        public int? IdThanhVien { get; set; }

        // Navigation property
        [ForeignKey("IdThanhVien")]
        public virtual ThanhVien.ThanhVien? ThanhVien { get; set; }
    }

    public enum TrangThaiPhieuXuPhatEnum
    {
        CHUA_XU_LY,
        DA_XU_LY
    }
}