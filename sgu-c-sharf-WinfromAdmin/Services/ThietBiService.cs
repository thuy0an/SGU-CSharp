using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using sgu_c_sharf_WinfromAdmin.Models;

namespace sgu_c_sharf_WinfromAdmin.Services
{
	public class ApiResponse<T>
	{
		public int Status { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
	}

	public class ServiceResult
	{
		public bool Success { get; set; }
		public string ErrorMessage { get; set; }
	}

	public class ThietBiService
	{
		private readonly HttpClient _httpClient;
		private const string BASE_URL = "http://localhost:5244/api/ThietBi";

		public ThietBiService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<List<ThietBi>> GetAll(int pageNumber = 1, int pageSize = 100)
		{
			string requestUrl = $"{BASE_URL}?pageNumber={pageNumber}&pageSize={pageSize}";
			try
			{
				HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
				string json = await res.Content.ReadAsStringAsync();
				if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
				{
					var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<ThietBi>>>(json, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
					return apiResponse?.Data ?? new List<ThietBi>();
				}
				return new List<ThietBi>();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return new List<ThietBi>();
			}
		}

		public async Task<ThietBi> GetById(int id)
		{
			string requestUrl = $"{BASE_URL}/{id}";
			try
			{
				HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
				string json = await res.Content.ReadAsStringAsync();
				if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
				{
					var apiResponse = JsonSerializer.Deserialize<ApiResponse<ThietBi>>(json, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
					return apiResponse?.Data ?? new ThietBi();
				}
				return new ThietBi();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return new ThietBi();
			}
		}

		public async Task<ServiceResult> Add(ThietBiCreateDTO thietBi)
		{
			string requestUrl = BASE_URL;
			try
			{
				var jsonContent = JsonSerializer.Serialize(thietBi);
				var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
				HttpResponseMessage res = await _httpClient.PostAsync(requestUrl, content);
				string jsonResponse = await res.Content.ReadAsStringAsync();

				var apiResponse = JsonSerializer.Deserialize<ApiResponse<ThietBiCreateDTO>>(jsonResponse, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				if (res.IsSuccessStatusCode)
				{
					return new ServiceResult { Success = true };
				}
				else
				{
					return new ServiceResult
					{
						Success = false,
						ErrorMessage = apiResponse?.Message ?? "Lỗi không xác định từ server"
					};
				}
			}
			catch (Exception ex)
			{
				return new ServiceResult
				{
					Success = false,
					ErrorMessage = $"Lỗi hệ thống: {ex.Message}"
				};
			}
		}

		public async Task<bool> Update(int id, ThietBi thietBi)
		{
			string requestUrl = $"{BASE_URL}/{id}";
			try
			{
				var jsonContent = JsonSerializer.Serialize(new { TenThietBi = thietBi.TenThietBi, IdLoaiThietBi = thietBi.IdLoaiThietBi });
				var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
				HttpResponseMessage res = await _httpClient.PutAsync(requestUrl, content);
				return res.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return false;
			}
		}

		public async Task<bool> Delete(int id)
		{
			string requestUrl = $"{BASE_URL}/{id}";
			try
			{
				HttpResponseMessage res = await _httpClient.DeleteAsync(requestUrl);
				return res.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return false;
			}
		}


        public async Task<bool> AddDauThietBi(int idTB, int soluong){
			string requestUrl = $"{BASE_URL}/ThemDauThietBi/{idTB}";
			try
			{
				var jsonContent = JsonSerializer.Serialize(new { SoLuong = soluong });
				var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
				HttpResponseMessage res = await _httpClient.PostAsync(requestUrl, content);
				return res.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return false;
			} 
        }



		public async Task<List<DauThietBi>> GetDauThietBiByThietBiId(int thietBiId)
		{
			string requestUrl = $"{BASE_URL}/{thietBiId}/dau-thiet-bi";
			try
			{
				HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
				string json = await res.Content.ReadAsStringAsync();
				if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
				{
					var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<DauThietBi>>>(json, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true,
						Converters = { new JsonStringEnumConverter() }
					});
					return apiResponse?.Data?.ToList() ?? new List<DauThietBi>();
				}
				return new List<DauThietBi>();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return new List<DauThietBi>();
			}
		}

        public async Task<List<ThietBiListAvailabilityDTO>> GetAllWithAvailability()
        {
            string requestUrl = $"{BASE_URL}/kha-dung"; // URL API lấy danh sách có kiểm tra khả dụng
            try
            {
                HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
                string json = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
                {
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<ThietBiListAvailabilityDTO>>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse?.Data ?? new List<ThietBiListAvailabilityDTO>();
                }

                return new List<ThietBiListAvailabilityDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<ThietBiListAvailabilityDTO>();
            }
        }

		public async Task<List<DauThietBi>> GetDauThietBi()
		{
			string requestUrl = $"http://localhost:5244/api/DauThietBi";
			try
			{
				HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
				string json = await res.Content.ReadAsStringAsync();

				if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
				{
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					};
					var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<DauThietBi>>>(json, options);

					return apiResponse?.Data ?? new List<DauThietBi>();
				}
				else
				{
					Console.WriteLine($"Request failed: StatusCode={res.StatusCode}, ReasonPhrase={res.ReasonPhrase}");
					return new List<DauThietBi>();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return new List<DauThietBi>();
			}
		}
    }
}