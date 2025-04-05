namespace sgu_c_sharf_WinfromAdmin.ApiResponse
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(){
            
        }

        private ApiResponse(int status, T data, string message)
        {
            Status = status;
            Data = data;
            Message = message;
        }

        public static ApiResponse<T> Ok(T data, string message = "Thành công")
        {
            return new ApiResponse<T>(200, data, message);
        }

        public static ApiResponse<T?> Fail(string message)
        {
            return new ApiResponse<T?>(400, default, message);
        }
    }
}