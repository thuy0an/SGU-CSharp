using System.Collections.Generic;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.ThietBi; // Import namespace cho LoaiThietBi

namespace sgu_c_sharf_backend.Interfaces
{
    public interface ILoaiThietBiRepository
    {
        LoaiThietBi GetById(int id);
        IEnumerable<LoaiThietBi> GetAll();
        void Add(LoaiThietBiCreateForm loaiThietBiCreateForm);
        void Update(int id, LoaiThietBiUpdateForm loaiThietBiUpdateForm); // Truyền Id
        void Delete(int id); // Soft Delete
        IEnumerable<LoaiThietBi> Search(string? tenLoaiThietBi, bool? daXoa);
    }
}