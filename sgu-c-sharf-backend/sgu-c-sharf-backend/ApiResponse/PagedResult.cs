namespace sgu_c_sharf_backend.ApiResponse;

public class PagedResult<T>
{
    public List<T> Content { get; set; } = new();
    public int TotalElements { get; set; }
    public int TotalPages { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PagedResult(List<T> content, int totalElements, int pageNumber, int pageSize)
    {
        Content = content;
        TotalElements = totalElements;
        PageSize = pageSize;
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling((double)totalElements / pageSize);
    }
}
