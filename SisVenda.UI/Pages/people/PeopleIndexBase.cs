using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.People
{
    public class PeopleIndexBase : AbstractComponentBase
    {
        public PeopleFilter peopleFilter;
        public bool filter;
        public string Display => filter ? "d-none" : null;
        public List<PeopleResponse> responseList;
        [Inject] public PeopleRequest Request { get; set; }
        public PeopleIndexBase()
        {
            peopleFilter = new PeopleFilter { IsCustomer = true, IsSupplier = true, PageNumber = 1, RowsByPage = 20, };
            filter = true;
            responseList = new List<PeopleResponse>();
        }
        protected override async Task OnInitializedAsync()
        {
            await Get();
        }
        public void AddNewPeople()
        {
            Navigation.NavigateTo("/people/add");
        }
        public void EditPeople(string id)
        {
            Navigation.NavigateTo("/people/Edit/" + id);
        }
        public void ToggleFilter()
        {
            filter = !filter;
        }
        public async Task Get()
        {
            (bool result, GenericPaginatorResponse<PeopleResponse> response) = await Request.Get(peopleFilter);
            if (result)
            {
                responseList = response.Page;
            }
        }
    }
}