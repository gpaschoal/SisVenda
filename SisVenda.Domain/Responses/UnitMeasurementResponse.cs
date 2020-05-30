using SisVenda.Domain.Entities;

namespace SisVenda.Domain.Responses
{
    public class UnitMeasurementResponse : IResponse
    {
        public UnitMeasurementResponse() { }
        public UnitMeasurementResponse(UnitMeasurement unitMeasurement)
        {
            if (unitMeasurement is null) return;

            Id = unitMeasurement.Id;
            Name = unitMeasurement.Name;
            QuantityLosses = unitMeasurement.QuantityLosses;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double QuantityLosses { get; set; }
    }

}
