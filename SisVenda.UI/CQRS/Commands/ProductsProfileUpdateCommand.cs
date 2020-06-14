namespace SisVenda.UI.CQRS.Commands
{
    public class ProductsProfileUpdateCommand : IUpdateCommand
    {
        public string Id { get; set; }
        public string UnitMeasurementId { get; set; }
        public string ProductsId { get; set; }
        public string BarCode { get; set; }
    }
}
