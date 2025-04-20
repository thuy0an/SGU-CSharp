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
    public class ThietBiController : ControllerBase
    {
        private readonly ThietBiService _thietBiService;

        public ThietBiController(ThietBiService thietBiService)
        {
            _thietBiService = thietBiService;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            try
            {
                var thietBi = _thietBiService.GetById(id);
                return Ok(ApiResponse<ThietBiDetailDTO>.Ok(thietBi));
            }
            catch (Exception ex)
            {
                return NotFound(ApiResponse<ThietBiDetailDTO>.Fail(ex.Message));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                var thietBis = _thietBiService.GetAll();
                return Ok(ApiResponse<IEnumerable<ThietBiListDTO>>.Ok(thietBis));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<IEnumerable<ThietBiListDTO>>.Fail(ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ThietBiCreateForm form)
        {
            try
            {
                _thietBiService.Add(form);
                return StatusCode(201, ApiResponse<ThietBiCreateForm>.Ok(form, "Tạo thiết bị thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ThietBiCreateForm>.Fail(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ThietBiUpdateForm form)
        {
            try
            {
                _thietBiService.Update(id, form);
                return Ok(ApiResponse<object>.Ok(null, "Cập nhật thiết bị thành công"));
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
                _thietBiService.Delete(id);
                return Ok(ApiResponse<object>.Ok(null, "Xóa thiết bị thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] string tenThietBi, [FromQuery] int? idLoaiThietBi)
        {
            try
            {
                var thietBis = _thietBiService.Search(tenThietBi, idLoaiThietBi);
                return Ok(ApiResponse<IEnumerable<ThietBiListDTO>>.Ok(thietBis));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<IEnumerable<ThietBiListDTO>>.Fail(ex.Message));
            }
        }

        [HttpGet("{id}/dau-thiet-bi")]
        [AllowAnonymous]
        public IActionResult GetDauThietBiByThietBiId(int id)
        {
            try
            {
                var dauThietBis = _thietBiService.GetDauThietBiByThietBiId(id);
                return Ok(ApiResponse<IEnumerable<DauThietBiListDTO>>.Ok(dauThietBis));
            }
            catch (Exception ex)
            {
                return NotFound(ApiResponse<IEnumerable<DauThietBiListDTO>>.Fail(ex.Message));
            }
        }
    }
}