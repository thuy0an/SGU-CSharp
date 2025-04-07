using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class LoaiThietbi
    {
        public int Id { get; set; }
        public string TenLoaiThietBi { get; set; }
        public DaXoaEnum TrangThai { get; set; }
    }

    public enum DaXoaEnum
    {
        CHUAXOA = 0,
        DAXOA = 1
    }
}