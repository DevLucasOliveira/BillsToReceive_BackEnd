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
            // Fail Fast Validation
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Erro ao registrar o usuário", command.Notifications);

            // Verificar se o nome de usuário ja esta cadastrado
            if (_userRepository.UserNameExists(command.UserName))
                return new GenericCommandResult(false, "Usuário já existe", command.UserName);

            // Verificar se a chave de acesso é valida
            if (!_keyAccessRepository.KeyAccessExists(command.KeyAccess))
                return new GenericCommandResult(false, "Chave de acesso inválida", command.UserName);

            // Recuperar a chave de acesso
            var keyAccess = _keyAccessRepository.GetKeyAccess(command.KeyAccess);

            // Gerar o VO
            var password = new Password(command.Password);
            if(password.Invalid)
                return new GenericCommandResult(false, "Senha inválida", password.Notifications);

            // Gerar as senhas criptografadas
            password.CreatePasswordHash(command.Password);

            // Gerar a entidade
            var user = new User(command.Name, command.UserName, password);

            // Adicionar a chave de acesso ao relacionamento
            user.AddKeyAccess(keyAccess);

            // Salvar no banco
            _keyAccessRepository.Update(keyAccess);

            // Salvar no banco
            _userRepository.Register(user);

            // Retornar informações
            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", user);
        }

        public ICommandResult Handle(AuthenticateUserCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if(Invalid)
                return new GenericCommandResult(false, "Erro ao autenticar o usuário", command.Notifications);

            // Recuperar o usuário
            var userVerify = _userRepository.Authenticate(command.UserName);

            // Verificar se o usuário existe
            if (userVerify.Count() == 0)
                return new GenericCommandResult(false, "Usuário inválido", command.Notifications);

            // Retornando o usuário
            var user = userVerify.First();

            // Verificar a senha criptografada
            var password = Password.VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt);

            // Verificar se as senhas são iguais
            if (!password)
                return new GenericCommandResult(false, "Senha incorreta", Notifications);

            // Verifica se a chave de acesso está validá
            if (!_keyAccessRepository.ValidKeyAccess(user.KeyAccess.Key))
                return new GenericCommandResult(false, "Chave de acesso inválida", command.UserName);

            // Agrupar as validações
            AddNotifications(user);

            // Checar as notificações
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao autenticar o usuário", command.Notifications);

            // Gerar o token
            var token = _tokenService.GenerateToken(user);

            // Adicionar o Token
            user.AddToken(token);

            // Retornar informações
            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", user);

        }
    }
}
