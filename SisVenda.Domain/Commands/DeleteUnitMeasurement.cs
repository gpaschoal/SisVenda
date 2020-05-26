﻿using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class DeleteUnitMeasurement : Notifiable, ICommand
    {
        public DeleteUnitMeasurement() { }
        public DeleteUnitMeasurement(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "Id", "É necessário identificar o código")
            );
        }
    }
}
