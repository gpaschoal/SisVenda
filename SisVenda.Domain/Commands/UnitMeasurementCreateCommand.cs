﻿using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class UnitMeasurementCreateCommand : Notifiable, ICommand
    {
        public UnitMeasurementCreateCommand() { }
        public UnitMeasurementCreateCommand(string name, double quantityLosses)
        {
            Name = name;
            QuantityLosses = quantityLosses;
        }

        public string Name { get; set; }
        public double? QuantityLosses { get; set; }
        public void Validate()
        {
            AddNotifications(
               new Contract()
                   .Requires()
                   .IsBetween(Name?.Trim().Length ?? 0, 3, 150, "Name", "O Nome precisa ter pelo entre 3 e 150 dígitos")
                   .IsGreaterThan(QuantityLosses ?? 0, 0.1d, "QuantityLosses", "A quantidade não pode ser menor que 0")
           );
        }
    }
}
