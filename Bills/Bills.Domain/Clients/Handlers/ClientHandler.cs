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
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Nome muito curto", command.Notifications);

            if (_clientRepository.NameAlreadyExists(command.User, command.Name))
                return new GenericCommandResult(false, "Cliente já cadastrado", command.Name);

            if (!_userRepository.UserExists(command.User))
                return new GenericCommandResult(false, "Usuário inválido", command.Notifications);

            var user = _userRepository.GetUserById(command.User).First();

            var client = new Client(command.Name, command.Cellphone);

            AddNotifications(client, user);

            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", Notifications);

            user.AddClient(client);

            _userRepository.Update(user);

            _clientRepository.Create(client);

            return new GenericCommandResult(true, "Cliente cadastrado com sucesso", user);
        }
    }
}
