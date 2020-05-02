﻿using Flunt.Notifications;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Shared.Handlers;

namespace SisVenda.Domain.Handlers
{
    public class PeopleHandler :
        Notifiable,
        IHandler<CreatePeopleCommand>,
        IHandler<UpdatePeopleCommand>
    {
        private readonly IPeopleRepository _repository;
        public PeopleHandler(IPeopleRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreatePeopleCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Houve erros na validação", command.Notifications);

            People people = new People(command.IsCustomer, command.IsSupplier, command.Name, command.Contact, command.CPF, command.CNPJ, command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode, command.AdressEmail);
            _repository.Create(people);

            return new GenericCommandResult(true, "Cadastrado com sucesso", people);
        }

        public ICommandResult Handle(UpdatePeopleCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Houve erros na validação", command.Notifications);

            People people = new People(command.IsCustomer, command.IsSupplier, command.Name, command.Contact, command.CPF, command.CNPJ, command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode, command.AdressEmail);
            _repository.Create(people);

            return new GenericCommandResult(true, "Atualizado com sucesso", people);
        }
    }
}
