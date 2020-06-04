using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.People
{
    public class PeopleAddBase : AbstractComponentBase
    {
        public PeopleCreateCommand command;
        public bool ErrorAlert;
        public List<string> Errors;
        [Inject] public PeopleRequest request { get; set; }
        public PeopleAddBase()
        {
            command = new PeopleCreateCommand() { IsCustomer = true, IsSupplier = true };
            ErrorAlert = false;
            Errors = new List<string>();
        }

        public void Cancel()
        {
            navigation.NavigateTo("/people");
        }

        public async Task Save()
        {
            (bool result, string message, List<ErrorMessage> Errors, _) = await request.Create(command);

            if (result)
            {
                navigation.NavigateTo("/people");
            }
            else
            {
                ErrorAlert = true;
                this.Errors = Errors.Select(x => x.message).ToList();
            }
        }
    }
}