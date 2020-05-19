using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.Requests;

namespace SisVenda.UI.Pages.people
{
    public class PeopleAddBase : AbstractComponentBase
    {
        public CreatePeopleCommand command;
        [Inject] public PeopleRequest request { get; set; }
        public PeopleAddBase()
        {
            command = new CreatePeopleCommand();
        }

        public void Cancel()
        {
            navigation.NavigateTo("/people");
        }

        public async Task Save()
        {
            (bool result, string message, object data) = await request.Create(command);
            //navigation.NavigateTo("/people");
        }
    }
}