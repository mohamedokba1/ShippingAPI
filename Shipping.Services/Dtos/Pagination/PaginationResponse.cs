namespace Shipping.Services.Dtos;

public class PaginationResponse<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public int PageNo { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
}
