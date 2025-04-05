
using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Models.LoaiThietBi;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.ThietBi;

namespace sgu_c_sharf_backend.Controllers
{
    [Route("api/loai-thiet-bi")]
    [ApiController]
    public class LoaiThietBiController : ControllerBase
    {
        private readonly LoaiThietBiService _loaiThietBiService;

        public LoaiThietBiController(LoaiThietBiService loaiThietBiService)
        {
            _loaiThietBiService = loaiThietBiService;
        }

        [HttpGet("no-paging")]
        public ActionResult<ApiResponse<List<LoaiThietBi>>> GetNoPaging()
        {
            var result = _loaiThietBiService.GetNoPaging();
            return Ok(ApiResponse<List<LoaiThietBi>>.Ok(result, "Thành công"));
        }

        [HttpGet]
        public ActionResult<ApiResponse<PagedResult<LoaiThietBi>>> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 100,
            [FromQuery] string? search = null,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortDirection = null)
        {
            PagedResult<LoaiThietBi> pagedResult =
                _loaiThietBiService.GetAll(pageNumber, pageSize, search, sortBy, sortDirection);

            // List<LoaiThietBi> dtoList = pagedResult.Content
            //     .Select(tv => new LoaiThietBi
            //     {
            //         Id = tv.Id,
            //         HoTen = tv.HoTen,
            //         Email = tv.Email,
            //         SoDienThoai = tv.SoDienThoai,
            //         TrangThai = tv.TrangThai,
            //         ThoiGianDangKy = tv.ThoiGianDangKy,
            //         Quyen = tv.Quyen,
            //     })
            //     .ToList();
            //
            // PagedResult<LoaiThietBi> pagedDtoResult = new PagedResult<LoaiThietBi>(
            //     dtoList, 
            //     pagedResult.TotalElements, 
            //     pageNumber, 
            //     pageSize
            // );

            return Ok(ApiResponse<PagedResult<LoaiThietBi>>.Ok(
                pagedResult,
                "Lấy danh sách thành viên thành công"
            ));
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<LoaiThietBi>> GetById(int id)
        {
            LoaiThietBi? thanhVien = _loaiThietBiService.GetById(id);
            if (thanhVien == null)
            {
                return NotFound(ApiResponse<LoaiThietBi>.Fail("Không tìm thấy loại thiết bị!"));
            }

            // ThanhVien dto = new ThanhVien
            // {
            //     Id = thanhVien.Id,
            //     HoTen = thanhVien.HoTen,
            //     Email = thanhVien.Email,
            //     NgaySinh = thanhVien.NgaySinh,
            //     SoDienThoai = thanhVien.SoDienThoai,
            //     TrangThai = thanhVien.TrangThai,
            //     ThoiGianDangKy = thanhVien.ThoiGianDangKy,
            //     Quyen = thanhVien.Quyen,
            // };

            return Ok(ApiResponse<LoaiThietBi>.Ok(thanhVien, "Lấy thông tin thành viên thành công"));
        }

        [HttpPost]
        public ActionResult<ApiResponse<LoaiThietBi>> AddLoaiThietBi([FromBody] LoaiThietBiCreateForm request)
        {
            if (request == null)
            {
                return BadRequest(ApiResponse<LoaiThietBi>.Fail("Dữ liệu không hợp lệ."));
            }

            var loaiThietBi= new LoaiThietBi
            {
                TenLoaiThietBi = request.tenLoaiThietBi,
            };

            // Thêm loại thiết bị
            LoaiThietBi loaiThietBiResponse = _loaiThietBiService.AddLoaiThietBi(loaiThietBi);

            // Trả về phản hồi thành công với data = null
            return Created("", ApiResponse<LoaiThietBi>.Ok(loaiThietBiResponse, "Thêm loại thiết bị thành công."));
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse<LoaiThietBi>> UpdateLoaiThietBi(int id,
            [FromBody] LoaiThietBiUpdateForm request)
        {
            if (request == null)
            {
                return BadRequest(ApiResponse<LoaiThietBi>.Fail("Dữ liệu không hợp lệ."));
            }

            var loaiThietBi = new LoaiThietBi
            {
                Id = id,
                TenLoaiThietBi = request.tenLoaiThietBi
            };

            // Cập nhật loại thiết bị
            LoaiThietBi loaiThietBiResponse = _loaiThietBiService.CapNhatLoaiThietBi(loaiThietBi);

            // Trả về phản hồi thành công với data = null
            return Ok(ApiResponse<LoaiThietBi>.Ok(loaiThietBiResponse, "Cập nhật loại thiết bị thành công."));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<LoaiThietBi>> DeleteLoaiThietBi(int id)
        {
            _loaiThietBiService.XoaLoaiThietBi(id);

            // Trả về phản hồi thành công với data = null
            return Ok(ApiResponse<LoaiThietBi>.Ok(null, "Xóa loại thiết bị thành công."));
        }
        
        [HttpGet("CountThietBi/{id}")]
        public ActionResult<ApiResponse<int>> GetCountLTB(int id){
            int count = _loaiThietBiService.GetCountTB(id);
            return Ok(ApiResponse<int>.Ok(count, "Lấy số lượng thiết bị thành công."));
        }

    }
}