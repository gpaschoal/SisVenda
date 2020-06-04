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
    public class ProductsRequest : AbstractRequest
    {
        public ProductsRequest(HttpClient http) : base(http) { }

        public async Task<(bool result, string message, List<ErrorMessage> Notifications, ProductResponse Data)> Create(ProductsCreateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await http.PostAsync("api/Products/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<ProductResponse> result = JsonSerializer.Deserialize<GenericCommandResult<ProductResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new ProductResponse());

            if (result.Success)
                return (true, "Cadastrado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao cadastrar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message, List<ErrorMessage> Notifications, ProductResponse Data)> Update(ProductsUpdateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await http.PutAsync("api/Products/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<ProductResponse> result = JsonSerializer.Deserialize<GenericCommandResult<ProductResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new ProductResponse());

            if (result.Success)
                return (true, "Editado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao editar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message, object response)> Delete(ProductsDeleteCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool result, ProductResponse response)> GetById(string id)
        {
            // api request
            HttpResponseMessage httpResponse = await http.GetAsync("api/Products/" + id);

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new ProductResponse());

            // Desserialize my json response
            ProductResponse response = responseAsString.Deserialize<ProductResponse>();

            return (true, response);
        }
        public async Task<(bool result, GenericPaginatorResponse<ProductResponse> response)> Get(PeopleFilter filter)
        {
            string json = JsonSerializer.Serialize(filter);

            // Request my api // if were a get filter.HttpQueryBuilder()
            HttpResponseMessage httpResponse = await http.PostAsync("api/people/get", new StringContent(json, Encoding.UTF8, "application/json"));

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode)
                return (false, new GenericPaginatorResponse<ProductResponse>());

            // Desserialize my json response
            GenericPaginatorResponse<ProductResponse> response = responseAsString.Deserialize<GenericPaginatorResponse<ProductResponse>>();

            return (true, response);
        }
    }
}
