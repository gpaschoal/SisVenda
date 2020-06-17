using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using SisVenda.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.Products
{
    public class ProductsProfileAddBase : AbstractComponentBase
    {
        [Parameter] public string ProductsId { get; set; }
        [Inject] public ProductsProfileRequest Request { get; set; }
        [Inject] public UnitMeasurementRequest UnitMeasurementRequest { get; set; }
        [Inject] public ProductsRequest ProductsRequest { get; set; }
        public List<UnitMeasurementResponse> LstUnitMeasurementResponse;
        public ProductsResponse ProductsResponse;
        public ProductsProfileCreateCommand command;
        public bool ErrorAlert;
        public List<string> Errors;

        public ProductsProfileAddBase()
        {
            LstUnitMeasurementResponse = new List<UnitMeasurementResponse>();
            command = new ProductsProfileCreateCommand();
            ErrorAlert = false;
            Errors = new List<string>();
        }

        protected override async Task OnInitializedAsync()
        {
            (bool result, GenericPaginatorResponse<UnitMeasurementResponse> UnitMeasurementGenericResponse) = await UnitMeasurementRequest.Get(new UnitMeasurementFilter() { Name = "" });
            if (result)
            {
                LstUnitMeasurementResponse = UnitMeasurementGenericResponse.Page.OrderBy(x => x.Name).ToList();
                if (LstUnitMeasurementResponse.Count > 0)
                    command.UnitMeasurementId = LstUnitMeasurementResponse.FirstOrDefault()?.Id ?? "";
            }

            (_, ProductsResponse) = await ProductsRequest.GetById(ProductsId);
        }
        public void Cancel()
        {
            Navigation.NavigateTo("/Products/ProductsProfile/" + ProductsId);
        }

        public async Task Save()
        {
            command.ProductsId = ProductsId;
            (bool result, string message, List<ErrorMessage> Errors, _) = await Request.Create(command);

            if (result)
            {
                Navigation.NavigateTo("/Products/ProductsProfile/" + ProductsId);
            }
            else
            {
                ErrorAlert = true;
                this.Errors = Errors.Select(x => x.Message).ToList();
            }
        }
    }
}
