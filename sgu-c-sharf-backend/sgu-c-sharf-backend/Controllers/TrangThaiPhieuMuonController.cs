using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.Models.PhieuMuon;
using sgu_c_sharf_backend.ApiResponse;
using System.Collections.Generic;
using System.Transactions;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/trang-thai-phieu-muon")]
    [ApiController]
    public class TrangThaiPhieuMuonController : ControllerBase
    {
        private readonly TrangThaiPhieuMuonService _trangThaiPhieuMuonService;
        private readonly ChiTietPhieuMuonService _chiTietPhieuMuonService;

        private readonly DauThietBiService _dauThietBiService;


        public TrangThaiPhieuMuonController(TrangThaiPhieuMuonService trangThaiPhieuMuonService,
                                            ChiTietPhieuMuonService chiTietPhieuMuonService,
                                            DauThietBiService dauThietBiService)
        {
            _trangThaiPhieuMuonService = trangThaiPhieuMuonService;
            _chiTietPhieuMuonService = chiTietPhieuMuonService;
            _dauThietBiService = dauThietBiService;

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
        [HttpPost("update-trang-thai")]
        public IActionResult AddAndUpdate([FromBody] TrangThaiPhieuMuonCreateDTO entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponse<bool>.Fail("Dữ liệu không hợp lệ"));
            }
            try
            {
                // 1. Thêm trạng thái phiếu mượn
                var result = _trangThaiPhieuMuonService.Add(entity);
                if (!result)
                {
                    return StatusCode(500, ApiResponse<bool>.Fail("Thêm trạng thái phiếu mượn thất bại"));
                }

                // 2. Lấy danh sách chi tiết phiếu mượn
                var chiTietList = _chiTietPhieuMuonService.GetAllByPhieuMuonId(entity.IdPhieuMuon);
                if (chiTietList == null || !chiTietList.Any())
                {
                    return NotFound(ApiResponse<bool>.Fail($"Không tìm thấy chi tiết phiếu mượn cho phiếu mượn có ID {entity.IdPhieuMuon}"));
                }

                // Chuyển sang DTO update
                var chiTietUpdateList = chiTietList.Select(ct => new ChiTietPhieuMuonUpdateDTO
                {
                    IdPhieuMuon = ct.IdPhieuMuon,
                    IdDauThietBi = ct.IdDauThietBi,
                    TrangThai = TrangThaiChiTietPhieuMuonEnum.DATRATHIETBI,
                    ThoiGianTra = ct.ThoiGianTra
                }).ToList();

                var updateChiTietResult = _chiTietPhieuMuonService.Update(chiTietUpdateList);
                if (!updateChiTietResult)
                {
                    return StatusCode(500, ApiResponse<bool>.Fail("Cập nhật chi tiết phiếu mượn thất bại"));
                }
                var dauThietBiIds = chiTietList
                    .Select(ct => ct.IdDauThietBi)
                    .ToList();

                if (!dauThietBiIds.Any())
                {
                    return StatusCode(404, ApiResponse<bool>.Fail("Không tìm thấy thiết bị nào"));
                }
                // 3. Lấy danh sách đầu thiết bị
                var dauThietBiList = _dauThietBiService.GetByListId(dauThietBiIds);
                if (dauThietBiList == null || !dauThietBiList.Any())
                {
                    return NotFound(ApiResponse<bool>.Fail($"Không tìm thấy đầu thiết bị cho phiếu mượn ID {entity.IdPhieuMuon}"));
                }
                foreach (var dauThietBi in dauThietBiList)
                {
                    dauThietBi.TrangThai = TrangThaiDauThietBiEnum.KHADUNG;
                }

                var updateDauThietBiResult = _dauThietBiService.UpdateDanhSachDauThietBi(dauThietBiList);
                if (!updateDauThietBiResult)
                {
                    return StatusCode(500, ApiResponse<bool>.Fail("Cập nhật đầu thiết bị thất bại"));
                }
                // Trả về phản hồi thành công
                return Ok(ApiResponse<bool>.Ok(true, "Cập nhật trạng thái phiếu mượn và danh sách thiết bị thành công"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");

                // Trả về lỗi nếu có exception
                return StatusCode(500, ApiResponse<bool>.Fail($"Lỗi hệ thống: {ex.Message}"));
            }
        }
    }
}
