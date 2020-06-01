using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class PeopleDeleteCommand : Notifiable, ICommand
    {
        public PeopleDeleteCommand() { }

        public PeopleDeleteCommand(string id)
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
