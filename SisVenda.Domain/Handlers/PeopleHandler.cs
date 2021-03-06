﻿using Flunt.Notifications;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Domain.Responses;
using SisVenda.Shared.Handlers;

namespace SisVenda.Domain.Handlers
{
    public class PeopleHandler :
        Notifiable,
        IHandler<PeopleCreateCommand, PeopleResponse>,
        IHandler<PeopleUpdateCommand, PeopleResponse>,
        IHandler<PeopleDeleteCommand, PeopleResponse>
    {
        private readonly IPeopleRepository _repository;
        public PeopleHandler(IPeopleRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult<PeopleResponse> Handle(PeopleCreateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<PeopleResponse>(false, "Houve erros na validação", command.Notifications);

            People people = new People(command.IsCustomer ?? false, command.IsSupplier ?? false, command.Name, command.Contact, command.CPF, command.CNPJ, command.Street,
                        command.Number, command.Neighborhood, command.City, command.State, command.ZipCode, command.AdressEmail, command.PhoneNumber);
            _repository.Create(people);

            return new GenericCommandResult<PeopleResponse>(true, "Cadastrado com sucesso", new PeopleResponse(people));
        }
        public ICommandResult<PeopleResponse> Handle(PeopleUpdateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<PeopleResponse>(false, "Houve erros na validação", command.Notifications);

            People person = _repository.GetById(command.Id);
            if (person is null)
                return new GenericCommandResult<PeopleResponse>(false, "O cadastro não existe para retificar!", command.Notifications);

            person.Update(command.IsCustomer, command.IsSupplier, command.Name, command.Contact, command.CPF, command.CNPJ, command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode, command.AdressEmail, command.PhoneNumber);
            _repository.Update(person);

            return new GenericCommandResult<PeopleResponse>(true, "Atualizado com sucesso", new PeopleResponse(person));
        }
        public ICommandResult<PeopleResponse> Handle(PeopleDeleteCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<PeopleResponse>(false, "Houve erros na validação", command.Notifications);

            People person = _repository.GetById(command.Id);
            if (person is null)
                return new GenericCommandResult<PeopleResponse>(false, "O cadastro não existe para deletar!", command.Notifications);

            _repository.Delete(command.Id);

            return new GenericCommandResult<PeopleResponse>(true, "Deletado com sucesso", new PeopleResponse());
        }
    }
}
