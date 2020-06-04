using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.Products
{
    public class ProductsIndexBase : AbstractComponentBase
    {
        public ProductsFilter productsFilter;
        public bool filter;
        public string Display => filter ? "d-none" : null;
        public List<ProductResponse> responseList;
        [Inject] public PeopleRequest Request { get; set; }
        public ProductsIndexBase()
        {
            productsFilter = new ProductsFilter { Description = "", Name = "", PageNumber = 1, RowsByPage = 20, };
            filter = true;
            responseList = new List<ProductResponse>();
        }
        protected override async Task OnInitializedAsync()
        {
            await Get();
        }
        public void AddNewProduct()
        {
            navigation.NavigateTo("/Products/add");
        }
        public void EditProduct(string id)
        {
            navigation.NavigateTo("/Products/Edit/" + id);
        }
        public void ToggleFilter()
        {
            filter = !filter;
        }
        public async Task Get()
        {
            //(bool result, GenericPaginatorResponse<PeopleResponse> response) = await Request.Get(peopleFilter);
            //if (result)
            //{
            //    responseList = response.Page;
            //}
        }
    }
}
