using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.Models;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class DauThietBiService
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "http://localhost:5244/api/DauThietBi";

        public DauThietBiService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<DauThietBi>> GetDauThietBiByIdVaSoLuong(int idThietBi, int soLuong)
        {
            string requestUrl = $"{BASE_URL}/{idThietBi}/{soLuong}"; // API endpoint
            try
            {
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<DauThietBi>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse?.Data ?? new List<DauThietBi>();
                }

                return new List<DauThietBi>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<DauThietBi>();
            }
        }
        public async Task<bool> UpdateDanhSachDauThietBi(List<DauThietBi> formList)
        {
            string requestUrl = $"{BASE_URL}/update-danhsach";

            try
            {
                var jsonContent = JsonSerializer.Serialize(formList);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await _httpClient.PutAsync(requestUrl, httpContent);
                string json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<object>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse != null && apiResponse.Status == 200;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public async Task<DauThietBiDetailResponseDto> GetDauThietBiById(int id)
        {
            string requestUrl = $"{BASE_URL}/{id}";

            try
            {
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<DauThietBiDetailResponseDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse.Data;
                }

                return new DauThietBiDetailResponseDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new DauThietBiDetailResponseDto();
            }
        }
    }
}

    