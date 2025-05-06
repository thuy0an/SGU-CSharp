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
        [HttpGet("nopaging")]
        public ActionResult<ApiResponse<List<PhieuMuonDetailDTO>>> GetAllNoPaging()
        {
            var res = _phieuMuonService.GetAll();
            return Ok(ApiResponse<List<PhieuMuonDetailDTO>>.Ok(res, "Thành công"));
        }

        // Lấy danh sách phiếu mượn với phân trang
        [HttpGet("paging")]
        public ActionResult<ApiResponse<PhieuMuonPagingResponse>> GetAllWithPaging(int page, int limit, DateTime? fromDate, DateTime? toDate, TrangThaiPhieuMuonEnum? trangThai, string? keyword = null)
        {
            var res = _phieuMuonService.GetAllPaging(page, limit, fromDate, toDate, trangThai, keyword);
            return Ok(ApiResponse<PhieuMuonPagingResponse>.Ok(res, "Thành công"));
        }

        // Lấy chi tiết phiếu mượn theo ID
        [HttpGet("{id}")]
        public ActionResult<ApiResponse<PhieuMuonDetailDTO>> GetById(int id)
        {

            var res = _phieuMuonService.GetById(id);
            if (res == null)
            {
                return NotFound(ApiResponse<PhieuMuonDetailDTO>.Fail("Không tìm thấy phiếu mượn"));
            }
            return Ok(ApiResponse<PhieuMuonDetailDTO>.Ok(res, "Thành công"));
        }
        
        // Lấy chi tiết phiếu mượn theo ID
        [HttpGet("thanh-vien/{id}")]
        public ActionResult<ApiResponse<List<PhieuMuonDetailDTO>>> GetByIdByAccountId(int id){
            

            var res = _phieuMuonService.GetAllByAccountId(id);
            if (res == null)
            {
                return NotFound(ApiResponse<List<PhieuMuonDetailDTO>>.Fail("Không tìm thấy phiếu mượn"));
            }
            return Ok(ApiResponse<List<PhieuMuonDetailDTO>>.Ok(res, "Thành công"));
        }

        // Thêm mới phiếu mượn 
        [HttpPost]
        public ActionResult<ApiResponse<int>> Add([FromBody] PhieuMuonCreateDTO pm)
        {
            if (pm == null)
                return BadRequest(ApiResponse<int>.Fail("Dữ liệu không hợp lệ"));

            var phieuMuon = new PhieuMuonCreateDTO()
            {
                IdThanhVien = pm.IdThanhVien,
                NgayTao = DateTime.Now,
            };

            var res = _phieuMuonService.Add(phieuMuon);
            return Created("", ApiResponse<int>.Ok(res, "Thêm phiếu mượn thành công"));
        }

        // Cập nhật phiếu mượn 
        [HttpPut("{id}")]
        public ActionResult<ApiResponse<bool>> Update(int id, [FromBody] PhieuMuonUpdateDTO phieuMuon)
        {
            if (phieuMuon == null || phieuMuon.Id != id)
            {
                return BadRequest(ApiResponse<bool>.Fail("Dữ liệu không hợp lệ"));
            }

            var res = _phieuMuonService.Update(phieuMuon);
            return Ok(ApiResponse<bool>.Ok(res, "Cập nhật phiếu mượn thành công"));
        }
    }
}
