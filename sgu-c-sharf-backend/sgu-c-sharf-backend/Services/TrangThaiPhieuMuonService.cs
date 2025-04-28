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

        public async Task<List<TrangThaiPhieuMuon>> GetByPhieuMuonIdAsync(int idPhieuMuon)
        {
            return await _repository.GetByPhieuMuonIdAsync(idPhieuMuon);
        }

        public async Task AddAsync(TrangThaiPhieuMuon trangThai)
        {
            await _repository.AddAsync(trangThai);
        }

    }
}
