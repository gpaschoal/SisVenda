using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class ProductsUpdateCommand : Notifiable, ICommand
    {
        public ProductsUpdateCommand() { }
        public ProductsUpdateCommand(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNullOrEmpty(Id, "Id", "É necessário identificar o código")
                  .IsBetween(Name?.Trim().Length ?? 0, 3, 150, "Name", "O Nome precisa ter pelo menos 3 dígitos")
                  .IsBetween(Description?.Trim().Length ?? 0, 4, 150, "Description", "A Descrição precisa ter no mínimo 4 dígitos")
          );
        }
    }
}
