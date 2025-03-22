using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sgu_c_sharf_backend.Models.ThanhVien
{
    [Table("ThanhVien")]
    public class ThanhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string HoTen { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        public TrangThaiEnum TrangThai { get; set; }

        [Required]
        [MaxLength(255)]
        public string MatKhau { get; set; }

        [Required]
        public DateTime ThoiGianDangKy { get; set; } = DateTime.Now;
    }

    public enum TrangThaiEnum
    {
        HOATDONG,
        DINHCHI,
        CAM
    }
}
