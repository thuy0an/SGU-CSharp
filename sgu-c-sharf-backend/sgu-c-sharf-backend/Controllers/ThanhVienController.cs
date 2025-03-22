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
                    ThoiGianDangKy = tv.ThoiGianDangKy,
                    Quyen = tv.Quyen,
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

        

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<ThanhVienDetailResponseDto>> GetById(int id)
        {
            ThanhVien? thanhVien = _service.GetById(id);
            if (thanhVien == null)
            {
                return NotFound(ApiResponse<ThanhVienDetailResponseDto>.Fail("Không tìm thấy thành viên!"));
            }

            ThanhVienDetailResponseDto dto = new ThanhVienDetailResponseDto
            {
                Id = thanhVien.Id,
                HoTen = thanhVien.HoTen,
                Email = thanhVien.Email,
                NgaySinh = thanhVien.NgaySinh,
                SoDienThoai = thanhVien.SoDienThoai,
                TrangThai = thanhVien.TrangThai,
                ThoiGianDangKy = thanhVien.ThoiGianDangKy,
                Quyen = thanhVien.Quyen,
            };

            return Ok(ApiResponse<ThanhVienDetailResponseDto>.Ok(dto, "Lấy thông tin thành viên thành công"));
        }


        [HttpPost("register")]
        public ActionResult<ApiResponse<ThanhVienDetailResponseDto>> AddThanhVien([FromBody] ThanhVienCreateForm request)
        {
            if (request == null)
            {
                return BadRequest(ApiResponse<ThanhVienDetailResponseDto>.Fail("Dữ liệu không hợp lệ."));
            }

            var thanhVien = new ThanhVien
            {
                HoTen = request.HoTen,
                NgaySinh = request.NgaySinh,
                Email = request.Email,
                SoDienThoai = request.SoDienThoai,
                TrangThai = TrangThaiEnum.HOATDONG,
                Quyen = QuyenEnum.USER,
                MatKhau = request.MatKhau // Mật khẩu sẽ được mã hóa trong service
            };

            var createdThanhVien = _service.AddThanhVien(thanhVien);

            if (createdThanhVien == null)
            {
                return StatusCode(500, ApiResponse<ThanhVienDetailResponseDto>.Fail("Không thể thêm thành viên."));
            }

            // Chuyển đổi sang DTO để trả về
            ThanhVienDetailResponseDto response = new ThanhVienDetailResponseDto()
            {
                Id = createdThanhVien.Id,
                HoTen = createdThanhVien.HoTen,
                NgaySinh = createdThanhVien.NgaySinh,
                Email = createdThanhVien.Email,
                SoDienThoai = createdThanhVien.SoDienThoai,
                TrangThai = createdThanhVien.TrangThai,
                ThoiGianDangKy = createdThanhVien.ThoiGianDangKy
            };

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, ApiResponse<ThanhVienDetailResponseDto>.Ok(response, "Đăng ký thành công."));
        }
        
        
        [HttpPut("{id}")]
        public ActionResult<ApiResponse<ThanhVienDetailResponseDto>> UpdateThanhVien(
            int id,
            [FromBody] ThanhVienUpdateForm request)
        {
            if (request == null)
            {
                return BadRequest(ApiResponse<ThanhVienDetailResponseDto>.Fail("Dữ liệu không hợp lệ."));
            }

            // Tạo đối tượng ThanhVien từ yêu cầu
            var thanhVien = new ThanhVien
            {
                Id = id,
                HoTen = request.HoTen,
                NgaySinh = request.NgaySinh,
                SoDienThoai = request.SoDienThoai,
                TrangThai = request.TrangThai
            };

            // Gọi service để cập nhật thành viên
            var updatedThanhVien = _service.CapNhatThanhVien(thanhVien);

            // Kiểm tra nếu không có thành viên nào được cập nhật
            if (updatedThanhVien == null)
            {
                return StatusCode(500, ApiResponse<ThanhVienDetailResponseDto>.Fail("Không thể cập nhật thông tin thành viên."));
            }

            // Chuyển đổi đối tượng thành viên thành DTO để trả về
            ThanhVienDetailResponseDto response = new ThanhVienDetailResponseDto()
            {
                Id = updatedThanhVien.Id,
                HoTen = updatedThanhVien.HoTen,
                NgaySinh = updatedThanhVien.NgaySinh,
                Email = updatedThanhVien.Email,
                SoDienThoai = updatedThanhVien.SoDienThoai,
                TrangThai = updatedThanhVien.TrangThai,
                ThoiGianDangKy = updatedThanhVien.ThoiGianDangKy
            };

            // Trả về ApiResponse với thông báo thành công
            return Ok(ApiResponse<ThanhVienDetailResponseDto>.Ok(response, "Cập nhật thông tin thành viên thành công."));
        }


        
    }
}