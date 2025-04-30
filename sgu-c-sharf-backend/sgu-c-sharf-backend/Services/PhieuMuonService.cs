using System.Globalization;
using sgu_c_sharf_backend.Models.PhieuMuon;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services;

public class PhieuMuonService
{
    private readonly PhieuMuonRepository _phieuMuonRepository;

    public PhieuMuonService(PhieuMuonRepository phieuMuonRepository)
    {
        _phieuMuonRepository = phieuMuonRepository;
    }

    public PhieuMuonDetailDTO GetById(int id)
    {
        return _phieuMuonRepository.GetById(id);
    }

    public List<PhieuMuonDetailDTO> GetAll()
    {
        return _phieuMuonRepository.GetAll();
    }
    public (List<PhieuMuonDetailDTO> items, int currentPage, int totalPages) GetAllPaging(int page, int limit, DateTime? fromDate, DateTime? toDate, TrangThaiPhieuMuonEnum? trangThai)
    {
        return _phieuMuonRepository.GetAllPaging(page, limit, fromDate, toDate, trangThai);
    }

    public int Add(PhieuMuonCreateDTO phieuMuon)
    {
        return _phieuMuonRepository.Add(phieuMuon);
    }

    public bool Update(PhieuMuonUpdateDTO phieuMuon)
    {
        return _phieuMuonRepository.Update(phieuMuon);
    }
}
