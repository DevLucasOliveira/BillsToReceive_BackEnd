using Bills.Shared.Commands;
using Flunt.Notifications;

namespace Bills.Domain.Admin.Commands
{
    public class CreateAdminCommand : Notifiable, ICommand
    {
        public CreateAdminCommand(decimal pin)
        {
            Pin = pin;
        }

        public decimal Pin { get; set; } 
        public void Validate() {} 
    }
}
