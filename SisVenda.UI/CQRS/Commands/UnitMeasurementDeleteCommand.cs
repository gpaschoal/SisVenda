﻿namespace SisVenda.UI.CQRS.Commands
{
    public class UnitMeasurementDeleteCommand : IDeleteCommand
    {
        public string Id { get; set; }
    }
}
