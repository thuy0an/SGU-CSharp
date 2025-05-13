using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using sgu_c_sharf_backend.Models.PhieuXuPhat;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class PhieuXuPhatService
    {
        private readonly PhieuXuPhatRepository _phieuXuPhatRepository;

        public PhieuXuPhatService(PhieuXuPhatRepository phieuXuPhatRepository)
        {
            _phieuXuPhatRepository = phieuXuPhatRepository;
        }

        public List<PhieuXuPhatDetailDTO> GetAll()
        {
            return _phieuXuPhatRepository.GetAll();
        }

        public PhieuXuPhatPagingResponse GetAllPaging(int page, int limit, TrangThaiPhieuXuPhatEnum? trangThai, DateTime? fromDate, DateTime? toDate, string? keyword)
        {
            return _phieuXuPhatRepository.GetAllPaging(page, limit, trangThai, fromDate, toDate, keyword);
        }

        public PhieuXuPhatDetailDTO? GetById(uint id)
        {
            return _phieuXuPhatRepository.GetById(id);
        }
        public List<PhieuXuPhatDetailDTO> GetByIdUser(uint id)
        {
            return _phieuXuPhatRepository.GetByIdUser(id);
        }
        public uint Add(PhieuXuPhatCreateDTO createDTO)
        {
            return _phieuXuPhatRepository.Add(createDTO);
        }

        public bool Update(uint id, PhieuXuPhatUpdateDTO updateDTO)
        {
            return _phieuXuPhatRepository.Update(id, updateDTO);
        }

        public bool Delete(uint id)
        {
            return _phieuXuPhatRepository.Delete(id);
        }
    }
}