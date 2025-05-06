using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.Models.PhieuMuon;
using sgu_c_sharf_backend.ApiResponse;
using System.Collections.Generic;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/trang-thai-phieu-muon")]
    [ApiController]
    public class TrangThaiPhieuMuonController : ControllerBase
    {
        private readonly TrangThaiPhieuMuonService _trangThaiPhieuMuonService;

        public TrangThaiPhieuMuonController(TrangThaiPhieuMuonService trangThaiPhieuMuonService)
        {
            _trangThaiPhieuMuonService = trangThaiPhieuMuonService;
        }

        // GET: api/trang-thai-phieu-muon/phieu-muon/{idPhieuMuon}
        [HttpGet("phieu-muon/{idPhieuMuon}")]
        public ActionResult<ApiResponse<List<TrangThaiPhieuMuonDetailDTO>>> GetByPhieuMuonId(int idPhieuMuon)
        {
            var res = _trangThaiPhieuMuonService.GetByPhieuMuonIdAsync(idPhieuMuon);
            if (res == null || res.Count == 0)
            {
                return NotFound(ApiResponse<List<TrangThaiPhieuMuonDetailDTO>>.Fail("Không tìm thấy trạng thái phiếu mượn"));
            }
            return Ok(ApiResponse<List<TrangThaiPhieuMuonDetailDTO>>.Ok(res, "Thành công"));
        }

        // GET: api/trang-thai-phieu-muon/phieu-muon/{idPhieuMuon}/moi-nhat
        [HttpGet("phieu-muon/{idPhieuMuon}/moi-nhat")]
        public ActionResult<ApiResponse<TrangThaiPhieuMuonDetailDTO>> GetTrangThaiMoiNhat(int idPhieuMuon)
        {
            var res = _trangThaiPhieuMuonService.GetTrangThaiMoiNhat(idPhieuMuon);
            if (res == null)
            {
                return NotFound(ApiResponse<TrangThaiPhieuMuonDetailDTO>.Fail("Không tìm thấy trạng thái mới nhất"));
            }
            return Ok(ApiResponse<TrangThaiPhieuMuonDetailDTO>.Ok(res, "Thành công"));
        }

        // POST: api/trang-thai-phieu-muon
        [HttpPost]
        public ActionResult<ApiResponse<bool>> Add([FromBody] TrangThaiPhieuMuonCreateDTO entity)
        {
            
            if (entity == null)
            {
                return BadRequest(ApiResponse<bool>.Fail("Dữ liệu không hợp lệ"));
            }

            var result = _trangThaiPhieuMuonService.Add(entity);
            if (result)
            {
                return Created("", ApiResponse<bool>.Ok(true, "Thêm trạng thái phiếu mượn thành công"));
            }
            else
            {
                return StatusCode(500, ApiResponse<bool>.Fail("Thêm trạng thái phiếu mượn thất bại"));
            }
        }
    }
}
