using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class CreateUnitMeasurement : Notifiable, ICommand
    {
        public CreateUnitMeasurement() { }
        public CreateUnitMeasurement(string name, double quantityLosses)
        {
            Name = name;
            QuantityLosses = quantityLosses;
        }

        public string Name { get; set; }
        public double QuantityLosses { get; set; }
        public void Validate()
        {
            AddNotifications(
               new Contract()
                   .Requires()
                   .HasMinLen(Name, 3, "Name", "O Nome precisa ter pelo menos 3 dígitos")
                   .HasMaxLen(Name, 150, "Name", "O Nome precisa ter no máximo 150 dígitos")
                   .IsLowerThan(QuantityLosses, 1, "QuantityLosses", "A quantidade não pode ser menor que 0")
           );
        }
    }
}
