using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgu_c_sharf_backend.Models.PhieuMuon
{
    public class TrangThaiPhieuMuonDetailDTO
    {
        public int Id { get; set; }

        public int IdPhieuMuon { get; set; }

        public TrangThaiPhieuMuonEnum TrangThai { get; set; }

        public DateTime ThoiGianCapNhat { get; set; }
    }

}
