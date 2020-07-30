using Bills.Domain.Admin.Commands;
using Bills.Domain.Commands;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;

namespace Bills.Domain.Admin.Handlers
{
    public class KeyAccessHandler : Notifiable, IHandler<CreateAccessKeyCommand>
    {
        public ICommandResult Handle(CreateAccessKeyCommand command)
        {
            // Retornar informações
            return new GenericCommandResult(true, "Chave gerada com sucesso", command);
        }
    }
}
