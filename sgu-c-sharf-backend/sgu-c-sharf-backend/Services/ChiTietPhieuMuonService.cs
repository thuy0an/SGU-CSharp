using System;
using System.Collections.Generic;
using sgu_c_sharf_backend.Models.PhieuMuon;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class ChiTietPhieuMuonService
    {
        private readonly ChiTietPhieuMuonRepository _repository;

        public ChiTietPhieuMuonService(ChiTietPhieuMuonRepository repository)
        {
            _repository = repository;
        }

        public ChiTietPhieuMuon? GetByIds(int idPhieuMuon, int idDauThietBi)
        {
            return _repository.GetByIds(idPhieuMuon, idDauThietBi);
        }

        public List<ChiTietPhieuMuon> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(ChiTietPhieuMuon entity)
        {
            _repository.Add(entity);
        }

        public void Update(ChiTietPhieuMuon entity)
        {
            _repository.Update(entity);
        }
    }
}
