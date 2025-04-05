using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.LoaiThietBi
{
    [Table("LoaiThietBi")]
    public class LoaiThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string TenLoaiThietBi { get; set; }

        [Required]
        public bool DaXoa { get; set; } = false;
    }
}