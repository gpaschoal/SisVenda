using Microsoft.AspNetCore.Components;
using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVenda.UI.Pages.UnitMeasurement
{
    public class UnitMeasurementAddBase : AbstractComponentBase
    {
        public UnitMeasurementCreateCommand command;
        public bool ErrorAlert;
        public List<string> Errors;
        [Inject] public UnitMeasurementRequest request { get; set; }
        public UnitMeasurementAddBase()
        {
            command = new UnitMeasurementCreateCommand();
            ErrorAlert = false;
            Errors = new List<string>();
        }

        public void Cancel()
        {
            Navigation.NavigateTo("/UnitMeasurement");
        }

        public async Task Save()
        {
            (bool result, string message, List<ErrorMessage> Errors, _) = await request.Create(command);

            if (result)
            {
                Navigation.NavigateTo("/UnitMeasurement");
            }
            else
            {
                ErrorAlert = true;
                this.Errors = Errors.Select(x => x.Message).ToList();
            }
        }
    }
}
