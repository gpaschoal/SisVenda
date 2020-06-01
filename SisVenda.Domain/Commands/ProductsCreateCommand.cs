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
                  .HasMinLen(Name, 3, "Name", "O Nome precisa ter pelo menos 3 dígitos")
                  .HasMaxLen(Name, 150, "Name", "O Nome precisa ter no máximo 150 dígitos")
                  .HasMinLen(Description, 4, "Description", "A Descrição precisa ter no mínimo 4 dígitos")
                  .HasMaxLen(Description, 150, "Description", "A Descrição precisa ter no máximo 150 dígitos")
           );
        }
    }
}
