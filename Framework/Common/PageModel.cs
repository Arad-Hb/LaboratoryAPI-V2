using System.Text.Json.Serialization;

namespace Laboratory.Framework.Common;

/// <summary>
/// مدل درخواست صفحه‌بندی ارسالی از کلاینت
/// </summary>
public class PageRequest
{
    private int _pageNumber = 1;
    private int _pageSize = 10;
    private const int MaxPageSize = 100;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : (value < 1 ? 10 : value);
    }

    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; } = "Id";
    public bool IsAscending { get; set; } = false;
}

/// <summary>
/// مدل کپسوله‌شده نتیجه لیست‌های صفحه‌بندی شده
/// </summary>
/// <typeparam name="T">نوع موجودیت یا DTO بازگشتی</typeparam>
public class PagedResult<T>
{
    [JsonPropertyName("items")]
    public IReadOnlyList<T> Items { get; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; }

    [JsonPropertyName("totalCount")]
    public int TotalCount { get; }

    [JsonPropertyName("totalPages")]
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    [JsonPropertyName("hasPreviousPage")]
    public bool HasPreviousPage => CurrentPage > 1;

    [JsonPropertyName("hasNextPage")]
    public bool HasNextPage => CurrentPage < TotalPages;

    public PagedResult(IReadOnlyList<T> items, int totalCount, int currentPage, int pageSize)
    {
        Items = items ?? new List<T>();
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
}
