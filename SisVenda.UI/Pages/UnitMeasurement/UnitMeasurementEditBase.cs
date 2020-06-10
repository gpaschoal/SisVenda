using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.UnitMeasurement
{
    public class UnitMeasurementEditBase : AbstractComponentBase
    {
        [Parameter] public string IdUnitMeasurement { get; set; }
        public UnitMeasurementUpdateCommand command;
        public bool ErrorAlert;
        public List<string> Errors;
        [Inject] public UnitMeasurementRequest Request { get; set; }
        public UnitMeasurementEditBase()
        {
            ErrorAlert = false;
            command = new UnitMeasurementUpdateCommand();
            Errors = new List<string>();
        }

        protected override async Task OnInitializedAsync()
        {
            (bool result, UnitMeasurementResponse response) = await Request.GetById(IdUnitMeasurement);
            if (!result)
                navigation.NavigateTo("/UnitMeasurement");

            command = new UnitMeasurementUpdateCommand(response);
        }

        public async Task Save()
        {
            (bool result, string message, List<ErrorMessage> Errors, _) = await Request.Update(command);
            if (result)
            {
                navigation.NavigateTo("/UnitMeasurement");
            }
            else
            {
                ErrorAlert = true;
                this.Errors = Errors.Select(x => x.message).ToList();
            }
        }

        public void Cancel()
        {
            navigation.NavigateTo("/UnitMeasurement");
        }
    }
}
