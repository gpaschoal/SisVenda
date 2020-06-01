using Flunt.Notifications;
using SisVenda.Domain.Commands.Contracts;
using SisVenda.Domain.Responses;
using System.Collections.Generic;

namespace SisVenda.Domain.Commands
{
    /// <summary>
    /// T -> My return type return
    /// </summary>
    public class GenericCommandResult<T> : ICommandResult<T> where T : IResponse, new()
    {
        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Message = message;
            Notifications = notifications;
            Data = new T();
        }

        public GenericCommandResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Notifications = new List<Notification>();
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }
        public T Data { get; set; }
    }
}
