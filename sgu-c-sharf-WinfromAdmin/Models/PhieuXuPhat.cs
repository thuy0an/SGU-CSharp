using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgu_c_sharf_WinfromAdmin.Models
{
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
    public class PhieuXuPhatPagingResponse

    {
        public List<PhieuXuPhatDetailDTO> Items { get; set; }

        public int TotalItems { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; }
    }
}
