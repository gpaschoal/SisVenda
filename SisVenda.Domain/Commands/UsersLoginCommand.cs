using Flunt.Notifications;
using SisVenda.Domain.Commands.Contracts;

namespace SisVenda.Domain.Commands
{
    public class UsersLoginCommand : Notifiable, ICommand
    {
        public UsersLoginCommand() { }

        public UsersLoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public void Validate()
        {
            if (string.IsNullOrEmpty(Username))
                AddNotification("Username", "Usuário inválido");
            if (string.IsNullOrEmpty(Password))
                AddNotification("Password", "Senha inválido");
        }
    }
}
