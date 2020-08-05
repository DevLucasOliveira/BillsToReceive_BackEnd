using Bills.Shared.Commands;
using Flunt.Notifications;

namespace Bills.Domain.Admin.Commands
{
    public class CreateAdminCommand : Notifiable, ICommand
    {
        public CreateAdminCommand(long pin)
        {
            Pin = pin;
        }

        public long Pin { get; set; } 
        public void Validate() {} 
    }
}
