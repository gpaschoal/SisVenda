namespace SisVenda.UI.CQRS.Responses
{
    public class ProductsProfileResponse : IResponse
    {
        public string Id { get; private set; }
        public string UnitMeasurementId { get; private set; }
        public string UnitMeasurementName { get; private set; }
        public string ProductsId { get; private set; }
        public string ProductsName { get; private set; }
        public string BarCode { get; private set; }
    }
}
