namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class ThietBi
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; }
        public string TenLoaiThietBi { get; set; }
        public int IdLoaiThietBi { get; set; }
        public ThietbiEnum ThietbiEnum { get; set; }
    }

    public enum ThietbiEnum
    {
        CHUAXOA = 0,
        DAXOA = 1
    }
}