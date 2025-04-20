using sgu_c_sharf_backend.Models.ThietBi;
using System.Text.Json.Serialization;
namespace sgu_c_sharf_backend.Models.DauThietBi
{
    public class DauthietBiListByThietBi
    {
        public int Id { get; set; }
        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public TrangThaiDauThietBiEnum TrangThai { get; set; }
        public DateTime ThoiGianMua { get; set; }
        public int IdThietBi { get; set; }
    }
}