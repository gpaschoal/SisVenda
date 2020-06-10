namespace SisVenda.UI.CQRS.Commands
{
    public class UnitMeasurementCreateCommand
    {
        public string Name { get; set; }
        public decimal QuantityLosses { get; set; }
    }
}
