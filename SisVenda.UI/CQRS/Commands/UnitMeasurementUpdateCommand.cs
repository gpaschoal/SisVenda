using SisVenda.UI.CQRS.Responses;

namespace SisVenda.UI.CQRS.Commands
{
    public class UnitMeasurementUpdateCommand
    {
        public UnitMeasurementUpdateCommand() { }
        public UnitMeasurementUpdateCommand(UnitMeasurementResponse response)
        {
            Id = response.Id;
            Name = response.Name;
            QuantityLosses = response.QuantityLosses;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public double QuantityLosses { get; set; }
    }
}
