using System.Collections.Generic;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class ThanhVienService
    {
        private readonly ThanhVienRepository _repository;

        public ThanhVienService(ThanhVienRepository repository)
        {
            _repository = repository;
        }

        public List<ThanhVien> GetAllMembers() => _repository.GetAll();

        public ThanhVien? GetMemberById(int id) => _repository.GetById(id);

        public void RegisterMember(ThanhVien thanhVien) => _repository.Create(thanhVien);
    }
}