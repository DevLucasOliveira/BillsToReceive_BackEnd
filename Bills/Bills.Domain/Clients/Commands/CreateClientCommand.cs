using Bills.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Bills.Domain.Clients.Commands
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public CreateClientCommand(string cellphone, string name, Guid user)
        {
            Cellphone = cellphone;
            Name = name;
            User = user;
        }

        public string Cellphone { get; set; }
        public string Name { get; set; }
        public Guid User { get; set; }
 
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Digite um nome válido"));
        }
    }
}
