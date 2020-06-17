using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SisVenda.UI.Requests
{
    public class UnitMeasurementRequest :
        AbstractRequest,
        IRequestBase<UnitMeasurementCreateCommand, UnitMeasurementUpdateCommand, UnitMeasurementDeleteCommand, UnitMeasurementResponse, UnitMeasurementFilter>
    {
        public UnitMeasurementRequest(HttpClient http) : base(http) { }

        public async Task<(bool result, string message, List<ErrorMessage> Notifications, UnitMeasurementResponse Data)> Create(UnitMeasurementCreateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            Console.WriteLine(command.ToString());
            HttpResponseMessage httpResponse = await Http.PostAsync("api/UnitMeasurement/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<UnitMeasurementResponse> result = JsonSerializer.Deserialize<GenericCommandResult<UnitMeasurementResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new UnitMeasurementResponse());

            if (result.Success)
                return (true, "Cadastrado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao cadastrar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message, List<ErrorMessage> Notifications, UnitMeasurementResponse Data)> Update(UnitMeasurementUpdateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await Http.PutAsync("api/UnitMeasurement/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<UnitMeasurementResponse> result = JsonSerializer.Deserialize<GenericCommandResult<UnitMeasurementResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new UnitMeasurementResponse());

            if (result.Success)
                return (true, "Editado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao editar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message)> Delete(UnitMeasurementDeleteCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool result, UnitMeasurementResponse response)> GetById(string id)
        {
            // api request
            HttpResponseMessage httpResponse = await Http.GetAsync("api/UnitMeasurement/" + id);

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new UnitMeasurementResponse());

            // Desserialize my json response
            UnitMeasurementResponse response = responseAsString.Deserialize<UnitMeasurementResponse>();

            return (true, response);
        }
        public async Task<(bool result, GenericPaginatorResponse<UnitMeasurementResponse> response)> Get(UnitMeasurementFilter filter)
        {
            string json = JsonSerializer.Serialize(filter);

            // Request my api // if were a get filter.HttpQueryBuilder()
            HttpResponseMessage httpResponse = await Http.PostAsync("api/UnitMeasurement/get", new StringContent(json, Encoding.UTF8, "application/json"));

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode)
                return (false, new GenericPaginatorResponse<UnitMeasurementResponse>());

            // Desserialize my json response
            GenericPaginatorResponse<UnitMeasurementResponse> response = responseAsString.Deserialize<GenericPaginatorResponse<UnitMeasurementResponse>>();

            return (true, response);
        }
    }
}
