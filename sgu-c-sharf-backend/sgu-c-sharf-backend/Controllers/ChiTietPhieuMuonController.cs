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
                return NotFound(ApiResponse<ChiTietPhieuMuonDetailDTO>.Fail("Không tìm thấy chi tiết phiếu mượn"));
            }
            return Ok(ApiResponse<ChiTietPhieuMuonDetailDTO>.Ok(res, "Thành công"));
        }

        // Lấy tất cả chi tiết phiếu mượn
        [HttpGet]
        public ActionResult<ApiResponse<List<ChiTietPhieuMuonDetailDTO>>> GetAllByPhieuMuonId(int idPhieuMuon)
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
        public ActionResult<ApiResponse<bool>> Update([FromBody] List<ChiTietPhieuMuonUpdateDTO> chiTietPhieuMuonUpdates)
        {
            var res = _chiTietPhieuMuonService.Update(chiTietPhieuMuonUpdates);
            if (res)
            {
                return Ok(ApiResponse<bool>.Ok(true, "Cập nhật chi tiết phiếu mượn thành công"));
            }
            return NotFound(ApiResponse<bool>.Fail("Không tìm thấy chi tiết phiếu mượn"));
        }

        // Xóa chi tiết phiếu mượn
        [HttpDelete]
        public ActionResult<ApiResponse<bool>> Delete([FromBody] List<ChiTietPhieuMuonDeleteDTO> chiTietPhieuMuonList)
        {
            if (chiTietPhieuMuonList == null || !chiTietPhieuMuonList.Any())
                return BadRequest(ApiResponse<bool>.Fail("Danh sách chi tiết phiếu mượn không hợp lệ"));

            var res = _chiTietPhieuMuonService.Delete(chiTietPhieuMuonList);
            if (res)
            {
                return Ok(ApiResponse<bool>.Ok(true, "Xóa chi tiết phiếu mượn thành công"));
            }
            return NotFound(ApiResponse<bool>.Fail("Không tìm thấy chi tiết phiếu mượn"));
        }
    }
}
