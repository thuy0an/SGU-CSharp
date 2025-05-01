namespace sgu_c_sharf_backend.Models.ThietBi
{
    public class ThietBiListAvailabilityDTO
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; }
        public string TenLoaiThietBi { get; set; }

        public int SoLuongKhaDung {get; set;}
    }
}