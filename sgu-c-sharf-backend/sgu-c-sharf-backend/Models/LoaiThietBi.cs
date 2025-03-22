using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models // Thay 'YourNamespace' bằng namespace thực tế của bạn
{
    public class LoaiThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string TenLoaiThietBi { get; set; }
        
    }
}