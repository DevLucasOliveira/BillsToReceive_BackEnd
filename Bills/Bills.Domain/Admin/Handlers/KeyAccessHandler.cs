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
            // Fail Fast Validation
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Admin inválido", command.Notifications);

            // Recuperar admin
            var admin = _adminRepository.GetAdmin(command.Admin);

            // Verificar se existe o admin
            if (admin == null)
                return new GenericCommandResult(false, "Admin inválido", command.Notifications);

            // Gerar a entidade 
            var key = new KeyAccess();

            // Gerar a chave de acesso
            key.GenerateKeyAccess();

            // Validar a chave de acesso
            key.ValidateKey();

            // Salvar no banco
            _keyAccessRepository.Create(key);

            // Retornar informações
            return new GenericCommandResult(true, "Chave gerada com sucesso", key);
        }
    }
}
