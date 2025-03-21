using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Services;

namespace sgu_c_sharf_backend.Controllers
{
    [ApiController]
    [Route("api/thanh-vien")]
    public class ThanhVienController : ControllerBase
    {
        private readonly ThanhVienService _service;

        public ThanhVienController(ThanhVienService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<ThanhVien>>> GetAll()
        {
            var members = _service.GetAllMembers();
            return Ok(ApiResponse<List<ThanhVien>>.Ok(members));
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<ThanhVien>> GetById(int id)
        {
            var thanhVien = _service.GetMemberById(id);
            if (thanhVien == null)
                return NotFound(ApiResponse<ThanhVien>.Fail("Thành viên không tồn tại."));

            return Ok(ApiResponse<ThanhVien>.Ok(thanhVien));
        }

        [HttpPost]
        public ActionResult<ApiResponse<ThanhVien>> Register(ThanhVien thanhVien)
        {
            _service.RegisterMember(thanhVien);
            return CreatedAtAction(nameof(GetById), new { id = thanhVien.Id }, ApiResponse<ThanhVien>.Ok(thanhVien, "Đăng ký thành công"));
        }
    }
}