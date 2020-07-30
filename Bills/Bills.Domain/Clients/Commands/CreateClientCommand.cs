using Bills.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Bills.Domain.Clients.Commands
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public CreateClientCommand(string cellphone, string name)
        {
            Cellphone = cellphone;
            Name = name;
        }

        public string Cellphone { get; set; }
        public string Name { get; set; }
 

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Digite um nome válido"));
        }
    }
}
