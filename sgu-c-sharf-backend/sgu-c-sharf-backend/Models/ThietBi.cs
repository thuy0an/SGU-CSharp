using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models // Thay 'YourNamespace' bằng namespace thực tế của bạn
{
    public class ThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string TenThietBi { get; set; }

        [Required]
        [ForeignKey("LoaiThietBi")]
        public int IdLoaiThietBi { get; set; }

        public virtual LoaiThietBi LoaiThietBi { get; set; } // Navigation property

        // Có thể thêm các thuộc tính khác nếu cần thiết (ví dụ: mô tả, ngày tạo, ...)
    }
}