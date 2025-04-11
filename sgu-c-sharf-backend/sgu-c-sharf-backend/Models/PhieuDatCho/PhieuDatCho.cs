using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Import List

namespace sgu_c_sharf_backend.Models.PhieuDatCho
{
    [Table("PhieuDatCho")]
    public class PhieuDatCho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ThanhVien")]
        public int IdThanhVien { get; set; }

        [Required]
        public TrangThaiPhieuDatChoEnum TrangThai { get; set; }

        [Required]
        public DateTime ThoiGianDat { get; set; } = DateTime.Now;

        [Required]
        public DateTime ThoiGianLapPhieu { get; set; } = DateTime.Now;

        // // Navigation property để truy cập danh sách các ChiTietPhieuDatCho
        // public virtual ICollection<ChiTietPhieuDatCho> ChiTietPhieuDatChos { get; set; } = new List<ChiTietPhieuDatCho>();
    }
    public enum TrangThaiPhieuDatChoEnum
    {
        HUY,
        DANGCHO,
        DANGSUDUNG,
        DATRACHO
    }
}