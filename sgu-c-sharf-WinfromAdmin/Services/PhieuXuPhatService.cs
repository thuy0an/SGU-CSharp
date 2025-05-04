using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.ApiResponse;
using sgu_c_sharf_WinfromAdmin.Models;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class PhieuXuPhatService
    {
        private readonly HttpClient _httpClient;
        private string BASE_URL = "http://localhost:5244/api/phieu-xu-phat";
        public PhieuXuPhatService()
        {
            this._httpClient = new HttpClient();
        }
        // Lấy tất cả không phân trang
        public async Task<List<PhieuXuPhatDetailDTO>> GetAllNoPagingAsync()
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/nopaging");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<PhieuXuPhatDetailDTO>>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return apiResponse?.Data ?? new List<PhieuXuPhatDetailDTO>();
            }
            return new List<PhieuXuPhatDetailDTO>();
        }

        // Lấy danh sách có phân trang
        public async Task<PagedResult<PhieuXuPhatDetailDTO>> GetAllPagingAsync(int page = 1, int limit = 10,
            TrangThaiPhieuXuPhatEnum? trangThai = null, DateTime? fromDate = null, DateTime? toDate = null, string? keyword = null)
        {
            var query = $"?page={page}&limit={limit}";
            if (trangThai.HasValue) query += $"&trangThai={trangThai.Value}";
            if (fromDate.HasValue) query += $"&fromDate={fromDate.Value:yyyy-MM-dd}";
            if (toDate.HasValue) query += $"&toDate={toDate.Value:yyyy-MM-dd}";
            if (!string.IsNullOrEmpty(keyword)) query += $"&keyword={Uri.EscapeDataString(keyword.ToLower())}";

            var response = await _httpClient.GetAsync($"{BASE_URL}/paging{query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultObj = JsonSerializer.Deserialize<PagedResult<PhieuXuPhatDetailDTO>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return resultObj ?? new PagedResult<PhieuXuPhatDetailDTO>();
            }
            return new PagedResult<PhieuXuPhatDetailDTO>();
        }

        // Lấy theo ID
        public async Task<PhieuXuPhatDetailDTO?> GetByIdAsync(uint id)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<PhieuXuPhatDetailDTO>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return apiResponse?.Data;
            }
            return null;
        }

        // Thêm mới
        public async Task<bool> AddAsync(PhieuXuPhatCreateDTO dto)
        {
            var content = new MultipartFormDataContent();
            // Add các field của dto vào content (giả sử dto là các property primitive)
            content.Add(new StringContent(dto.TienPhat.ToString()), "TienPhat");
            content.Add(new StringContent(dto.LyDo ?? ""), "LyDo");
            content.Add(new StringContent(dto.NgayLap?.ToString("yyyy-MM-dd") ?? ""), "NgayLap");
            content.Add(new StringContent(dto.IdThanhVien.ToString()), "IdThanhVien");

            var response = await _httpClient.PostAsync(BASE_URL, content);
            return response.IsSuccessStatusCode;
        }

        // Cập nhật
        public async Task<bool> UpdateAsync(uint id, PhieuXuPhatUpdateDTO dto)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(dto.TienPhat.ToString()), "TienPhat");
            content.Add(new StringContent(dto.LyDo ?? ""), "LyDo");
            content.Add(new StringContent(dto.NgayCapNhat?.ToString("yyyy-MM-dd") ?? ""), "NgayCapNhat");
            if (dto.IdThanhVien.HasValue)
                content.Add(new StringContent(dto.IdThanhVien.Value.ToString()), "IdThanhVien");

            var response = await _httpClient.PutAsync($"{BASE_URL}/{id}", content);
            return response.IsSuccessStatusCode;
        }

        // Xoá
        public async Task<bool> DeleteAsync(uint id)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
