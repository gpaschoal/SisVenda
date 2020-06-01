namespace SisVenda.Shared.DTO.Filters
{
    public class ProductsFilter : IFilter
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }

        public void Normalize()
        {
            Name ??= "";
            Description ??= "";
        }
    }
}