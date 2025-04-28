// using Microsoft.AspNetCore.Mvc;
// using sgu_c_sharf_backend.Services;
// using sgu_c_sharf_backend.Models.PhieuMuon;
// using sgu_c_sharf_backend.ApiResponse;
// using System;
// using System.Collections.Generic;

// namespace sgu_c_sharf_backend.Controllers
// {
//     [Route("api/chi-tiet-phieu-muon")]
//     [ApiController]
//     public class ChiTietPhieuMuonController : ControllerBase
//     {
//         private readonly ChiTietPhieuMuonService _chiTietPhieuMuonService;

//         public ChiTietPhieuMuonController(ChiTietPhieuMuonService chiTietPhieuMuonService)
//         {
//             _chiTietPhieuMuonService = chiTietPhieuMuonService;
//         }

//         // Lấy chi tiết phiếu mượn theo IdPhiếuMượn và IdDauThietBi
//         [HttpGet("{idPhieuMuon}/{idDauThietBi}")]
//         public ActionResult<ApiResponse<ChiTietPhieuMuon>> GetByIds(int idPhieuMuon, int idDauThietBi)
//         {
//             var res = _chiTietPhieuMuonService.GetByIds(idPhieuMuon, idDauThietBi);
//             if (res == null)
//             {
//                 return NotFound(ApiResponse<ChiTietPhieuMuon>.Fail("Không tìm thấy chi tiết phiếu mượn"));
//             }
//             return Ok(ApiResponse<ChiTietPhieuMuon>.Ok(res, "Thành công"));
//         }

//         // Lấy tất cả chi tiết phiếu mượn
//         [HttpGet]
//         public ActionResult<ApiResponse<List<ChiTietPhieuMuon>>> GetAll()
//         {
//             var res = _chiTietPhieuMuonService.GetAll();
//             return Ok(ApiResponse<List<ChiTietPhieuMuon>>.Ok(res, "Thành công"));
//         }

//         // Thêm mới chi tiết phiếu mượn
//         // [HttpPost]
//         // public ActionResult<ApiResponse<int>> AddChiTietPhieuMuon([FromBody] ChiTietPhieuMuonCreateDTO chiTietPhieuMuon)
//         // {
//         //     if (chiTietPhieuMuon == null)
//         //         return BadRequest(ApiResponse<int>.Fail("Dữ liệu không hợp lệ"));

//         //     var entity = new ChiTietPhieuMuon
//         //     {
//         //         IdPhieuMuon = chiTietPhieuMuon.IdPhieuMuon,
//         //         IdDauThietBi = chiTietPhieuMuon.IdDauThietBi,
//         //         ThoiGianMuon = chiTietPhieuMuon.ThoiGianMuon,
//         //         ThoiGianTra = chiTietPhieuMuon.ThoiGianTra,
//         //         TrangThai = chiTietPhieuMuon.TrangThai
//         //     };

//         //     var res = _chiTietPhieuMuonService.AddChiTietPhieuMuon(entity);
//         //     return Created("", ApiResponse<int>.Ok(res, "Thêm chi tiết phiếu mượn thành công"));
//         // }

//         // Cập nhật chi tiết phiếu mượn
//         // [HttpPut("{idPhieuMuon}/{idDauThietBi}")]
//         // public ActionResult<ApiResponse<string>> UpdateChiTietPhieuMuon(int idPhieuMuon, int idDauThietBi, [FromBody] ChiTietPhieuMuonUpdateDTO chiTietPhieuMuonUpdate)
//         // {
//         //     var res = _chiTietPhieuMuonService.UpdateChiTietPhieuMuon(idPhieuMuon, idDauThietBi, chiTietPhieuMuonUpdate);
//         //     if (res)
//         //     {
//         //         return Ok(ApiResponse<string>.Ok("Cập nhật chi tiết phiếu mượn thành công"));
//         //     }
//         //     return NotFound(ApiResponse<string>.Fail("Không tìm thấy chi tiết phiếu mượn"));
//         // }

//         // Xóa chi tiết phiếu mượn
//         // [HttpDelete("{idPhieuMuon}/{idDauThietBi}")]
//         // public ActionResult<ApiResponse<string>> DeleteChiTietPhieuMuon(int idPhieuMuon, int idDauThietBi)
//         // {
//         //     var res = _chiTietPhieuMuonService.DeleteChiTietPhieuMuon(idPhieuMuon, idDauThietBi);
//         //     if (res)
//         //     {
//         //         return Ok(ApiResponse<string>.Ok("Xóa chi tiết phiếu mượn thành công"));
//         //     }
//         //     return NotFound(ApiResponse<string>.Fail("Không tìm thấy chi tiết phiếu mượn"));
//         // }
//     }
// }
