﻿using Microsoft.EntityFrameworkCore;

namespace OnClocService.Infrastructure.Extensions.Systems;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalItems { get; private set; }
    public int TotalPages { get; private set; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalItems = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    public static async Task<PaginatedList<T>> CreatePaginationAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var item = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(item, count, pageIndex, pageSize);
    }
}
