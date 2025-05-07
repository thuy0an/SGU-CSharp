namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class DauThietBi
    {
        public int Id { get; set; }
        public TrangThaiDauThietBi TrangThai { get; set; }
        public DateTime ThoiGianMua { get; set; }
        public int IdThietBi { get; set; }


        public enum TrangThaiDauThietBi
        {
            KHADUNG,
            DATTRUOC,
            DANGMUON,
            BAOTRI,
            THATLAC
        }
    }
    public class DauThietBiDetailResponseDto
    {
        public int Id { get; set; }
        public DauThietBi.TrangThaiDauThietBi TrangThai { get; set; }
        public DateTime ThoiGianMua { get; set; }
        public int IdThietBi { get; set; }
        public string TenThietBi { get; set; }
        public int IdLoaiThietBi { get; set; }
        public string TenLoaiThietBi { get; set; }
    }
}