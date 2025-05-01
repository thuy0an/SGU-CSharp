using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.ApiResponse;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class PhieuMuonService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string BASE_URL = "http://localhost:5244/api/phieu-muon";

        public async Task<List<PhieuMuonDetailDTO>> GetAllNoPaging()
        {
            try
            {
                var res = await _httpClient.GetAsync($"{BASE_URL}/nopaging");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<PhieuMuonDetailDTO>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse?.Data ?? new List<PhieuMuonDetailDTO>();
                }
                return new List<PhieuMuonDetailDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PhieuMuonDetailDTO>();
            }
        }

        public async Task<PhieuMuonDetailDTO?> GetById(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync($"{BASE_URL}/{id}");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<PhieuMuonDetailDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return apiResponse?.Data;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy phiếu mượn theo ID: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<int?> Add(PhieuMuonCreateDTO createDTO)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(createDTO);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var res = await _httpClient.PostAsync(BASE_URL, content);
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<int>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return apiResponse?.Data;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> Update(PhieuMuonUpdateDTO phieuMuon)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(phieuMuon);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var res = await _httpClient.PutAsync($"{BASE_URL}/{phieuMuon.Id}", content);
                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<PhieuMuonPagingResponse> GetAllWithPaging(
    int page,
    int limit,
    DateTime? fromDate = null,
    DateTime? toDate = null,
    TrangThaiPhieuMuonEnum? trangThai = null)
        {
            try
            {
                var query = $"?page={page}&limit={limit}";

                // Thêm điều kiện cho ngày bắt đầu và ngày kết thúc
                if (fromDate != null)
                    query += $"&fromDate={fromDate.Value:yyyy-MM-dd}";
                if (toDate != null)
                    query += $"&toDate={toDate.Value:yyyy-MM-dd}";

                // Chuyển đổi enum trangThai thành chuỗi nếu có
                if (trangThai != null)
                    query += $"&trangThai={Enum.GetName(typeof(TrangThaiPhieuMuonEnum), trangThai)}"; // Dùng Enum.GetName để chuyển enum thành chuỗi

                // Gửi yêu cầu API
                var res = await _httpClient.GetAsync($"{BASE_URL}/paging{query}");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    // Xử lý dữ liệu nhận về
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<PhieuMuonPagingResponse>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse.Data ?? new PhieuMuonPagingResponse
                    {
                        Items = new List<PhieuMuonDetailDTO>(),
                        CurrentPage = 1,
                        TotalPages = 1
                    };
                }

                return new PhieuMuonPagingResponse
                {
                    Items = new List<PhieuMuonDetailDTO>(),
                    CurrentPage = 1,
                    TotalPages = 1
                };
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi phân trang phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new PhieuMuonPagingResponse
                {
                    Items = new List<PhieuMuonDetailDTO>(),
                    CurrentPage = 1,
                    TotalPages = 1
                };
            }
        }

    }

}
