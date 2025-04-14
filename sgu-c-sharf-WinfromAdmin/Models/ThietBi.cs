using System;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class ThietBi
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; }
        public string TenLoaiThietBi { get; set; }
        public bool DaXoa { get; set; }
    }

    public enum DaXoaEnum
    {
        CHUAXOA = 0,
        DAXOA = 1
    }
}