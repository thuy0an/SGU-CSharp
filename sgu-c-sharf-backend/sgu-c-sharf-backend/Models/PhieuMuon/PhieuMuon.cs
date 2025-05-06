using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    [Table("PhieuMuon")]
    public class PhieuMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ThanhVien")]
        public int IdThanhVien { get; set; }

        [Required]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        public TrangThaiPhieuMuonEnum TrangThai { get; set; } 
    }
    public class PhieuMuonUpdateDTO
    {
        [Required]
        public int Id { get; set; }  
        
        [Required]
        public int IdThanhVien { get; set; } 
        
    }

    public class PhieuMuonDetailDTO
    {
        public int Id { get; set; }
        public int IdThanhVien { get; set; }
        public string TenThanhVien { get; set; } = string.Empty;
        public TrangThaiPhieuMuonEnum TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        

    }

    public class PhieuMuonCreateDTO
    {
        [Required]
        public int IdThanhVien { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;
    }

    public class PhieuMuonPagingResponse
    {
        public List<PhieuMuonDetailDTO> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
    public enum TrangThaiPhieuMuonEnum
    {
        CHODUYET,
        DATCHO,
        DANGSUDUNG,
        DATRATHIETBI,
        HUY
    }
    public class PhieuMuonChiTietDTO
{
    public int PhieuMuonId { get; set; }
    public DateTime NgayTaoPhieuMuon { get; set; }
    
    public int ThanhVienId { get; set; }
    public string TenThanhVien { get; set; }
    public string Email { get; set; }
    public string SoDienThoai { get; set; }
    
    public int? TrangThaiPhieuMuonId { get; set; }
    public string TrangThaiPhieuMuon { get; set; }
    public DateTime? ThoiGianCapNhatTrangThai { get; set; }
    
    public int? IdDauThietBi { get; set; }
    public DateTime? ThoiGianMuon { get; set; }
    public DateTime? ThoiGianTra { get; set; }
    public string TrangThaiChiTietPhieuMuon { get; set; }
    
    public string TrangThaiDauThietBi { get; set; }
    public DateTime? ThoiGianMua { get; set; }
    
    public string TenThietBi { get; set; }
    public string AnhMinhHoa { get; set; }
}
}
