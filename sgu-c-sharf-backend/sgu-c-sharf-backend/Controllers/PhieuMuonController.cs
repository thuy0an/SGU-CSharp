// using System;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using sgu_c_sharf_backend.Models.PhieuMuon;
// using sgu_c_sharf_backend.Services;
// using sgu_c_sharf_backend.ApiResponse;

// namespace sgu_c_sharf_backend.Controllers
// {
//     [Route("api/phieu-muon")]
//     [ApiController]
//     public class PhieuMuonController : ControllerBase
//     {
//         private readonly PhieuMuonService _phieuMuonService;

//         public PhieuMuonController(PhieuMuonService phieuMuonService)
//         {
//             _phieuMuonService = phieuMuonService;
//         }

//         // Lấy danh sách phiếu mượn không có phân trang
//         [HttpGet]
//         public ActionResult<ApiResponse<List<PhieuMuon>>> GetAllNoPaging()
//         {
//             var res = _phieuMuonService.GetAllNoPaging();
//             return Ok(ApiResponse<List<PhieuMuon>>.Ok(res, "Thành công"));
//         }

//         // Lấy danh sách phiếu mượn với phân trang
//         [HttpGet("paging")]
//         public ActionResult<ApiResponse<List<PhieuMuon>>> GetAllWithPaging(int page = 1, int limit = 10)
//         {
//             var res = _phieuMuonService.GetAllWithPaging(page, limit);
//             return Ok(ApiResponse<List<PhieuMuon>>.Ok(res, "Thành công"));
//         }

//         // Lấy chi tiết phiếu mượn theo ID
//         [HttpGet("{id}")]
//         public ActionResult<ApiResponse<PhieuMuon>> GetById(int id)
//         {
//             var res = _phieuMuonService.GetById(id);
//             if (res == null)
//             {
//                 return NotFound(ApiResponse<PhieuMuon>.Fail("Không tìm thấy phiếu mượn"));
//             }
//             return Ok(ApiResponse<PhieuMuon>.Ok(res, "Thành công"));
//         }

//         // Thêm mới phiếu mượn
//         [HttpPost]
//         public ActionResult<ApiResponse<PhieuMuon>> AddPhieuMuon([FromBody] PhieuMuonCreateDTO pm)
//         {
//             if (pm == null)
//                 return BadRequest(ApiResponse<PhieuMuon>.Fail("Dữ liệu không hợp lệ"));

//             var phieuMuon = new PhieuMuon()
//             {
//                 IdThanhVien = pm.IdThanhVien,
//                 TrangThai = pm.TrangThai,
//                 NgayTao = DateTime.Now,
//                 NgayMuon = pm.NgayMuon   // Ngày mượn do người dùng chọn
//             };

//             var res = _phieuMuonService.AddPhieuMuon(phieuMuon);
//             return Created("", ApiResponse<PhieuMuon>.Ok(res, "Thêm phiếu mượn thành công"));
//         }

//         // Cập nhật phiếu mượn
//         [HttpPut("{id}")]
//         public ActionResult<ApiResponse<PhieuMuon>> UpdatePhieuMuon(int id, [FromBody] PhieuMuonUpdateDTO pm)
//         {
//             if (pm == null)
//                 return BadRequest(ApiResponse<PhieuMuon>.Fail("Dữ liệu không hợp lệ"));

//             var phieuMuon = new PhieuMuon()
//             {
//                 Id = id,
//                 TrangThai = pm.TrangThai
//             };

//             var res = _phieuMuonService.UpdatePhieuMuon(phieuMuon);
//             return Ok(ApiResponse<PhieuMuon>.Ok(res, "Cập nhật phiếu mượn thành công"));
//         }

//         // Xóa phiếu mượn
//         [HttpDelete("{id}")]
//         public ActionResult<ApiResponse<PhieuMuon>> DeletePhieuMuon(int id)
//         {
//             _phieuMuonService.DeletePhieuMuon(id);
//             return Ok(ApiResponse<PhieuMuon>.Ok(null, "Hủy phiếu mượn thành công"));
//         }
//     }
// }
