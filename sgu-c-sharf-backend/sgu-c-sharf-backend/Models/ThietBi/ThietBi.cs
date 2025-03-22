using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.ThietBi
{
    [Table("ThietBi")]
    public class ThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string TenThietBi { get; set; }

        [Required]
        [ForeignKey("LoaiThietBi")]
        public int IdLoaiThietBi { get; set; }

        public virtual LoaiThietBi LoaiThietBi { get; set; } 

        [Required]
        public bool DaXoa { get; set; } = false;
    }
}