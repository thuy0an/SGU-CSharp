using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Models
{
    [Table("ChiTietPhieuDatCho")]
    public class ChiTietPhieuDatCho
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("PhieuDatCho")]
        public int IdPhieuDat { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("DauThietBi")]
        public int IdDauThietBi { get; set; }

        public virtual PhieuDatCho.PhieuDatCho PhieuDatCho { get; set; }
        public virtual sgu_c_sharf_backend.Models.ThietBi.DauThietBi DauThietBi { get; set; }
    }
}