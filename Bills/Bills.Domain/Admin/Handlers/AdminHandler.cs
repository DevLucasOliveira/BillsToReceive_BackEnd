using Bills.Domain.Admin.Commands;
using Bills.Domain.Admin.Entities;
using Bills.Domain.Admin.Repositories;
using Bills.Domain.Commands;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;

namespace Bills.Domain.Admin.Handlers
{
    public class AdminHandler : Notifiable, IHandler<CreateAdminCommand>
    {
        private readonly IAdminRepository _adminRepository;

        public AdminHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public ICommandResult Handle(CreateAdminCommand command)
        {
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Admin inválido", command.Notifications);

            var admin = new UserAdmin(command.Pin);

            _adminRepository.Create(admin);

            return new GenericCommandResult(true, "Admin criado com sucesso", admin);
        }
    }
}
