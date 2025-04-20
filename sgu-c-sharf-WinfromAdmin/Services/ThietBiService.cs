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
	public class ThietBiService
	{
		private readonly HttpClient _httpClient;
		private const string BASE_URL = "http://localhost:5244/api/ThietBi";

		public ThietBiService()
		{
			this._httpClient = new HttpClient();
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
					if (apiResponse?.Data != null)
						return apiResponse.Data;
					else
						return new List<ThietBi>();
				}
				else
					return new List<ThietBi>();
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"JSON Error: {ex.Message}");
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
					if (apiResponse?.Data != null)
						return apiResponse.Data;
					else
						return new ThietBi();
				}
				else
					return new ThietBi();
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"JSON Error: {ex.Message}");
				return new ThietBi();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return new ThietBi();
			}
		}

		public async Task<bool> Add(ThietBi thietBi)
		{
			string requestUrl = $"{BASE_URL}";
			try
			{
				var jsonContent = JsonSerializer.Serialize(new { TenThietBi = thietBi.TenThietBi, IdLoaiThietBi = thietBi.Id });
				var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage res = await _httpClient.PostAsync(requestUrl, content);
				return res.IsSuccessStatusCode;
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"JSON Error: {ex.Message}");
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return false;
			}
		}

		public async Task<bool> Update(int id, ThietBi thietBi)
		{
			string requestUrl = $"{BASE_URL}/{id}";
			try
			{
				var jsonContent = JsonSerializer.Serialize(new { TenThietBi = thietBi.TenThietBi, IdLoaiThietBi = thietBi.Id });
				var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage res = await _httpClient.PutAsync(requestUrl, content);
				return res.IsSuccessStatusCode;
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"JSON Error: {ex.Message}");
				return false;
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
			catch (JsonException ex)
			{
				Console.WriteLine($"JSON Error: {ex.Message}");
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return false;
			}
		}

		//public async Task<int> CountDauThietBi(int id)
		//{
		//	string requestUrl = $"{BASE_URL}/CountDauThietBi/{id}";
		//	try
		//	{
		//		HttpResponseMessage res = await _httpClient.GetAsync(requestUrl);
		//		string json = await res.Content.ReadAsStringAsync();
		//		if (res.IsSuccessStatusCode && !string.IsNullOrEmpty(json))
		//		{
		//			var apiResponse = JsonSerializer.Deserialize<ApiResponse<int>>(json, new JsonSerializerOptions
		//			{
		//				PropertyNameCaseInsensitive = true
		//			});
		//			if (apiResponse?.Data != null)
		//				return apiResponse.Data;
		//			else
		//				return -1;
		//		}
		//		return -1;
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine($"Error: {ex.Message}");
		//		return -1;
		//	}
		//}
	}
}