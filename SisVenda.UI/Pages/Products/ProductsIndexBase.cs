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
        public List<ProductsResponse> responseList;
        [Inject] public ProductsRequest Request { get; set; }
        public ProductsIndexBase()
        {
            productsFilter = new ProductsFilter { Description = "", Name = "", PageNumber = 1, RowsByPage = 20, };
            filter = true;
            responseList = new List<ProductsResponse>();
        }
        protected override async Task OnInitializedAsync()
        {
            await Get();
        }
        public void AddNewProduct()
        {
            Navigation.NavigateTo("/Products/Add");
        }
        public void EditProduct(string id)
        {
            Navigation.NavigateTo("/Products/Edit/" + id);
        }
        public void ProductProfiles(string id)
        {
            Navigation.NavigateTo("/Products/ProductsProfile/" + id);
        }
        public void ToggleFilter()
        {
            filter = !filter;
        }
        public async Task Get()
        {
            (bool result, GenericPaginatorResponse<ProductsResponse> response) = await Request.Get(productsFilter);
            if (result)
            {
                responseList = response.Page;
            }
        }
    }
}
