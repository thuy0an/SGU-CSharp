using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.ThanhVien;
using sgu_c_sharf_backend.Services;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/check-in")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly CheckInService _checkInService;

        public CheckInController(CheckInService checkInService){
            _checkInService = checkInService;
        }


        [HttpGet("{id}")]
        public ActionResult<ApiResponse<List<CheckIn>>> GetAll(int id){
            var result = _checkInService.GetAll(id);
            return Ok(ApiResponse<List<CheckIn>>.Ok(result, "Thành công"));
        }


        [HttpPost]
        public ActionResult<ApiResponse<bool>> Create(CheckIn checkIn){
            var result = _checkInService.Create(checkIn);
            if (result)
                return Ok(ApiResponse<bool>.Ok(result, "Thêm thành công"));
            else
                return BadRequest(ApiResponse<bool>.Fail("Thêm thất bại"));
        }
    }
}