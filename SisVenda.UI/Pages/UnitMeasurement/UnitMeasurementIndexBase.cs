using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.UnitMeasurement
{
    public class UnitMeasurementIndexBase : AbstractComponentBase
    {
        public UnitMeasurementFilter unitMeasurementFilter;
        public bool filter;
        public string Display => filter ? "d-none" : null;
        public List<UnitMeasurementResponse> responseList;
        [Inject] public UnitMeasurementRequest Request { get; set; }
        public UnitMeasurementIndexBase()
        {
            unitMeasurementFilter = new UnitMeasurementFilter { Name = "", PageNumber = 1, RowsByPage = 20, };
            filter = true;
            responseList = new List<UnitMeasurementResponse>();
        }
        protected override async Task OnInitializedAsync()
        {
            await Get();
        }
        public void AddNewProduct()
        {
            navigation.NavigateTo("/UnitMeasurement/Add");
        }
        public void EditProduct(string id)
        {
            navigation.NavigateTo("/UnitMeasurement/Edit/" + id);
        }
        public void ToggleFilter()
        {
            filter = !filter;
        }
        public async Task Get()
        {
            (bool result, GenericPaginatorResponse<UnitMeasurementResponse> response) = await Request.Get(unitMeasurementFilter);
            if (result)
            {
                responseList = response.Page;
            }
        }
    }
}
