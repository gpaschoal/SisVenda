using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using SisVenda.UI.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.People
{
    public class PeopleEditBase : AbstractComponentBase
    {
        [Parameter] public string IdPeople { get; set; }
        public UpdatePeopleCommand command;
        public bool ErrorAlert;
        public List<string> Errors;
        [Inject] public PeopleRequest request { get; set; }
        public PeopleEditBase()
        {
            ErrorAlert = false;
            command = new UpdatePeopleCommand();
            Errors = new List<string>();
        }

        protected override async Task OnInitializedAsync()
        {
            (bool result, PeopleResponse response) = await request.GetById(IdPeople);
            if (!result)
                navigation.NavigateTo("/people");

            command = new UpdatePeopleCommand(response);
        }

        public async Task Save()
        {
            (bool result, string message, object data) = await request.Update(command);
            PrintTest.PrintConsole(result);
            PrintTest.PrintConsole(message);
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

        public void Cancel()
        {
            navigation.NavigateTo("/people");
        }
    }

}