using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.PhieuXuPhat
{
    [Table("PhieuXuPhat")]
    public class PhieuXuPhat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; } // Sử dụng uint để phù hợp với INT UNSIGNED

        [Required]
        public TrangThaiPhieuXuPhatEnum TrangThai { get; set; }

        [Required]
        public DateTime NgayViPham { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(255)]
        public string MoTa { get; set; }

        public uint? ThoiHanXuPhat { get; set; } // Sử dụng uint? để phù hợp với INT UNSIGNED
        public uint? MucPhat { get; set; } // Sử dụng uint? để phù hợp với INT UNSIGNED

        [Required]
        [ForeignKey("ThanhVien")]
        public uint IdThanhVien { get; set; } // Sử dụng uint để phù hợp với INT UNSIGNED

        public virtual ThanhVien.ThanhVien ThanhVien { get; set; }
    }

    public class PhieuXuPhatCreateDTO
    {
        [Required]
        public TrangThaiPhieuXuPhatEnum TrangThai { get; set; } = TrangThaiPhieuXuPhatEnum.CHUAXULY;

        [Required]
        public DateTime NgayViPham { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(255)]
        public string MoTa { get; set; }

        public uint? ThoiHanXuPhat { get; set; } // Sử dụng uint?
        public uint? MucPhat { get; set; } // Sử dụng uint?

        [Required]
        public uint IdThanhVien { get; set; } // Sử dụng uint
    }

    public class PhieuXuPhatDetailDTO
    {
        public uint Id { get; set; } // Sử dụng uint
        public TrangThaiPhieuXuPhatEnum TrangThai { get; set; }
        public DateTime NgayViPham { get; set; }
        public string MoTa { get; set; }
        public uint? ThoiHanXuPhat { get; set; } // Sử dụng uint?
        public uint? MucPhat { get; set; } // Sử dụng uint?
        public uint IdThanhVien { get; set; } // Sử dụng uint
        public string TenThanhVien { get; set; }
    }

    public class PhieuXuPhatUpdateDTO
    {
        public TrangThaiPhieuXuPhatEnum? TrangThai { get; set; }

        public DateTime? NgayViPham { get; set; }

        [MaxLength(255)]
        public string? MoTa { get; set; }

        public uint? ThoiHanXuPhat { get; set; } // Sử dụng uint?
        public uint? MucPhat { get; set; } // Sử dụng uint?

        public uint? IdThanhVien { get; set; } // Sử dụng uint?
    }

    public class PhieuXuPhatDeleteDTO
    {
        [Required]
        public uint Id { get; set; } // Sử dụng uint
    }

    public enum TrangThaiPhieuXuPhatEnum
    {
        DAXOA,
        DAXULY,
        CHUAXULY
    }
}