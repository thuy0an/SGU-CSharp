using System;
using System.Collections.Generic;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Interfaces
{
    public interface IDauThietBiRepository
    {
        DauThietBi GetById(int id);
        IEnumerable<DauThietBi> GetAll();
        void Add(DauThietBiCreateForm dauThietBi);
        void Update(DauThietBiUpdateForm dauThietBi);

        IEnumerable<DauThietBi> Search(string trangThai, DateTime? thoiGianMuaStart, DateTime? thoiGianMuaEnd, int? idThietBi);
        int UpdateByCondition(
            string? trangThaiCondition, // Điều kiện cho TrangThai
            DateTime? thoiGianMuaStartCondition, // Điều kiện cho ThoiGianMua (từ ngày)
            DateTime? thoiGianMuaEndCondition, // Điều kiện cho ThoiGianMua (đến ngày)
            int? idThietBiCondition, // Điều kiện cho IdThietBi
            DauThietBiUpdateForm? updateValues // Giá trị cần cập nhật
        );
    }
}