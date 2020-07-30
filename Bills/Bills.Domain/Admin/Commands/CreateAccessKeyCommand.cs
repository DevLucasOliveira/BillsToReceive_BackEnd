using Bills.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Bills.Domain.Admin.Commands
{
    public class CreateAccessKeyCommand : Notifiable, ICommand
    {
        public CreateAccessKeyCommand(Guid admin)
        {
            Admin = admin;
        }

        public Guid Admin { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmpty(Admin, "Admin", "Admin inválido"));
        }
    }
}
