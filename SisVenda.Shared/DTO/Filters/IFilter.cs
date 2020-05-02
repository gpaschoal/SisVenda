namespace SisVenda.Shared.DTO.Filters
{
    public interface IFilter
    {
        int RowsByPage { get; set; }
        int PageNumber { get; set; }
    }
}
