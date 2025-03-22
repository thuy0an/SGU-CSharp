using System;
using System.Collections.Generic;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.PhieuXuPhat;

namespace sgu_c_sharf_backend.Interfaces
{
    public interface IPhieuXuPhatRepository
    {
        PhieuXuPhat GetById(int id);
        IEnumerable<PhieuXuPhat> GetAll();
        void Add(PhieuXuPhatCreateForm phieuXuPhatCreateForm);
        void Update(int id, PhieuXuPhatUpdateForm phieuXuPhatUpdateForm);
        void Delete(int id);

        IEnumerable<PhieuXuPhat> Search(
            string? trangThai, // Tìm kiếm theo trạng thái
            DateTime? ngayViPhamStart, // Lọc theo ngày vi phạm (từ ngày)
            DateTime? ngayViPhamEnd, // Lọc theo ngày vi phạm (đến ngày)
            string? moTa, // Tìm kiếm theo mô tả
            int? thoiHanXuPhat, //Lọc theo thời hạn
            int? mucPhat, //Lọc theo Mức phạt
            int? idThanhVien // Lọc theo Id thành viên
        );
    }
}