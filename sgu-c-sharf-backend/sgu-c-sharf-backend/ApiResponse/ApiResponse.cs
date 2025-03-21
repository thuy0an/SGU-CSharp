namespace sgu_c_sharf_backend.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        private ApiResponse(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public static ApiResponse<T> Ok(T data, string message = "Thành công")
        {
            return new ApiResponse<T>(true, data, message);
        }

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>(false, default, message);
        }
    }
}