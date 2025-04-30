using sgu_c_sharf_backend.Models.PhieuMuon;
using sgu_c_sharf_backend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sgu_c_sharf_backend.Services
{
    public class TrangThaiPhieuMuonService
    {
        private readonly TrangThaiPhieuMuonRepository _repository;

        public TrangThaiPhieuMuonService(TrangThaiPhieuMuonRepository repository)
        {
            _repository = repository;
        }

        public List<TrangThaiPhieuMuonDetailDTO> GetByPhieuMuonIdAsync(int idPhieuMuon)
        {
            return  _repository.GetByPhieuMuonId(idPhieuMuon);
        }

        public bool Add(TrangThaiPhieuMuonCreateDTO trangThai)
        {
            return _repository.Add(trangThai);
        }

        public TrangThaiPhieuMuonDetailDTO GetTrangThaiMoiNhat(int idPhieuMuon)
        {
            return _repository.GetTrangThaiMoiNhat(idPhieuMuon);
        }
    }
}
