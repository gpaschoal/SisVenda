using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class ProductsProfileUpdateCommand : Notifiable, ICommand
    {
        public ProductsProfileUpdateCommand() { }

        public string Id { get; set; }
        public string UnitMeasurementId { get; set; }
        public string ProductsId { get; set; }
        public string BarCode { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "Id", "É necessário identificar o código")
                    .HasMinLen(UnitMeasurementId, 32, "UnitMeasurementId", "A Unidade de medida é inválida!")
                    .HasMaxLen(UnitMeasurementId, 32, "UnitMeasurementId", "A Unidade de medida é inválida!")
                    .HasMinLen(ProductsId, 32, "ProductsId", "O Produto é inválido!")
                    .HasMaxLen(ProductsId, 32, "ProductsId", "O Produto é inválido!")
                    .HasMinLen(BarCode, 003, "BarCode", "O código de barras precisa ter no mínimo 3 digitos!")
                    .HasMaxLen(BarCode, 100, "BarCode", "O código de barras precisa ter no máximo 100 digitos!")
            );
        }
    }
}
