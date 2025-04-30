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

        public List<ChiTietPhieuMuonDetailDTO> GetAllByPhieuMuonId(int idPhieuMuon){
            return _repository.GetAllByPhieuMuonId(idPhieuMuon);
        }

        public ChiTietPhieuMuonDetailDTO? GetByPhieuMuonIdAndDauThietBiId(int idPhieuMuon, int idDauThietBi){
            return _repository.GetByPhieuMuonIdAndDauThietBiId(idPhieuMuon, idDauThietBi);
        }

        public bool Add(List<ChiTietPhieuMuonCreateDTO> entities){
            return _repository.Add(entities);
        }

        public bool Update(List<ChiTietPhieuMuonUpdateDTO> entities){
            return _repository.Update(entities);
        }

        public bool Delete(List<ChiTietPhieuMuon> entities){
            return _repository.Delete(entities);
        }
    }
}
