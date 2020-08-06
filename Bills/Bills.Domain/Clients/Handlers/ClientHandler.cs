using Bills.Domain.Account.Repositories;
using Bills.Domain.Clients.Commands;
using Bills.Domain.Clients.Entities;
using Bills.Domain.Clients.Repositories;
using Bills.Domain.Commands;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;
using System.Linq;

namespace Bills.Domain.Clients.Handlers
{
    public class ClientHandler : Notifiable, IHandler<CreateClientCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;

        public ClientHandler(IUserRepository userRepository, IClientRepository clientRepository)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
        }

        public ICommandResult Handle(CreateClientCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Nome muito curto", command.Notifications);

            // Verificar se o nome do cliente já existe
            if (_clientRepository.NameAlreadyExists(command.User, command.Name))
                return new GenericCommandResult(false, "Cliente já cadastrado", command.Name);

            // Verificar se o usuário existe
            if (!_userRepository.UserExists(command.User))
                return new GenericCommandResult(false, "Usuário inválido", command.Notifications);

            // Recuperar o usuário
            var user = _userRepository.GetUserById(command.User).First();

            // Gerar a entidade
            var client = new Client(command.Name, command.Cellphone);

            // Agrupar validações
            AddNotifications(client, user);

            // Verificar se há algum erro
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", Notifications);

            // Adicionar o cliente na lista do usuário
            user.AddClient(client);

            // Salvar no banco
            _userRepository.Update(user);

            // Salvar no banco
            _clientRepository.Create(client);

            // Retornar informações
            return new GenericCommandResult(true, "Cliente cadastrado com sucesso", user);
        }
    }
}
