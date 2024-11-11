using api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_backend.Models;

public class PagedModelResponse<T>
{
    public PagedModelResponse(T data,int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Data = data;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public bool isFirstpage { get; set; } = false;
    public bool isLastpage { get; set; } = false;
    public T Data { get; set; }
}
