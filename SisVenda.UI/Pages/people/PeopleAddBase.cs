using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using SisVenda.UI.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.people
{
    public class PeopleAddBase : AbstractComponentBase
    {
        public CreatePeopleCommand command;
        public bool ErrorAlert;
        public List<string> Errors;
        [Inject] public PeopleRequest request { get; set; }
        public PeopleAddBase()
        {
            command = new CreatePeopleCommand();
            ErrorAlert = false;
            Errors = new List<string>();
        }

        public void Cancel()
        {
            navigation.NavigateTo("/people");
        }

        public async Task Save()
        {
            (bool result, string message, object data) = await request.Create(command);

            if (result)
            {
                navigation.NavigateTo("/people");
            }
            else
            {
                ErrorAlert = true;
                Errors = data.Deserialize<List<ErrorMessage>>().Select(x => x.message).ToList();
            }
        }
    }
}