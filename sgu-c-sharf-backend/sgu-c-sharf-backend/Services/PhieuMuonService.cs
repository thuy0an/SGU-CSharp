// using sgu_c_sharf_backend.Models.PhieuMuon;
// using sgu_c_sharf_backend.Repositories;

// namespace sgu_c_sharf_backend.Services;

// public class PhieuMuonService
// {
//     private readonly PhieuMuonRepository _phieuMuonRepository;

//     public PhieuMuonService(PhieuMuonRepository phieuMuonRepository)
//     {
//         _phieuMuonRepository = phieuMuonRepository;
//     }

//     /// Lấy tất cả phiếu mượn
//     public List<PhieuMuon> GetAll()
//     {
//         return _phieuMuonRepository.GetAll();
//     }
//     public List<PhieuMuon> GetAllPaging(int page, int limit)
//     {
//         return _phieuMuonRepository.GetAllPaging(page, limit);
//     }

//     /// Lấy phiếu mượn theo ID
//     public PhieuMuon? GetById(int id)
//     {
//         return _phieuMuonRepository.GetById(id);
//     }

//     /// Thêm mới phiếu mượn
//     public PhieuMuon? AddPhieuMuon(PhieuMuon phieuMuon)
//     {
//         return _phieuMuonRepository.Add(phieuMuon);
//     }

//     /// Cập nhật phiếu mượn
//     public PhieuMuon? CapNhatPhieuMuon(int id, string trangThai)
//     {
//         var existing = _phieuMuonRepository.GetById(phieuMuon.Id);
//         if (existing == null) return null;

//         return _phieuMuonRepository.UpdateTrangThai(id, trangThai);
//     }

//     /// Xoá phiếu mượn
//     public bool XoaPhieuMuon(int id)
//     {
//         var existing = _phieuMuonRepository.GetById(id);
//         if (existing == null) return false;

//         _phieuMuonRepository.UpdateTrangThai(id, "HUY");
//         return true;
//     }
// }
