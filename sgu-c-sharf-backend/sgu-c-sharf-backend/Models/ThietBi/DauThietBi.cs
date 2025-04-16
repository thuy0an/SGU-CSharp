using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.ThietBi
{
    [Table("DauThietBi")]
    public class DauThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public TrangThaiDauThietBiEnum TrangThai { get; set; }

        [Required]
        public DateTime ThoiGianMua { get; set; }

        [Required]
        [ForeignKey("ThietBi")]
        public int IdThietBi { get; set; }

        public virtual Models.ThietBi.ThietBi ThietBi { get; set; }
    }
    public enum TrangThaiDauThietBiEnum
    {
        KHADUNG,
        DATTRUOC,
        DANGMUON,
        THATLAC,
        BAOTRI,
        THANHLY,
        DATHATLAC
    }
}