using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.Products
{
    public class ProductsAddBase : AbstractComponentBase
    {
        public ProductsCreateCommand command;
        public bool ErrorAlert;
        public List<string> Errors;
        [Inject] public ProductsRequest request { get; set; }
        public ProductsAddBase()
        {
            command = new ProductsCreateCommand();
            ErrorAlert = false;
            Errors = new List<string>();
        }

        public void Cancel()
        {
            navigation.NavigateTo("/Products");
        }

        public async Task Save()
        {
            (bool result, string message, List<ErrorMessage> Errors, _) = await request.Create(command);

            if (result)
            {
                navigation.NavigateTo("/Products");
            }
            else
            {
                ErrorAlert = true;
                this.Errors = Errors.Select(x => x.message).ToList();
            }
        }
    }
}
