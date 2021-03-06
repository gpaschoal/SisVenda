﻿using SisVenda.UI.CQRS.Commands;
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
    public class ProductsRequest :
        AbstractRequest,
        IRequestBase<ProductsCreateCommand, ProductsUpdateCommand, ProductsDeleteCommand, ProductsResponse, ProductsFilter>
    {
        public ProductsRequest(HttpClient http) : base(http) { }

        public async Task<(bool result, string message, List<ErrorMessage> Notifications, ProductsResponse Data)> Create(ProductsCreateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await Http.PostAsync("api/Products/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<ProductsResponse> result = JsonSerializer.Deserialize<GenericCommandResult<ProductsResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new ProductsResponse());

            if (result.Success)
                return (true, "Cadastrado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao cadastrar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message, List<ErrorMessage> Notifications, ProductsResponse Data)> Update(ProductsUpdateCommand command)
        {
            string json = JsonSerializer.Serialize(command);
            HttpResponseMessage httpResponse = await Http.PutAsync("api/Products/", new StringContent(json, Encoding.UTF8, "application/json"));
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            GenericCommandResult<ProductsResponse> result = JsonSerializer.Deserialize<GenericCommandResult<ProductsResponse>>(responseAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!httpResponse.IsSuccessStatusCode)
                return (false, "Ops, houve um erro inexperado!", new List<ErrorMessage>(), new ProductsResponse());

            if (result.Success)
                return (true, "Editado com sucesso!", result.Notifications, result.Data);

            return (false, "Ops, houve algum erro ao editar!", result.Notifications, result.Data);
        }
        public async Task<(bool result, string message)> Delete(ProductsDeleteCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool result, ProductsResponse response)> GetById(string id)
        {
            // api request
            HttpResponseMessage httpResponse = await Http.GetAsync("api/Products/" + id);

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode) return (false, new ProductsResponse());

            // Desserialize my json response
            ProductsResponse response = responseAsString.Deserialize<ProductsResponse>();

            return (true, response);
        }
        public async Task<(bool result, GenericPaginatorResponse<ProductsResponse> response)> Get(ProductsFilter filter)
        {
            string json = JsonSerializer.Serialize(filter);

            // Request my api // if were a get filter.HttpQueryBuilder()
            HttpResponseMessage httpResponse = await Http.PostAsync("api/Products/get", new StringContent(json, Encoding.UTF8, "application/json"));

            // My result as string
            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // If not success
            if (!httpResponse.IsSuccessStatusCode)
                return (false, new GenericPaginatorResponse<ProductsResponse>());

            // Desserialize my json response
            GenericPaginatorResponse<ProductsResponse> response = responseAsString.Deserialize<GenericPaginatorResponse<ProductsResponse>>();

            return (true, response);
        }
    }
}
