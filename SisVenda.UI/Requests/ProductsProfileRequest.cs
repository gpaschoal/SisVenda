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
    public class ProductsProfileRequest :
        AbstractRequest,
        IRequestBase<ProductsProfileCreateCommand, ProductsProfileUpdateCommand, ProductsProfileDeleteCommand, ProductsProfileResponse, ProductsProfileFilter>
    {
        public ProductsProfileRequest(HttpClient http) : base(http) { }
        public async Task<(bool result, string message, List<ErrorMessage> Notifications, ProductsProfileResponse Data)> Create(ProductsProfileCreateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await Http.PostAsync("api/ProductsProfile/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<ProductsProfileResponse> result = JsonSerializer.Deserialize<GenericCommandResult<ProductsProfileResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new ProductsProfileResponse());

            if (result.Success)
                return (true, "Cadastrado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao cadastrar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message)> Delete(ProductsProfileDeleteCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool result, GenericPaginatorResponse<ProductsProfileResponse> response)> Get(ProductsProfileFilter filter)
        {
            // serializing my filter
            string json = JsonSerializer.Serialize(filter);

            // Request my api // if were a get filter.HttpQueryBuilder()
            HttpResponseMessage httpResponse = await Http.PostAsync("api/ProductsProfile/get", new StringContent(json, Encoding.UTF8, "application/json"));

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new GenericPaginatorResponse<ProductsProfileResponse>());

            // Desserialize my json response
            GenericPaginatorResponse<ProductsProfileResponse> response = responseAsString.Deserialize<GenericPaginatorResponse<ProductsProfileResponse>>();

            return (true, response);
        }
        public async Task<(bool result, ProductsProfileResponse response)> GetById(string id)
        {
            // api request
            HttpResponseMessage httpResponse = await Http.GetAsync("api/ProductsProfile/" + id);

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new ProductsProfileResponse());

            // Desserialize my json response
            ProductsProfileResponse response = responseAsString.Deserialize<ProductsProfileResponse>();

            return (true, response);
        }
        public async Task<(bool result, string message, List<ErrorMessage> Notifications, ProductsProfileResponse Data)> Update(ProductsProfileUpdateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await Http.PutAsync("api/ProductsProfile/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<ProductsProfileResponse> result = JsonSerializer.Deserialize<GenericCommandResult<ProductsProfileResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new ProductsProfileResponse());

            if (result.Success)
                return (true, "Editado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao editar!", result.Notifications, result.Data);
        }
    }
}
