using System;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class ThietBi
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; }
        public string TenLoaiThietBi { get; set; }
        public bool ThietbiEnum { get; set; }
    }

    public enum ThietbiEnum
    {
        CHUAXOA = 0,
        DAXOA = 1
    }
}