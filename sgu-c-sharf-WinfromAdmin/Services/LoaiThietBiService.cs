using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.Models;
using sgu_c_sharf_WinfromAdmin.ApiResponse;
using System.Net.Http;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    public class LoaiThietBiService
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "http://localhost:5244/api/loai-thiet-bi";


        public LoaiThietBiService()
        {
            this._httpClient = new HttpClient();
        }


        public async Task<List<LoaiThietbi>> GetAll(int pageNumber = 1, int pageSize = 100){
            string requestUrl = $"{BASE_URL}?pageNumber={pageNumber}&pageSize={pageSize}";
            try
            {
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();
                if( res.IsSuccessStatusCode && !string.IsNullOrEmpty(json)){
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<PagedResult<LoaiThietbi>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (apiResponse?.Data.Content != null)
                        return apiResponse.Data.Content;
                    else
                        return new List<LoaiThietbi>();
                }
                else // lỗi request
                    return new List<LoaiThietbi>();

            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Lỗi JSON: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<LoaiThietbi>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<LoaiThietbi>();
            }
        }
        public async Task<LoaiThietbi> GetById(int id){
            string requestUrl = $"{BASE_URL}/{id}";
            try
            {
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();
                if( res.IsSuccessStatusCode && !string.IsNullOrEmpty(json)){
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<LoaiThietbi>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (apiResponse?.Data != null)
                        return apiResponse.Data;
                    else
                        return new LoaiThietbi();
                }
                else // lỗi request
                    return new LoaiThietbi();

            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Lỗi JSON: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new LoaiThietbi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new LoaiThietbi();
            }
        }

        public async Task<bool> Add(LoaiThietbi ltb){
            string  requestUrl = $"{BASE_URL}";
            try
            {
                
                var jsonContent = JsonSerializer.Serialize(ltb);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage res = await _httpClient.PostAsync(requestUrl, content);
                return res.IsSuccessStatusCode;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Lỗi JSON: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }       
        }

        public async Task<bool> Update(LoaiThietbi ltb){
            string requestUrl = $"{BASE_URL}/{ltb.Id}";
            try
            {
                var jsonContent = JsonSerializer.Serialize(ltb);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage res = await _httpClient.PutAsync(requestUrl, content);
                return res.IsSuccessStatusCode;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Lỗi JSON: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }        
        }
        public async Task<bool> Delete(int id){
            string requestUrl = $"{BASE_URL}/{id}";
            try
            {
                HttpResponseMessage res = await _httpClient.DeleteAsync(requestUrl);
                return res.IsSuccessStatusCode;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Lỗi JSON: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }  
        }
        public async Task<int> GetLastId(){
            string requestUrl = $"{BASE_URL}/lastId";
            try{
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();
                if( res.IsSuccessStatusCode && !string.IsNullOrEmpty(json)){
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<int>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if( apiResponse.Data != null)
                        return apiResponse.Data;
                    else
                        return -1;
                }
            }
            catch (Exception ex){
                Console.WriteLine($"Lỗi: {ex.Message}");
                return -1;
            }
            return -1;
        }

        public async Task<int> CountTB(int id){
            string requestUrl= $"{BASE_URL}/CountThietBi/{id}";
            try{
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json= await res.Content.ReadAsStringAsync();
                if( res.IsSuccessStatusCode && !string.IsNullOrEmpty(json)){
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<int>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (apiResponse.Data != null)
                        return apiResponse.Data;
                    else
                        return -1;
                }
            }
            catch (Exception ex){
                Console.WriteLine($"Lỗi: {ex.Message}");
                return -1;
            }
            return -1;
        }

        public string GetNextIndex(){
            string requestUrl = $"{BASE_URL}/NextIndex";
            try
            {
                HttpResponseMessage res = _httpClient.GetAsync(requestUrl).Result;
                string json = res.Content.ReadAsStringAsync().Result;
                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<string>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (apiResponse.Data != null)
                        return apiResponse.Data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return "";
            }
            return "";
        }

    }
}