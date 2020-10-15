using Bills.Domain.Account.Commands;
using Bills.Domain.Account.Entities;
using Bills.Domain.Account.Repositories;
using Bills.Domain.Account.Services;
using Bills.Domain.Account.ValueObjects;
using Bills.Domain.Admin.Repositories;
using Bills.Domain.Commands;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;
using System.Linq;

namespace Bills.Domain.Account.Handlers
{
    public class UserHandler : Notifiable, IHandler<RegisterUserCommand>, IHandler<AuthenticateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IKeyAccessRepository _keyAccessRepository;

        public UserHandler(IUserRepository userRepository, ITokenService tokenService, IKeyAccessRepository keyAccessRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _keyAccessRepository = keyAccessRepository;
        }

        public ICommandResult Handle(RegisterUserCommand command)
        {
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Erro ao registrar o usuário", command.Notifications);

            if (_userRepository.UserNameExists(command.UserName))
                return new GenericCommandResult(false, "Usuário já existe", command.UserName);

            if (!_keyAccessRepository.KeyAccessExists(command.KeyAccess))
                return new GenericCommandResult(false, "Chave de acesso inválida", command.UserName);

            var keyAccess = _keyAccessRepository.GetKeyAccess(command.KeyAccess);

            var password = new Password(command.Password);
            if(password.Invalid)
                return new GenericCommandResult(false, "Senha inválida", password.Notifications);

            password.CreatePasswordHash(command.Password);

            var user = new User(command.Name, command.UserName, password);

            user.AddKeyAccess(keyAccess);

            _keyAccessRepository.Update(keyAccess);
            _userRepository.Register(user);

            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", user);
        }

        public ICommandResult Handle(AuthenticateUserCommand command)
        {
            command.Validate();
            if(Invalid)
                return new GenericCommandResult(false, "Erro ao autenticar o usuário", command.Notifications);

            var userVerify = _userRepository.Authenticate(command.UserName);

            if (userVerify.Count() == 0)
                return new GenericCommandResult(false, "Usuário inválido", command.Notifications);

            var user = userVerify.First();

            var password = Password.VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt);

            if (!password)
                return new GenericCommandResult(false, "Senha incorreta", Notifications);

            if (!_keyAccessRepository.ValidKeyAccess(user.KeyAccess.Key))
                return new GenericCommandResult(false, "Chave de acesso inválida", command.UserName);

            AddNotifications(user);

            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao autenticar o usuário", command.Notifications);

            var token = _tokenService.GenerateToken(user);

            user.AddToken(token);

            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", user);
        }
    }
}
