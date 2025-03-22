using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models;
using sgu_c_sharf_backend.Models.ThanhVien;
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
        public ActionResult<ApiResponse<PagedResult<ThanhVienListItemResponseDto>>> GetAll(
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 10, 
            [FromQuery] string? search = null,
            [FromQuery] TrangThaiEnum? status = null,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortDirection = null)
        {
            PagedResult<ThanhVien> pagedResult = _service.GetAll(pageNumber, pageSize, search, status, sortBy, sortDirection);

            // Chuyển đổi danh sách từ ThanhVien sang ThanhVienListItemResponseDto
            List<ThanhVienListItemResponseDto> dtoList = pagedResult.Content
                .Select(tv => new ThanhVienListItemResponseDto
                {
                    Id = tv.Id,
                    HoTen = tv.HoTen,
                    Email = tv.Email,
                    SoDienThoai = tv.SoDienThoai,
                    TrangThai = tv.TrangThai,
                    ThoiGianDangKy = tv.ThoiGianDangKy
                })
                .ToList();

            PagedResult<ThanhVienListItemResponseDto> pagedDtoResult = new PagedResult<ThanhVienListItemResponseDto>(
                dtoList, 
                pagedResult.TotalElements, 
                pageNumber, 
                pageSize
            );

            return Ok(ApiResponse<PagedResult<ThanhVienListItemResponseDto>>.Ok(
                pagedDtoResult, 
                "Lấy danh sách thành viên thành công"
            ));
        }







        // [HttpGet("{id}")]
        // public ActionResult<ApiResponse<ThanhVien>> GetById(int id)
        // {
        //     var thanhVien = _service.GetMemberById(id);
        //     if (thanhVien == null)
        //         return NotFound(ApiResponse<ThanhVien>.Fail("Thành viên không tồn tại."));
        //
        //     return Ok(ApiResponse<ThanhVien>.Ok(thanhVien));
        // }
        //
        // [HttpPost]
        // public ActionResult<ApiResponse<ThanhVien>> Register(ThanhVien thanhVien)
        // {
        //     _service.RegisterMember(thanhVien);
        //     return CreatedAtAction(nameof(GetById), new { id = thanhVien.Id }, ApiResponse<ThanhVien>.Ok(thanhVien, "Đăng ký thành công"));
        // }
    }
}