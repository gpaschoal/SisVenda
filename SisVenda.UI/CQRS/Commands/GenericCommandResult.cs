using System.Collections.Generic;
using SisVenda.UI.CQRS.Responses;

namespace SisVenda.UI.CQRS.Commands
{
    public class GenericCommandResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<ErrorMessage> Notifications { get; set; }
        public T Data { get; set; }
    }
}
