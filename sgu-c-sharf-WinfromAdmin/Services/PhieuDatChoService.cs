using sgu_c_sharf_WinfromAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.ApiResponse;
using System.Net.Http;

namespace sgu_c_sharf_WinfromAdmin.Services
{
    internal class PhieuDatChoService
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "http://localhost:5244/api/phieu-dat-cho";

        public PhieuDatChoService()
        {
            this._httpClient = new HttpClient();
        }


        // getAll
        public List<PhieuDatCho> GetAll()
        {
            string reqUrl = $"{BASE_URL}";
            try
            {
                HttpResponseMessage res = _httpClient.GetAsync(reqUrl).Result;
                string json = res.Content.ReadAsStringAsync().Result;
                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<PhieuDatCho>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if( apiResponse?.Data!= null)
                        return apiResponse.Data;
                    else
                        return new List<PhieuDatCho>();
                }
                else // lỗi request
                    return new List<PhieuDatCho>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Lỗi JSON: {ex.Message}");
                return new List<PhieuDatCho>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<PhieuDatCho>();
            }

        }
    }

    // getByID


    // cập nhật

    // xóa
}
