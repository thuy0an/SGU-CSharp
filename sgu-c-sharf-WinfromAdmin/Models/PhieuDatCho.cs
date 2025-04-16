using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    internal class PhieuDatCho
    {
        public int Id { get; set; }
        public int IdThanhVien { get; set; }

        public DateTime ThoiGianDat { get; set; }
        public DateTime ThoiGianLapPhieu { get; set; }

        public PhieuDatChoEnum TrangThai { get; set; }

    }
    public enum PhieuDatChoEnum
    {
        HUY = 0,
        DANGCHO = 1,
        DANGSUDUNG = 2,
        DATRACHO =3,
    }
}
