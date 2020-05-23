using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using System.Collections.Generic;

namespace SisVenda.UI.Pages.people
{
    public class PeopleBase : AbstractComponentBase
    {
        public PeopleFilter peopleFilter;
        public bool filter;
        public string Display => filter ? "d-none" : null;
        public List<PeopleResponse> responseList;
        public PeopleBase()
        {
            peopleFilter = new PeopleFilter();
            filter = true;
            responseList = new List<PeopleResponse>();
        }
        public void AddNewPeople()
        {
            navigation.NavigateTo("/people/add");
        }
        public void ToggleFilter()
        {
            filter = !filter;
        }
    }
}