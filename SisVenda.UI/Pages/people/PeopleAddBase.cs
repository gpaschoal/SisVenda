using SisVenda.UI.CQRS.Commands;

namespace SisVenda.UI.Pages.people
{
    public class PeopleAddBase : AbstractComponentBase
    {
        public CreatePeopleCommand peopleCommand;
        public PeopleAddBase()
        {
            peopleCommand = new CreatePeopleCommand();
        }

        public void Cancel()
        {
            navigation.NavigateTo("/people");
        }

        public void Save()
        {
            navigation.NavigateTo("/people");
        }
    }
}