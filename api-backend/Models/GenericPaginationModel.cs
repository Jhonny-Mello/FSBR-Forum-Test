using System.ComponentModel.DataAnnotations;

namespace api.Models;
public class GenericPaginationModel<T>
{
    public GenericPaginationModel()
    {
    }

    public GenericPaginationModel(T value, int pageNumber = 0, int pageSize = 0)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Value = value ;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    [Required]
    public T Value { get; set; } = default!;
}
