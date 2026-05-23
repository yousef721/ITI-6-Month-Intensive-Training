using System;

namespace Lap02.Shared.Pagination;

public class PaginationParams
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string? Search { get; set; }
}