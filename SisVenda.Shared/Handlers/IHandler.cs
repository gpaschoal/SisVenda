using SisVenda.Shared.Commands;

namespace SisVenda.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
