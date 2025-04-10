using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Models.PhieuDatCho;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.ApiResponse;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/phieu-dat-cho")]
    [ApiController]
    public class PhieuDatChoController : ControllerBase
    {
        private readonly PhieuDatChoService _phieuDatChoService;
        
    public PhieuDatChoController(PhieuDatChoService phieuDatChoService)
    {
        _phieuDatChoService = phieuDatChoService;
    }

    [HttpGet]
    public ActionResult<ApiResponse<List<PhieuDatCho>>> GetAllNoPaging(){
        var res = _phieuDatChoService.GetAllNoPaging();
        return Ok(ApiResponse<List<PhieuDatCho>>.Ok(res, "Thành công"));
    }

    [HttpGet("{id}")]
    public ActionResult<ApiResponse<PhieuDatCho>> GetById(int id){
        PhieuDatCho? res = _phieuDatChoService.GetById(id);
        if( res == null){
            return NotFound(ApiResponse<PhieuDatCho>.Fail("Không tìm thấy phiếu đặt chỗ"));
        }
        return Ok(ApiResponse<PhieuDatCho>.Ok(res, "Thành công"));
    }

        [HttpPost]
        public ActionResult<ApiResponse<PhieuDatCho>> AddPhieuDatCho([FromBody] PhieuDatChoCreateDTO pdc)
        {
            if (pdc == null)
                return BadRequest(ApiResponse<PhieuDatCho>.Fail("Dữ liệu không hợp lệ"));

            var phieudatcho = new PhieuDatCho()
            {
                IdThanhVien = pdc.IdThanhVien,
                TrangThai = pdc.TrangThai,
                ThoiGianLapPhieu = DateTime.Now,
                ThoiGianDat = pdc.ThoiGianDat   // Thời gian đặt chỗ do người dùng chọn
            };

            var res = _phieuDatChoService.AddPhieuDatCho(phieudatcho);
            return Created("", ApiResponse<PhieuDatCho>.Ok(res, "Thêm phiếu đặt chỗ thành công"));
        }

    [HttpPut("{id}")]
    public ActionResult<ApiResponse<PhieuDatCho>> UpdatePhieuDatCho(int id, [FromBody] PhieuDatChoUpdateDTO pdc){
        if (pdc == null)
            return BadRequest(ApiResponse<PhieuDatCho>.Fail("Dữ liệu không hợp lệ"));
        
        var phieudatcho = new PhieuDatCho()
        {
            Id = id,
            TrangThai = pdc.TrangThai
        };

        var res = _phieuDatChoService.UpdatePhieuDatCho(phieudatcho);
        return Ok(ApiResponse<PhieuDatCho>.Ok(res, "Cập nhật phiếu đặt chỗ thành công"));

    }

    [HttpDelete("{id}")]
    public ActionResult<ApiResponse<PhieuDatCho>> DeletePhieuDatCho(int id){
        _phieuDatChoService.DeletePhieuDatCho(id);
        return Ok(ApiResponse<PhieuDatCho>.Ok(null, "Hủy phiếu đặt chỗ thành công"));
    
    }

    }
}