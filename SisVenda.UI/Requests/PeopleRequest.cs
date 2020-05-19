using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SisVenda.UI.CQRS.Commands;

namespace SisVenda.UI.Requests
{
    public class PeopleRequest : AbstractRequest
    {
        public PeopleRequest(HttpClient http) : base(http) { }

        public async Task<(bool, string, object)> Create(CreatePeopleCommand command)
        {
            Utils.PrintTest.PrintConsole(command);
            Utils.PrintTest.PrintConsole(http);

            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await http.PostAsync("api/people/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult result = JsonSerializer.Deserialize<GenericCommandResult>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Utils.PrintTest.PrintConsole(result);

            if (httpResponse.IsSuccessStatusCode)
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
    }
}