using Flunt.Notifications;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Domain.Responses;
using SisVenda.Shared.Handlers;

namespace SisVenda.Domain.Handlers
{
    public class UnitMeasurementHandler :
            Notifiable,
            IHandler<CreateUnitMeasurement>,
            IHandler<UpdateUnitMeasurement>,
            IHandler<DeleteUnitMeasurement>
    {
        private readonly IUnitMeasurementRepository _repository;

        public UnitMeasurementHandler(IUnitMeasurementRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUnitMeasurement command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Houve erros na validação", command.Notifications);

            UnitMeasurement unitMeasurement = new UnitMeasurement(command.Name, command.QuantityLosses);
            _repository.Create(unitMeasurement);

            return new GenericCommandResult(true, "Cadastrado com sucesso", new UnitMeasurementResponse(unitMeasurement));
        }

        public ICommandResult Handle(UpdateUnitMeasurement command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Houve erros na validação", command.Notifications);

            UnitMeasurement unitMeasurement = _repository.GetById(command.Id);
            if (unitMeasurement is null)
                return new GenericCommandResult(false, "O cadastro não existe para retificar!", command.Notifications);

            unitMeasurement.Update(command.Name, command.QuantityLosses);
            _repository.Update(unitMeasurement);

            return new GenericCommandResult(true, "Atualizado com sucesso", new UnitMeasurementResponse(unitMeasurement));
        }

        public ICommandResult Handle(DeleteUnitMeasurement command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Houve erros na validação", command.Notifications);

            UnitMeasurement unitMeasurement = _repository.GetById(command.Id);
            if (unitMeasurement is null)
                return new GenericCommandResult(false, "O cadastro não existe para deletar!", command.Notifications);

            _repository.Delete(command.Id);
            return new GenericCommandResult(true, "Deletado com sucesso", null);
        }
    }
}
