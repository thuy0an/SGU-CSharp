using System;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class ThietBi
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; }
        public int IdLoaiThietBi { get; set; }
        public ThietBiEnum TrangThai { get; set; }
    }

    public enum ThietBiEnum
    {
        CHUAXOA = 0,
        DAXOA = 1
    }
}