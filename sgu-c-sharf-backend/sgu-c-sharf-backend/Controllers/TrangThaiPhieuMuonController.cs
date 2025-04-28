// using Microsoft.AspNetCore.Mvc;
// using sgu_c_sharf_backend.Services;
// using sgu_c_sharf_backend.Models.PhieuMuon;
// using sgu_c_sharf_backend.ApiResponse;
// using System;
// using System.Collections.Generic;

// namespace sgu_c_sharf_backend.Controllers
// {
//     [Route("api/trang-thai-phieu-muon")]
//     [ApiController]
//     public class TrangThaiPhieuMuonController : ControllerBase
//     {
//         private readonly TrangThaiPhieuMuonService _trangThaiPhieuMuonService;

//         public TrangThaiPhieuMuonController(TrangThaiPhieuMuonService trangThaiPhieuMuonService)
//         {
//             _trangThaiPhieuMuonService = trangThaiPhieuMuonService;
//         }

//         // Lấy danh sách trạng thái phiếu mượn theo IdPhiếuMượn
//         [HttpGet("phieu-muon/{idPhieuMuon}")]
//         public ActionResult<ApiResponse<List<TrangThaiPhieuMuon>>> GetByPhieuMuonId(int idPhieuMuon)
//         {
//             var res = _trangThaiPhieuMuonService.GetByPhieuMuonId(idPhieuMuon);
//             if (res == null || res.Count == 0)
//             {
//                 return NotFound(ApiResponse<List<TrangThaiPhieuMuon>>.Fail("Không tìm thấy trạng thái phiếu mượn"));
//             }
//             return Ok(ApiResponse<List<TrangThaiPhieuMuon>>.Ok(res, "Thành công"));
//         }

//         // Thêm mới trạng thái phiếu mượn
//         // [HttpPost]
//         // public ActionResult<ApiResponse<int>> AddTrangThaiPhieuMuon([FromBody] TrangThaiPhieuMuonCreateDTO trangThaiPhieuMuon)
//         // {
//         //     if (trangThaiPhieuMuon == null)
//         //         return BadRequest(ApiResponse<int>.Fail("Dữ liệu không hợp lệ"));

//         //     var entity = new TrangThaiPhieuMuon
//         //     {
//         //         IdPhieuMuon = trangThaiPhieuMuon.IdPhieuMuon,
//         //         TrangThai = trangThaiPhieuMuon.TrangThai,
//         //         ThoiGianCapNhat = DateTime.Now
//         //     };

//         //     var res = _trangThaiPhieuMuonService.AddTrangThaiPhieuMuon(entity);
//         //     return Created("", ApiResponse<int>.Ok(res, "Thêm trạng thái phiếu mượn thành công"));
//         // }

//     }
// }
