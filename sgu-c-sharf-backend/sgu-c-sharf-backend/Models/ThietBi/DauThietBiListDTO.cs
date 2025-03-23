namespace sgu_c_sharf_backend.Models.ThietBi
{
    public class DauThietBiListDTO
    {
        public int Id { get; set; }
        public TrangThaiDauThietBiEnum TrangThai { get; set; }
        public DateTime ThoiGianMua { get; set; }
        public int IdThietBi { get; set; }
    }
}