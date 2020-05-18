namespace SisVenda.UI.Pages.people
{
    public class PeopleBase : AbstractComponentBase
    {
        public void AddNewPeople()
        {
            navigation.NavigateTo("/people/add");
        }
    }
}