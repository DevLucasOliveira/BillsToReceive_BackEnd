using Bills.Domain.Admin.Commands;
using Bills.Domain.Admin.Entities;
using Bills.Domain.Admin.Repositories;
using Bills.Domain.Commands;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;

namespace Bills.Domain.Admin.Handlers
{
    public class KeyAccessHandler : Notifiable, IHandler<CreateAccessKeyCommand>
    {
        private readonly IKeyAccessRepository _keyAccessRepository;
        private readonly IAdminRepository _adminRepository;

        public KeyAccessHandler(IKeyAccessRepository keyAccessRepository, IAdminRepository adminRepository)
        {
            _keyAccessRepository = keyAccessRepository;
            _adminRepository = adminRepository;
        }

        public ICommandResult Handle(CreateAccessKeyCommand command)
        {
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Admin inválido", command.Notifications);

            var admin = _adminRepository.GetAdmin(command.Admin);

            if (admin == null)
                return new GenericCommandResult(false, "Admin inválido", command.Notifications);

            var key = new KeyAccess();

            key.GenerateKeyAccess();

            key.ValidateKey();

            _keyAccessRepository.Create(key);

            return new GenericCommandResult(true, "Chave gerada com sucesso", key);
        }
    }
}
