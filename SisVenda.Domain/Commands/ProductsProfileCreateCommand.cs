using Flunt.Notifications;
using Flunt.Validations;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class ProductsProfileCreateCommand : Notifiable, ICommand
    {
        public ProductsProfileCreateCommand() { }

        public ProductsProfileCreateCommand(string unitMeasurementId, string productsId, string barCode)
        {
            UnitMeasurementId = unitMeasurementId;
            ProductsId = productsId;
            BarCode = barCode;
        }

        public string UnitMeasurementId { get; set; }
        public string ProductsId { get; set; }
        public string BarCode { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(UnitMeasurementId, "UnitMeasurementId", "O código da unidade de medida é inválida!")
                    .IsNotNullOrEmpty(ProductsId, "ProductsId", "O código do produto é inválido!")
                    .IsBetween(BarCode?.Trim().Length ?? 0, 003, 100, "BarCode", "O código de barras precisa ter no entre 3 e 100 digitos!")
            );
        }
    }
}
