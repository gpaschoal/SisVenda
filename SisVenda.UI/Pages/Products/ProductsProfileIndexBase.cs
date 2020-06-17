using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.Products
{
    public class ProductsProfileIndexBase : AbstractComponentBase
    {
        [Parameter] public string ProductsId { get; set; }
        [Inject] public ProductsProfileRequest Request { get; set; }
        public List<ProductsProfileResponse> responseList;
        public ProductsProfileFilter filter;
        public ProductsProfileIndexBase()
        {
            responseList = new List<ProductsProfileResponse>();
            filter = new ProductsProfileFilter();
        }
        protected override async Task OnInitializedAsync()
        {
            await Get();
        }
        public void Add()
        {
            Navigation.NavigateTo($"/Products/ProductsProfile/{ProductsId}/Add");
        }
        public void Edit(string id)
        {
            Navigation.NavigateTo($"/Products/ProductsProfile/{ProductsId}/Edit/" + id);
        }
        public async Task Get()
        {
            (bool result, GenericPaginatorResponse<ProductsProfileResponse> response) = await Request.Get(filter);
            if (result)
            {
                responseList = response.Page;
            }
        }
    }
}
