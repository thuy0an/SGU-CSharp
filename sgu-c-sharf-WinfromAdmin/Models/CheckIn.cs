using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgu_c_sharf_WinfromAdmin.Models
{
    public class CheckIn
    {
        public int Id { get; set; }
        public int IdThanhVien {get; set;}

        public DateTime ThoiGianCheckIn { get; set; }
    }
}