using Flunt.Notifications;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Domain.Responses;
using SisVenda.Shared.Handlers;

namespace SisVenda.Domain.Handlers
{
    public class ProductsHandler :
        Notifiable,
        IHandler<ProductsCreateCommand, ProductsResponse>,
        IHandler<ProductsUpdateCommand, ProductsResponse>,
        IHandler<ProductsDeleteCommand, ProductsResponse>
    {
        private readonly IProductsRepository _repository;

        public ProductsHandler(IProductsRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult<ProductsResponse> Handle(ProductsCreateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ProductsResponse>(false, "Houve erros na validação", command.Notifications);

            Products products = new Products(command.Name, command.Description);

            _repository.Create(products);

            return new GenericCommandResult<ProductsResponse>(true, "Cadastrado com sucesso", new ProductsResponse(products));
        }
        public ICommandResult<ProductsResponse> Handle(ProductsUpdateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ProductsResponse>(false, "Houve erros na validação", command.Notifications);

            Products products = _repository.GetById(command.Id);
            if (products is null)
                return new GenericCommandResult<ProductsResponse>(false, "O cadastro não existe para retificar!", command.Notifications);

            products.Update(command.Name, command.Description);
            _repository.Update(products);

            return new GenericCommandResult<ProductsResponse>(true, "Cadastrado com sucesso", new ProductsResponse(products));
        }
        public ICommandResult<ProductsResponse> Handle(ProductsDeleteCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ProductsResponse>(false, "Houve erros na validação", command.Notifications);

            Products products = _repository.GetById(command.Id);
            if (products is null)
                return new GenericCommandResult<ProductsResponse>(false, "O cadastro não existe para deletar!", command.Notifications);

            _repository.Delete(command.Id);

            return new GenericCommandResult<ProductsResponse>(true, "Deletado com sucesso", new ProductsResponse());
        }
    }
}
