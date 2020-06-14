namespace SisVenda.UI.CQRS.Commands
{
    public class ProductsProfileCreateCommand : ICreateCommand
    {
        public string UnitMeasurementId { get; set; }
        public string ProductsId { get; set; }
        public string BarCode { get; set; }
    }
}
