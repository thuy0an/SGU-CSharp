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

        public async Task<List<PhieuMuon>> GetAllNoPaging()
        {
            try
            {
                var res = await _httpClient.GetAsync($"{BASE_URL}/nopaging");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<PhieuMuon>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse?.Data ?? new List<PhieuMuon>();
                }
                return new List<PhieuMuon>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PhieuMuon>();
            }
        }

        public async Task<PhieuMuon?> GetById(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync($"{BASE_URL}/{id}");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<PhieuMuon>>(json, new JsonSerializerOptions
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

        public async Task<bool> Update(PhieuMuon phieuMuon)
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

        public async Task<(List<PhieuMuon> items, int currentPage, int totalPages)> GetAllWithPaging(int page, int limit, DateTime? fromDate = null, DateTime? toDate = null, int? trangThai = null)
        {
            try
            {
                var query = $"?page={page}&limit={limit}";
                if (fromDate != null)
                    query += $"&fromDate={fromDate.Value:yyyy-MM-dd}";
                if (toDate != null)
                    query += $"&toDate={toDate.Value:yyyy-MM-dd}";
                if (trangThai != null)
                    query += $"&trangThai={trangThai}";

                var res = await _httpClient.GetAsync($"{BASE_URL}/paging{query}");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<PhieuMuonPagingResponse>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return (apiResponse.Data.Items, apiResponse.Data.CurrentPage, apiResponse.Data.TotalPages);
                }

                return (new List<PhieuMuon>(), 1, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phân trang phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (new List<PhieuMuon>(), 1, 1);
            }
        }
    }

}
