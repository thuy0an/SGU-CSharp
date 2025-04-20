using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.ApiResponse;
using System.Linq;


namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class ThanhVienService
    {
        private readonly HttpClient _httpClient;
        private string BASE_URL = "http://localhost:5244/api/thanh-vien";

        public ThanhVienService()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<List<ThanhVien>> GetAll(int pageNumber = 1, int pageSize = 100){
            string requestUrl = $"{BASE_URL}?pageNumber={pageNumber}&pageSize={pageSize}";
            try
            {
                // Gửi yêu cầu GET đến API  
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<PagedResult<ThanhVien>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    // trả về danh sách có dữ liệu
                    if (apiResponse?.Data?.Content != null)
                        return apiResponse.Data.Content;
                    // nếu không có dữ liệu thì trả về danh sách rỗng
                    else
                        return new List<ThanhVien>();
                }
                else // lỗi request
                    return new List<ThanhVien>();

            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Lỗi JSON: {jsonEx.Message}");
                return new List<ThanhVien>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<ThanhVien>();
            }
        }


        public async Task<ThanhVien?> GetById(int id){
            string requestUrl = $"{BASE_URL}/{id}";
            try
            {
                // Gửi yêu cầu GET đến API
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<ThanhVien>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return apiResponse.Data;
                }
                else // lỗi request
                    return new ThanhVien();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Lỗi JSON: {jsonEx.Message}");
                return new ThanhVien();
            }            
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new ThanhVien();
            }
        }

        public async Task<bool> Update(ThanhVien thanhVien)
        {
            string requestUrl = $"{BASE_URL}/{thanhVien.Id}";
            try
            {
                // Chuyển đổi đối tượng thành JSON
                var jsonContent = JsonSerializer.Serialize(thanhVien);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Gửi yêu cầu PUT đến API
                HttpResponseMessage res = await _httpClient.PutAsync(requestUrl, content);
                return res.IsSuccessStatusCode;
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show($"Lỗi JSON: {jsonEx.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> Add(ThanhVien thanhVien){
            string requestUrl = $"{BASE_URL}/register";
            try {
                var jsonContent = JsonSerializer.Serialize(thanhVien);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage res = await _httpClient.PostAsync(requestUrl, content);
                return res.IsSuccessStatusCode;
            }
            catch (JsonException jsonEx) {
                MessageBox.Show($"Lỗi JSON: {jsonEx.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex) {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }

}