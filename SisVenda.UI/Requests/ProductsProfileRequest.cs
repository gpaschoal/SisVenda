using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SisVenda.UI.Requests
{
    public class ProductsProfileRequest : 
        AbstractRequest,
        IRequestBase<ProductsProfileCreateCommand, ProductsProfileUpdateCommand, ProductsProfileDeleteCommand, ProductsProfileResponse, ProductsProfileFilter>
    {
        public ProductsProfileRequest(HttpClient http) : base(http) { }

        public Task<(bool result, string message, List<ErrorMessage> Notifications, ProductsProfileResponse Data)> Create(ProductsProfileCreateCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, string message, object response)> Delete(ProductsProfileDeleteCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, GenericPaginatorResponse<ProductsProfileResponse> response)> Get(ProductsProfileFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, ProductsProfileResponse response)> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, string message, List<ErrorMessage> Notifications, ProductsProfileResponse Data)> Update(ProductsProfileUpdateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
