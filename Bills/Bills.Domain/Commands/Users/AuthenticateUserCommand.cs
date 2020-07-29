using Bills.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Bills.Domain.Commands.Users
{
    public class AuthenticateUserCommand : Notifiable, ICommand
    {
        public AuthenticateUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(UserName, 3, "UserName", "Digite um nome de usuário válido")
                );
        }
    }
}
