using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.Products
{
    public class ProductsEditBase : AbstractComponentBase
    {
        [Parameter] public string IdProduct { get; set; }
        public ProductsUpdateCommand command;
        public bool ErrorAlert;
        public List<string> Errors;
        [Inject] public ProductsRequest Request { get; set; }
        public ProductsEditBase()
        {
            ErrorAlert = false;
            command = new ProductsUpdateCommand();
            Errors = new List<string>();
        }

        protected override async Task OnInitializedAsync()
        {
            (bool result, ProductResponse response) = await Request.GetById(IdProduct);
            if (!result)
                navigation.NavigateTo("/Products");

            command = new ProductsUpdateCommand(response);
        }

        public async Task Save()
        {
            (bool result, string message, List<ErrorMessage> Errors, _) = await Request.Update(command);
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

        public void Cancel()
        {
            navigation.NavigateTo("/Products");
        }
    }
}
