using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.ApiResponse;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class TrangThaiPhieuMuonService
    {
        private readonly HttpClient _httpClient;
        private string BASE_URL = "http://localhost:5244/api/trang-thai-phieu-muon";

        public TrangThaiPhieuMuonService()
        {
            this._httpClient = new HttpClient();
        }

        // Lấy danh sách trạng thái phiếu mượn theo IdPhiếuMượn
        public async Task<List<TrangThaiPhieuMuonDetailDTO>> GetByPhieuMuonId(int idPhieuMuon)
        {
            string requestUrl = $"{BASE_URL}/phieu-muon/{idPhieuMuon}";
            try
            {
                // Gửi yêu cầu GET đến API  
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<TrangThaiPhieuMuonDetailDTO>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    // trả về danh sách có dữ liệu
                    if (apiResponse?.Data != null)
                        return apiResponse.Data;
                    // nếu không có dữ liệu thì trả về danh sách rỗng
                    else
                        return new List<TrangThaiPhieuMuonDetailDTO>();
                }
                else // lỗi request
                    return new List<TrangThaiPhieuMuonDetailDTO>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Lỗi JSON: {jsonEx.Message}");
                return new List<TrangThaiPhieuMuonDetailDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<TrangThaiPhieuMuonDetailDTO>();
            }
        }

        // Lấy trạng thái mới nhất của phiếu mượn
        public async Task<TrangThaiPhieuMuonDetailDTO?> GetTrangThaiMoiNhat(int idPhieuMuon)
        {
            string requestUrl = $"{BASE_URL}/phieu-muon/{idPhieuMuon}/moi-nhat";    
            try
            {
                // Gửi yêu cầu GET đến API
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<TrangThaiPhieuMuonDetailDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return apiResponse.Data;
                }
                else // lỗi request
                    return null;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Lỗi JSON: {jsonEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        // Thêm trạng thái phiếu mượn
        public async Task<bool> Add(TrangThaiPhieuMuonCreateDTO trangThai)
        {
            string requestUrl = $"{BASE_URL}";
            try
            {
                var jsonContent = JsonSerializer.Serialize(trangThai);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST đến API
                HttpResponseMessage res = await _httpClient.PostAsync(requestUrl, content);
                return res.IsSuccessStatusCode;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Lỗi JSON: {jsonEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }
    }
}
