using System.Collections.Generic;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.ThanhVien;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class ThanhVienService
    {
        private readonly ThanhVienRepository _thanhVienRepository;

        public ThanhVienService(ThanhVienRepository repository)
        {
            _thanhVienRepository = repository;
        }

        public PagedResult<ThanhVien> GetAll(int pageNumber, int pageSize, string? search, TrangThaiEnum? status, string? sortBy, string? sortDirection)
        {
            return _thanhVienRepository.GetAll(pageNumber, pageSize, search, status, sortBy, sortDirection);
        }

        // public ThanhVien? GetMemberById(int id) => _thanhVienRepository.GetById(id);
        //
        // public void RegisterMember(ThanhVien thanhVien) => _thanhVienRepository.Create(thanhVien);
    }
}