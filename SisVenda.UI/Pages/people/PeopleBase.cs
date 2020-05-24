using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using SisVenda.UI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.People
{
    public class PeopleBase : AbstractComponentBase
    {
        public PeopleFilter peopleFilter;
        public bool filter;
        public string Display => filter ? "d-none" : null;
        public List<PeopleResponse> responseList;
        [Inject] public PeopleRequest request { get; set; }
        public PeopleBase()
        {
            peopleFilter = new PeopleFilter { IsCustomer = true, IsSupplier = true, PageNumber = 1, RowsByPage = 20, };
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

        public async Task Get()
        {
            (bool result, GenericPaginatorResponse<PeopleResponse> response) = await request.Get(peopleFilter);
            if (result)
            {
                responseList = response.Page;
            }
        }
    }
}