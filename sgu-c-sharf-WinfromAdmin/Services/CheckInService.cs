using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.ApiResponse;
using sgu_c_sharf_WinfromAdmin.Models;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class CheckInService
    {
        private readonly HttpClient _httpClient;
        private string BASE_URL = "http://localhost:5244/api/check-in";

        public CheckInService(){
            this._httpClient = new HttpClient();
        }

        public async Task<List<CheckIn>> GetAll(int idTV){
            string requestUrl = $"{BASE_URL}/{idTV}";
            try
            {
                HttpResponseMessage res =  await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<CheckIn>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (apiResponse?.Data != null)
                        return apiResponse.Data;
                    else
                        return new List<CheckIn>();
                }
                else // lỗi request
                    return new List<CheckIn>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Lỗi JSON: {jsonEx.Message}");
                return new List<CheckIn>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<CheckIn>();
            }
        }

        public async Task<string> AddCheckIn(int idTV){
            string requestUrl = $"{BASE_URL}";
            CheckIn checkIn = new CheckIn();
            checkIn.IdThanhVien = idTV;
            checkIn.ThoiGianCheckIn = DateTime.Now;
            try
            {
                var json = JsonSerializer.Serialize(checkIn);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _httpClient.PostAsync(requestUrl, content);
                if (res.IsSuccessStatusCode)
                    return checkIn.ThoiGianCheckIn.ToString("dd/MM/yyyy HH:mm:ss");
                else
                    return "";
            }
            catch (JsonException jsonEx) {
                MessageBox.Show($"Lỗi JSON: {jsonEx.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            catch (Exception ex) {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}