using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using SisVenda.UI.Utils;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SisVenda.UI.Requests
{
    public class PeopleRequest : AbstractRequest
    {
        public PeopleRequest(HttpClient http) : base(http) { }

        public async Task<(bool, string, object)> Create(CreatePeopleCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await http.PostAsync("api/people/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult result = JsonSerializer.Deserialize<GenericCommandResult>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new object());

            if (result.Success)
                return (true, "Cadastrado com sucesso!", result.Data);

            return (false, "Ops, houve algum erro ao cadastrar!", result.Data); ;
        }
        public async Task<(bool, string, object)> Update(CreatePeopleCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool, string, object)> Delete(DeletePeopleCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool result, GenericPaginatorResponse<PeopleResponse> response)> Get(PeopleFilter filter)
        {
            //serializing my filter
            string json = JsonSerializer.Serialize(filter);

            // Request my api // if were a get filter.HttpQueryBuilder()
            HttpResponseMessage httpResponse = await http.PostAsync("api/people/get", new StringContent(json, Encoding.UTF8, "application/json"));

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new GenericPaginatorResponse<PeopleResponse>());

            //Desserialize my json response
            GenericPaginatorResponse<PeopleResponse> response = responseAsString.Deserialize<GenericPaginatorResponse<PeopleResponse>>();

            return (true, response);
        }
    }
}