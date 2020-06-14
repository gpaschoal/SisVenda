using Flunt.Notifications;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Domain.Responses;
using SisVenda.Shared.Handlers;
using System.Collections.Generic;

namespace SisVenda.Domain.Handlers
{
    public class ProductsProfileHandler :
        Notifiable,
        IHandler<ProductsProfileCreateCommand, ProductsProfileResponse>,
        IHandler<ProductsProfileUpdateCommand, ProductsProfileResponse>,
        IHandler<ProductsProfileDeleteCommand, ProductsProfileResponse>
    {
        private readonly IProductsProfileRepository _repository;
        private readonly IUnitMeasurementRepository _UnitMeasurementRepository;
        private readonly IProductsRepository _ProductsRepository;

        public ProductsProfileHandler(IProductsProfileRepository repository, IUnitMeasurementRepository unitMeasurementRepository, IProductsRepository productsRepository)
        {
            _repository = repository;
            _UnitMeasurementRepository = unitMeasurementRepository;
            _ProductsRepository = productsRepository;
        }

        public ICommandResult<ProductsProfileResponse> Handle(ProductsProfileCreateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ProductsProfileResponse>(false, "Houve erro na validação", command.Notifications);

            List<Notification> errors = null;
            if (_ProductsRepository.GetById(command.ProductsId) is null)
            {
                errors ??= new List<Notification>();
                errors.Add(new Notification("ProductsId", "O produto é inválido!"));
            }
            if (_repository.GetByBarCode(command.BarCode) != null)
            {
                errors ??= new List<Notification>();
                errors.Add(new Notification("BarCode", "Já existe esse código de barra no sistema!"));
            }
            if (_UnitMeasurementRepository.GetById(command.UnitMeasurementId) is null)
            {
                errors ??= new List<Notification>();
                errors.Add(new Notification("UnitMeasurementId", "A unidade de medida é inválida!"));
            }
            if (errors != null)
                return new GenericCommandResult<ProductsProfileResponse>(false, "Houve erro na validação", errors);

            ProductsProfile productsProfile = new ProductsProfile(command.UnitMeasurementId, command.ProductsId, command.BarCode);

            _repository.Create(productsProfile);
            return new GenericCommandResult<ProductsProfileResponse>(true, "Cadastrado com sucesso", new ProductsProfileResponse(productsProfile));
        }

        public ICommandResult<ProductsProfileResponse> Handle(ProductsProfileUpdateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ProductsProfileResponse>(false, "Houve erro na validação", command.Notifications);

            ProductsProfile productsProfile = _repository.GetById(command.Id);
            if (productsProfile is null)
                return new GenericCommandResult<ProductsProfileResponse>(false, "O cadastro não existe para retificar!", command.Notifications);

            ProductsProfile productsProfileBarcode = _repository.GetById(command.Id);

            List<Notification> errors = null;
            if (_ProductsRepository.GetById(command.ProductsId) is null)
            {
                errors ??= new List<Notification>();
                errors.Add(new Notification("ProductsId", "O produto é inválido!"));
            }
            if (productsProfileBarcode != null)
            {
                errors ??= new List<Notification>();
                /* Checking if the existing barcode is my own ProductsProfile - If not mean errors */
                if (productsProfile.Id != productsProfileBarcode.Id)
                    errors.Add(new Notification("BarCode", "Já existe esse código de barra no sistema!"));
            }
            if (_UnitMeasurementRepository.GetById(command.UnitMeasurementId) is null)
            {
                errors ??= new List<Notification>();
                errors.Add(new Notification("UnitMeasurementId", "A unidade de medida é inválida!"));
            }
            if (errors != null && errors.Count > 0)
                return new GenericCommandResult<ProductsProfileResponse>(false, "Houve erro na validação", errors);

            productsProfile.Update(command.UnitMeasurementId, command.ProductsId, command.BarCode);

            _repository.Update(productsProfile);
            return new GenericCommandResult<ProductsProfileResponse>(true, "Cadastrado com sucesso", new ProductsProfileResponse(productsProfile));
        }

        public ICommandResult<ProductsProfileResponse> Handle(ProductsProfileDeleteCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ProductsProfileResponse>(false, "Houve erro na validação", command.Notifications);

            ProductsProfile productsProfile = _repository.GetById(command.Id);
            if (productsProfile is null)
                return new GenericCommandResult<ProductsProfileResponse>(false, "O cadastro não existe para deletar!", command.Notifications);

            _repository.Delete(command.Id);

            return new GenericCommandResult<ProductsProfileResponse>(true, "Deletado com sucesso", new ProductsProfileResponse());
        }
    }
}
