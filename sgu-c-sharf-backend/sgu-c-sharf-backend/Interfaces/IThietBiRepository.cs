using System;
using System.Collections.Generic;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Interfaces
{
    public interface IThietBiRepository
    {
        ThietBi GetById(int id);
        IEnumerable<ThietBi> GetAll();
        void Add(ThietBiCreateForm thietBiCreateForm);
        void Update(int id, ThietBiUpdateForm thietBiUpdateForm); // Thêm ID vào Update

        IEnumerable<ThietBi> Search(
            string? tenThietBi, // Tìm kiếm theo tên
            int? idLoaiThietBi, // Lọc theo loại thiết bị
            bool? daXoa // Lọc theo trạng thái đã xóa
        );

        int UpdateByCondition(
            string? tenThietBiCondition, // Điều kiện cho TenThietBi
            int? idLoaiThietBiCondition, // Điều kiện cho IdLoaiThietBi
            bool? daXoaCondition, // Điều kiện cho DaXoa
            ThietBiUpdateForm updateValues // Giá trị cần cập nhật
        );

        void Delete(int id);
    }
}