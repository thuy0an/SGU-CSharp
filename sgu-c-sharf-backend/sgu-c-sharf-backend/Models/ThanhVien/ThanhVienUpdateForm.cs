using System.Text.Json.Serialization;

namespace sgu_c_sharf_backend.Models.ThanhVien;

public class ThanhVienUpdateForm
{
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string SoDienThoai { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TrangThaiEnum TrangThai { get; set; }
}
