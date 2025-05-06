using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sgu_c_sharf_backend.Models.ThanhVien;
namespace sgu_c_sharf_backend.Models
{
    [Table("OTP")]
    public class OTP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; } // Sử dụng uint để phù hợp với INT UNSIGNED

        [Required]
        [MaxLength(255)]
        public string Token { get; set; } = string.Empty;

        [Required]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Required]
        public DateTime NgayHetHan { get; set; }

        [Required]
        [MaxLength(50)]
        public string LoaiOTP { get; set; } = string.Empty;

        [Required]
        [ForeignKey("ThanhVien")]
        public int IdThanhVien { get; set; } // Sử dụng uint để phù hợp với INT UNSIGNED

        public virtual ThanhVien.ThanhVien ThanhVien { get; set; } // Quan hệ với ThanhVien
    }

    public class OTPCreateDTO
    {
        [Required]
        [MaxLength(255)]
        public string Token { get; set; } = string.Empty;

        [Required]
        public DateTime NgayHetHan { get; set; }

        [Required]
        [MaxLength(50)]
        public string LoaiOTP { get; set; } = string.Empty;

        [Required]
        public int IdThanhVien { get; set; } // Sử dụng uint
    }
    
}