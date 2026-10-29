using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KarataClub.Domain.Common.Models;

public sealed class PaginatedList<T>
{
    public List<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int PageNumber { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    [JsonConstructor]
    public PaginatedList(List<T> items, int pageNumber,bool hasNextPage,bool hasPreviousPage,int totalPages)
    {
        Items = items;
        TotalPages = totalPages;
        PageNumber = pageNumber;
        this.HasNextPage = hasNextPage;
        this.HasPreviousPage = hasPreviousPage;
    }
    public PaginatedList(List<T>items,int pageNumber,int pageSize,int count)
    {
        this.Items = items;
        this.PageNumber = pageNumber;
        this.TotalPages =(int)Math.Ceiling((decimal) count / pageSize);
        HasNextPage = pageNumber < TotalPages;
        HasPreviousPage = pageNumber > 1;
    }

    public static  async Task<Result<PaginatedList<T>>> Create(IQueryable<T> items, int pageNumber=1, int pageSize=10)
    {
        List<T> itemList =await items.Skip((pageNumber - 1) *pageSize)
            .Take(pageSize).ToListAsync();
        int count=items.Count();
        return new PaginatedList<T>(itemList,pageNumber,pageSize,count);
    }
}
