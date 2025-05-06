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
}
