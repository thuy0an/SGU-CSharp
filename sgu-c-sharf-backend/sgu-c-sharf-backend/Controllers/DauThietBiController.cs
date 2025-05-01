using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.ThietBi;
using sgu_c_sharf_backend.Services;

namespace sgu_c_sharf_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize(Roles = "ADMIN")]
    public class DauThietBiController : ControllerBase
    {
        private readonly DauThietBiService _dauThietBiService;

        public DauThietBiController(DauThietBiService dauThietBiService)
        {
            _dauThietBiService = dauThietBiService;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            try
            {
                var dauThietBi = _dauThietBiService.GetById(id);
                return Ok(ApiResponse<DauThietBiDetailResponseDto>.Ok(dauThietBi));
            }
            catch (Exception ex)
            {
                return NotFound(ApiResponse<DauThietBiDetailResponseDto>.Fail(ex.Message));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                var dauThietBis = _dauThietBiService.GetAll();
                return Ok(ApiResponse<IEnumerable<DauThietBiListDTO>>.Ok(dauThietBis));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<IEnumerable<DauThietBiListDTO>>.Fail(ex.Message));
            }
        }

        [HttpGet("{id}/{soLuong}")]
        [AllowAnonymous]
        public IActionResult GetDauThietBiByIdVaSoLuong(int id, int soLuong)
        {
            try
            {
                // Gọi dịch vụ để lấy danh sách đầu thiết bị theo IdThietBi và SoLuong
                var dauThietBis = _dauThietBiService.GetDauThietBiByIdVaSoLuong(id, soLuong);

                // Trả về phản hồi thành công với dữ liệu
                return Ok(ApiResponse<IEnumerable<DauThietBiListDTO>>.Ok(dauThietBis));
            }
            catch (Exception ex)
            {
                // Trả về phản hồi lỗi nếu có ngoại lệ xảy ra
                return BadRequest(ApiResponse<IEnumerable<DauThietBiListDTO>>.Fail(ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] DauThietBiCreateForm form)
        {
            try
            {
                _dauThietBiService.Add(form);
                return StatusCode(201, ApiResponse<DauThietBiCreateForm>.Ok(form, "Tạo đầu thiết bị thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<DauThietBiCreateForm>.Fail(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DauThietBiUpdateForm form)
        {
            try
            {
                _dauThietBiService.Update(id, form);
                return Ok(ApiResponse<object>.Ok(null, "Cập nhật đầu thiết bị thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpPut("update-danhsach")]
        public IActionResult UpdateDanhSach([FromBody] List<DauThietBiListDTO> formList)
        {
            try
            {
                bool result = _dauThietBiService.UpdateDanhSachDauThietBi(formList);
                if (result)
                {
                    return Ok(ApiResponse<object>.Ok(result, "Cập nhật danh sách đầu thiết bị thành công"));
                }
                else
                {
                    return BadRequest(ApiResponse<object>.Fail("Cập nhật thất bại (có thiết bị không tồn tại hoặc lỗi)"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dauThietBiService.Delete(id);
                return Ok(ApiResponse<object>.Ok(null, "Xóa đầu thiết bị thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] int? idThietBi, [FromQuery] string trangThai)
        {
            try
            {
                var dauThietBis = _dauThietBiService.Search(idThietBi, trangThai);
                return Ok(ApiResponse<IEnumerable<DauThietBiListDTO>>.Ok(dauThietBis));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<IEnumerable<DauThietBiListDTO>>.Fail(ex.Message));
            }
        }
    }
}