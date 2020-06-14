namespace SisVenda.UI.CQRS.Commands
{
    public class UnitMeasurementCreateCommand : ICreateCommand
    {
        public string Name { get; set; }
        public decimal QuantityLosses { get; set; }
    }
}
