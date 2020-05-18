using System;
using System.Net.Http;
using System.Threading.Tasks;
using SisVenda.UI.CQRS.Commands;

namespace SisVenda.UI.Requests
{
    public class PeopleRequest : AbstractRequest
    {
        public PeopleRequest(HttpClient http) : base(http) { }

        public async Task<(bool, string)> Create(CreatePeopleCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool, string)> Update(CreatePeopleCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool, string)> Delete(DeletePeopleCommand command)
        {
            throw new NotImplementedException();
        }
    }
}