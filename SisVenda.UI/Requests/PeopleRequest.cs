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
    public class PeopleRequest : AbstractRequest
    {
        public PeopleRequest(HttpClient http) : base(http) { }

        public async Task<(bool result, string message, List<ErrorMessage> Notifications, PeopleResponse Data)> Create(CreatePeopleCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await http.PostAsync("api/people/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<PeopleResponse> result = JsonSerializer.Deserialize<GenericCommandResult<PeopleResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new PeopleResponse());

            if (result.Success)
                return (true, "Cadastrado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao cadastrar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message, List<ErrorMessage> Notifications, PeopleResponse Data)> Update(UpdatePeopleCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await http.PutAsync("api/people/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<PeopleResponse> result = JsonSerializer.Deserialize<GenericCommandResult<PeopleResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new PeopleResponse());

            if (result.Success)
                return (true, "Editado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao editar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message, object response)> Delete(DeletePeopleCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool result, PeopleResponse response)> GetById(string id)
        {
            // api request
            HttpResponseMessage httpResponse = await http.GetAsync("api/people/" + id);

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new PeopleResponse());

            // Desserialize my json response
            PeopleResponse response = responseAsString.Deserialize<PeopleResponse>();

            return (true, response);
        }
        public async Task<(bool result, GenericPaginatorResponse<PeopleResponse> response)> Get(PeopleFilter filter)
        {
            // serializing my filter
            string json = JsonSerializer.Serialize(filter);

            // Request my api // if were a get filter.HttpQueryBuilder()
            HttpResponseMessage httpResponse = await http.PostAsync("api/people/get", new StringContent(json, Encoding.UTF8, "application/json"));

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new GenericPaginatorResponse<PeopleResponse>());

            // Desserialize my json response
            GenericPaginatorResponse<PeopleResponse> response = responseAsString.Deserialize<GenericPaginatorResponse<PeopleResponse>>();

            return (true, response);
        }
    }
}