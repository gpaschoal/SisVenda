namespace SisVenda.UI.CQRS.Filters
{
    public interface IFilter
    {
        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }
    }
}