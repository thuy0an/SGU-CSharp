namespace sgu_c_sharf_backend.Models.ThietBi
{
    public class DauThietBiDetailResponseDto
    {
        public int Id { get; set; }
        public TrangThaiDauThietBiEnum TrangThai { get; set; }
        public DateTime ThoiGianMua { get; set; }
        public int IdThietBi { get; set; }
        public string TenThietBi { get; set; }
        public int IdLoaiThietBi { get; set; }
        public string TenLoaiThietBi { get; set; }
    }
}