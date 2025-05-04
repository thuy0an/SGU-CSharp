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
        public async Task<PhieuXuPhatPagingResponse> GetAllPagingAsync(int page = 1, int limit = 10,
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
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<PhieuXuPhatPagingResponse>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return apiResponse?.Data ?? new PhieuXuPhatPagingResponse();
            }
            return new PhieuXuPhatPagingResponse();
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
            content.Add(new StringContent(dto.IdThanhVien.ToString()), "IdThanhVien");
            content.Add(new StringContent(dto.MoTa), "MoTa");
            content.Add(new StringContent(dto.NgayViPham.ToString("yyyy-MM-dd")), "NgayViPham");
            content.Add(new StringContent(dto.TrangThai.ToString()), "TrangThai");

            if (dto.ThoiHanXuPhat.HasValue)
                content.Add(new StringContent(dto.ThoiHanXuPhat.Value.ToString()), "ThoiHanXuPhat");

            if (dto.MucPhat.HasValue)
                content.Add(new StringContent(dto.MucPhat.Value.ToString()), "MucPhat");

            var response = await _httpClient.PostAsync(BASE_URL, content);

            return response.IsSuccessStatusCode; // Kiểm tra xem yêu cầu có thành công không
        }

        // Cập nhật
        public async Task<bool> UpdateAsync(uint id, PhieuXuPhatUpdateDTO dto)
        {
            var jsonContent = JsonSerializer.Serialize(dto); // Chuyển DTO thành JSON
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"); // Định dạng content là application/json

            var response = await _httpClient.PutAsync($"{BASE_URL}/{id}", content); // Gửi yêu cầu PUT

            return response.IsSuccessStatusCode; // Kiểm tra xem yêu cầu có thành công không
        }

        // Xoá
        public async Task<bool> DeleteAsync(uint id)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
