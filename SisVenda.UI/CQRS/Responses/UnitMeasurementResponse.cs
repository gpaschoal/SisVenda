﻿namespace SisVenda.UI.CQRS.Responses
{
    public class UnitMeasurementResponse : IResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double QuantityLosses { get; set; }
    }
}
