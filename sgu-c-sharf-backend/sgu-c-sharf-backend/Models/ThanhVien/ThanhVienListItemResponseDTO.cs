
namespace sgu_c_sharf_backend.Models.ThanhVien;

public class ThanhVienListItemResponseDto
{
    public int Id { get; set; }

    public string HoTen { get; set; }
    
    public string Email { get; set; }

    public string SoDienThoai { get; set; }

    public TrangThaiEnum TrangThai { get; set; }

    public DateTime ThoiGianDangKy { get; set; } = DateTime.Now;
}