namespace SisVenda.UI.CQRS.Filters
{
    public class UnitMeasurementFilter : IFilter
    {
        public string Name { get; set; }
        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }
    }
}
