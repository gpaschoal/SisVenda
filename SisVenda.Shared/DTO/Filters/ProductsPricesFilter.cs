namespace SisVenda.Shared.DTO.Filters
{
    public class ProductsPricesFilter : IFilter
    {
        public string ProductsProfileId { get; set; }
        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }

        public void Normalize()
        {
            ProductsProfileId ??= "";
        }
    }
}
