using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.ApiResponse;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class ChiTietPhieuMuonService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string BASE_URL = "http://localhost:5244/api/chi-tiet-phieu-muon";

        // Lấy tất cả chi tiết theo Id phiếu mượn
        public async Task<List<ChiTietPhieuMuonDetailDTO>> GetAllByPhieuMuonId(int idPhieuMuon)
        {
            try
            {
                var res = await _httpClient.GetAsync($"{BASE_URL}?idPhieuMuon={idPhieuMuon}");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<ChiTietPhieuMuonDetailDTO>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse?.Data ?? new List<ChiTietPhieuMuonDetailDTO>();
                }

                return new List<ChiTietPhieuMuonDetailDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy chi tiết phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ChiTietPhieuMuonDetailDTO>();
            }
        }

        // Lấy chi tiết theo Id phiếu mượn + Id đầu thiết bị
        public async Task<ChiTietPhieuMuonDetailDTO?> GetByPhieuMuonIdAndDauThietBiId(int idPhieuMuon, int idDauThietBi)
        {
            try
            {
                var res = await _httpClient.GetAsync($"{BASE_URL}/{idPhieuMuon}/{idDauThietBi}");
                var json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<ChiTietPhieuMuonDetailDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse?.Data;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy chi tiết theo ID kép: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Thêm mới danh sách chi tiết
        public async Task<bool> Add(List<ChiTietPhieuMuonCreateDTO> list)
        {
            try
            {
                var json = JsonSerializer.Serialize(list);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await _httpClient.PostAsync(BASE_URL, content);
                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm chi tiết phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật danh sách chi tiết
        public async Task<bool> Update(List<ChiTietPhieuMuonUpdateDTO> list)
        {
            try
            {
                var json = JsonSerializer.Serialize(list);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await _httpClient.PutAsync(BASE_URL, content);
                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật chi tiết phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Xóa danh sách chi tiết
        public async Task<bool> Delete(List<ChiTietPhieuMuonDeleteDTO> list)
        {
            try
            {
                var json = JsonSerializer.Serialize(list);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(BASE_URL),
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                var res = await _httpClient.SendAsync(request);
                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa chi tiết phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
