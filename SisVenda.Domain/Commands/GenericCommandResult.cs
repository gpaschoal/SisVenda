using Flunt.Notifications;
using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Responses;
using System.Collections.Generic;

namespace SisVenda.Domain.Commands
{
    /// <summary>
    /// T -> My response
    /// </summary>
    public class GenericCommandResult<T> : ICommandResult<T> where T : IResponse
    {
        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Message = message;
            Notifications = notifications;
        }

        public GenericCommandResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }
        public T Data { get; set; }
    }
}
