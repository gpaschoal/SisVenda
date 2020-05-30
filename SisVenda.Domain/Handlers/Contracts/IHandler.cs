using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Responses;

namespace SisVenda.Shared.Handlers
{
    public interface IHandler<T, R>
            where T : ICommand, new()
            where R : IResponse, new()
    {
        ICommandResult<R> Handle(T command);
    }
}
