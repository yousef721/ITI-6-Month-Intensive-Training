using System;

namespace Lap02.Shared.Pagination;

public class PaginationResponse<T>
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public int TotalPages { get; set; }

    public List<T> Data { get; set; } = new();
}
