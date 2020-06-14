using SisVenda.UI.CQRS.Commands;
using SisVenda.UI.CQRS.Filters;
using SisVenda.UI.CQRS.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisVenda.UI.Requests
{
    interface IRequestBase<C, U, D, R, F> 
        where C : ICreateCommand
        where U : IUpdateCommand
        where D : IDeleteCommand
        where R : IResponse
        where F : IFilter
    {
        Task<(bool result, string message, List<ErrorMessage> Notifications, R Data)> Create(C command);
        Task<(bool result, string message, List<ErrorMessage> Notifications, R Data)> Update(U command);
        Task<(bool result, string message, object response)> Delete(D command);
        Task<(bool result, R response)> GetById(string id);
        Task<(bool result, GenericPaginatorResponse<R> response)> Get(F filter);
    }
}
