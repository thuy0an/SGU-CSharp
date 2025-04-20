using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Models.PhieuMuon;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.ApiResponse;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/phieu-muon")]
    [ApiController]
    public class PhieuMuonController : ControllerBase
    {
        private readonly PhieuMuonService _phieuMuonService;

        public PhieuMuonController(PhieuMuonService phieuMuonService)
        {
            _phieuMuonService = phieuMuonService;
        }

        // Lấy danh sách phiếu mượn không có phân trang
        [HttpGet]
        public ActionResult<ApiResponse<List<PhieuMuon>>> GetAllNoPaging()
        {
            var res = _phieuMuonService.GetAll();
            return Ok(ApiResponse<List<PhieuMuon>>.Ok(res, "Thành công"));
        }

        // Lấy danh sách phiếu mượn với phân trang
        [HttpGet("paging")]
        public ActionResult<ApiResponse<List<PhieuMuon>>> GetAllWithPaging(int page = 1, int limit = 10)
        {
            var res = _phieuMuonService.GetAllPaging(page, limit);
            return Ok(ApiResponse<List<PhieuMuon>>.Ok(res, "Thành công"));
        }

        // Lấy chi tiết phiếu mượn theo ID
        [HttpGet("{id}")]
        public ActionResult<ApiResponse<PhieuMuon>> GetById(int id)
        {
            var res = _phieuMuonService.GetById(id);
            if (res == null)
            {
                return NotFound(ApiResponse<PhieuMuon>.Fail("Không tìm thấy phiếu mượn"));
            }
            return Ok(ApiResponse<PhieuMuon>.Ok(res, "Thành công"));
        }

        // Thêm mới phiếu mượn
        [HttpPost]
        public ActionResult<ApiResponse<int>> AddPhieuMuon([FromBody] PhieuMuonCreateDTO pm)
        {
            if (pm == null)
                return BadRequest(ApiResponse<PhieuMuon>.Fail("Dữ liệu không hợp lệ"));

            var phieuMuon = new PhieuMuon()
            {
                IdThanhVien = pm.IdThanhVien,
                NgayTao = DateTime.Now,
            };

            var res = _phieuMuonService.AddPhieuMuon(phieuMuon);
            return Created("", ApiResponse<int>.Ok(res, "Thêm phiếu mượn thành công"));
        }

    }
}
