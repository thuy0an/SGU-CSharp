using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.ThanhVien;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class ThanhVienService
    {
        private readonly ThanhVienRepository _thanhVienRepository;
        private readonly IPasswordHasher<object> _passwordHasher;

        public ThanhVienService(ThanhVienRepository thanhVienRepository, IPasswordHasher<object> passwordHasher)
        {
            _thanhVienRepository = thanhVienRepository;
            _passwordHasher = passwordHasher;
        }

        public PagedResult<ThanhVien> GetAll(int pageNumber, int pageSize, string? search, TrangThaiEnum? status,
            string? sortBy, string? sortDirection)
        {
            return _thanhVienRepository.GetAll(pageNumber, pageSize, search, status, sortBy, sortDirection);
        }

        public ThanhVien? GetById(int id)
        {
            return _thanhVienRepository.GetById(id);
        }

        public ThanhVien? AddThanhVien(ThanhVien thanhVien)
        {
            // Mã hóa mật khẩu trước khi lưu
            thanhVien.MatKhau = _passwordHasher.HashPassword(null, thanhVien.MatKhau);

            // Gọi Repository để thêm mới thành viên
            return _thanhVienRepository.Create(thanhVien);
        }
    }
}