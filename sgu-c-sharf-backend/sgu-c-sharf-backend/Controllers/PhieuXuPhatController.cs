using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sgu_c_sharf_backend.Models.PhieuXuPhat;
using sgu_c_sharf_backend.Services;
using sgu_c_sharf_backend.ApiResponse;


namespace sgu_c_sharf_backend.Controllers

{
    [Route("api/phieu-xu-phat")]
    [ApiController]
    public class PhieuXuPhatController : ControllerBase

    {
        private readonly PhieuXuPhatService _phieuXuPhatService;


        public PhieuXuPhatController(PhieuXuPhatService phieuXuPhatService)

        {
            _phieuXuPhatService = phieuXuPhatService;
        }


// Lấy danh sách phiếu xử phạt không có phân trang

        [HttpGet("nopaging")]
        public ActionResult<List<PhieuXuPhatDetailDTO>> GetAllNoPaging()

        {
            try

            {
                var result = _phieuXuPhatService.GetAll();

                return Ok(ApiResponse<List<PhieuXuPhatDetailDTO>>.Ok(result));
            }

            catch (Exception ex)

            {
                return BadRequest(new { Message = ex.Message });
            }
        }


// Lấy danh sách phiếu xử phạt với phân trang

        [HttpGet("paging")]
        public ActionResult<object> GetAllWithPaging(
            int page = 1,
            int limit = 10,
            TrangThaiPhieuXuPhatEnum? trangThai = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            string? keyword = null)

        {
            try

            {
                var result = _phieuXuPhatService.GetAllPaging(page, limit, trangThai, fromDate, toDate, keyword);

                var response = new

                {
                    Data = result,

                    Message = "Thành công",

                    Status = 200
                };

                return Ok(response);
            }

            catch (Exception ex)

            {
                return BadRequest(new { Message = $"Lỗi: {ex.Message}", Status = 400 });
            }
        }


        [HttpGet("user/{id}")]
        public ActionResult<List<PhieuXuPhatDetailDTO>> GetByIdUser(uint id)

        {
            try

            {
                var result = _phieuXuPhatService.GetByIdUser(id);

                if (result == null)

                {
                    return NotFound(new { Message = "Không tìm thấy phiếu xử phạt" });
                }

                return Ok(ApiResponse<List<PhieuXuPhatDetailDTO>>.Ok(result));
            }

            catch (Exception ex)

            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PhieuXuPhatDetailDTO> GetById(uint id)

        {
            try

            {
                var result = _phieuXuPhatService.GetById(id);

                if (result == null)

                {
                    return NotFound(new { Message = "Không tìm thấy phiếu xử phạt" });
                }

                return Ok(ApiResponse<PhieuXuPhatDetailDTO>.Ok(result));
            }

            catch (Exception ex)

            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<uint> Add([FromForm] PhieuXuPhatCreateDTO pxp)

        {
            try

            {
                if (pxp == null)

                {
                    return BadRequest(new { Message = "Dữ liệu không hợp lệ" });
                }


                var result = _phieuXuPhatService.Add(pxp);

                var response = new

                {
                    Message = "Thành công",

                    Status = 201
                };

                return Ok(response);
            }

            catch (Exception ex)

            {
                return BadRequest(new { Message = ex.Message });
            }
        }


// Cập nhật phiếu xử phạt

        [HttpPut("{id}")]
        public ActionResult<bool> Update(uint id, [FromForm] PhieuXuPhatUpdateDTO phieuXuPhat)

        {
            try

            {
                if (phieuXuPhat == null)

                {
                    return BadRequest(new { Message = "Dữ liệu không hợp lệ" });
                }

                var result = _phieuXuPhatService.Update(id, phieuXuPhat);

                if (!result)

                {
                    return NotFound(new { Message = "Không tìm thấy phiếu xử phạt để cập nhật" });
                }

                return Ok(result);
            }

            catch (Exception ex)

            {
                return BadRequest(new { Message = ex.Message });
            }
        }


// Xóa phiếu xử phạt

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(uint id)

        {
            try

            {
                var result = _phieuXuPhatService.Delete(id);

                if (!result)

                {
                    return NotFound(new { Message = "Không tìm thấy phiếu xử phạt để xóa" });
                }

                return Ok(result);
            }

            catch (Exception ex)

            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }


    public class PhieuXuPhatPagingResponse

    {
        public List<PhieuXuPhatDetailDTO> Items { get; set; }

        public int TotalItems { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; }
    }
}