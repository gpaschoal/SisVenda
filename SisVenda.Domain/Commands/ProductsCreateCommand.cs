using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class ProductsCreateCommand : Notifiable, ICommand
    {
        public ProductsCreateCommand() { }

        public ProductsCreateCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
                   .Requires()
                  .IsBetween(Name?.Trim().Length ?? 0, 3, 150, "Name", "O Nome precisa ter pelo menos 3 dígitos")
                  .IsBetween(Description?.Trim().Length ?? 0, 4, 150, "Description", "A Descrição precisa ter no mínimo 4 dígitos")
           );
        }
    }
}
