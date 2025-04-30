using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.Models.PhieuMuon;
using sgu_c_sharf_backend.ApiResponse;
using System;
using System.Collections.Generic;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/chi-tiet-phieu-muon")]
    [ApiController]
    public class ChiTietPhieuMuonController : ControllerBase
    {
        private readonly ChiTietPhieuMuonService _chiTietPhieuMuonService;

        public ChiTietPhieuMuonController(ChiTietPhieuMuonService chiTietPhieuMuonService)
        {
            _chiTietPhieuMuonService = chiTietPhieuMuonService;
        }

        // Lấy chi tiết phiếu mượn theo IdPhiếuMượn và IdDauThietBi
        [HttpGet("{idPhieuMuon}/{idDauThietBi}")]
        public ActionResult<ApiResponse<ChiTietPhieuMuonDetailDTO>> GetByPhieuMuonIdAndDauThietBiId(int idPhieuMuon, int idDauThietBi)
        {
            var res = _chiTietPhieuMuonService.GetByPhieuMuonIdAndDauThietBiId(idPhieuMuon, idDauThietBi);
            if (res == null)
            {
                return NotFound(ApiResponse<ChiTietPhieuMuon>.Fail("Không tìm thấy chi tiết phiếu mượn"));
            }
            return Ok(ApiResponse<ChiTietPhieuMuonDetailDTO>.Ok(res, "Thành công"));
        }

        // Lấy tất cả chi tiết phiếu mượn
        [HttpGet]
        public ActionResult<ApiResponse<List<ChiTietPhieuMuon>>> GetAllByPhieuMuonId(int idPhieuMuon)
        {
            var res = _chiTietPhieuMuonService.GetAllByPhieuMuonId(idPhieuMuon);
            return Ok(ApiResponse<List<ChiTietPhieuMuonDetailDTO>>.Ok(res, "Thành công"));
        }

        // Thêm mới chi tiết phiếu mượn
        [HttpPost]
        public ActionResult<ApiResponse<bool>> Add([FromBody] List<ChiTietPhieuMuonCreateDTO> entities)
        {
            if (entities == null || !entities.Any())
                return BadRequest(ApiResponse<bool>.Fail("Danh sách chi tiết phiếu mượn không hợp lệ"));

            var result = _chiTietPhieuMuonService.Add(entities);

            if (result)
                return Created("", ApiResponse<bool>.Ok(true, "Thêm chi tiết phiếu mượn thành công"));
            else
                return StatusCode(500, ApiResponse<bool>.Fail("Thêm chi tiết phiếu mượn thất bại"));
        }

        // Cập nhật chi tiết phiếu mượn
        [HttpPut]
        public ActionResult<ApiResponse<string>> Update([FromBody] List<ChiTietPhieuMuonUpdateDTO> chiTietPhieuMuonUpdates)
        {
            var res = _chiTietPhieuMuonService.Update(chiTietPhieuMuonUpdates);
            if (res)
            {
                return Ok(ApiResponse<string>.Ok("Cập nhật chi tiết phiếu mượn thành công"));
            }
            return NotFound(ApiResponse<string>.Fail("Không tìm thấy chi tiết phiếu mượn"));
        }

        // Xóa chi tiết phiếu mượn
        [HttpDelete]
        public ActionResult<ApiResponse<string>> Delete([FromBody] List<ChiTietPhieuMuon> chiTietPhieuMuonList)
        {
            if (chiTietPhieuMuonList == null || !chiTietPhieuMuonList.Any())
                return BadRequest(ApiResponse<string>.Fail("Danh sách chi tiết phiếu mượn không hợp lệ"));

            var res = _chiTietPhieuMuonService.Delete(chiTietPhieuMuonList);
            if (res)
            {
                return Ok(ApiResponse<string>.Ok("Xóa chi tiết phiếu mượn thành công"));
            }
            return NotFound(ApiResponse<string>.Fail("Không tìm thấy chi tiết phiếu mượn"));
        }
    }
}
