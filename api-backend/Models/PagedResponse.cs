using api_backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public sealed class PagedResponse
    {
        public static PagedModelResponse<IEnumerable<T>> CreatePagedReponse<T, C>(IEnumerable<T> pagedData, GenericPaginationModel<C> validFilter, int totalRecords)
        {
            var respose = new PagedModelResponse<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            if (validFilter.PageNumber == roundedTotalPages)
            {
                respose.isLastpage = true;
            }

            if (validFilter.PageNumber == 1)
            {
                respose.isFirstpage = true;
            }

            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }

    }
}