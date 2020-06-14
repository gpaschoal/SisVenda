namespace SisVenda.UI.CQRS.Filters
{
    public class ProductsProfileFilter : IFilter
    {
        public string ProductsId { get; set; }
        public string BarCode { get; set; }
        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }
    }
}
