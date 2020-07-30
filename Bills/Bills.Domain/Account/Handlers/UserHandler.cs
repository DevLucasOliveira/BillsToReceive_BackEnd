using Bills.Domain.Account.Commands;
using Bills.Domain.Account.Entities;
using Bills.Domain.Account.Repositories;
using Bills.Domain.Account.Services;
using Bills.Domain.Account.ValueObjects;
using Bills.Domain.Commands;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;

namespace Bills.Domain.Account.Handlers
{
    public class UserHandler : Notifiable, IHandler<RegisterUserCommand>, IHandler<AuthenticateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
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

            // Gerar o VO
            var password = new Password(command.Password);
            if(password.Invalid)
                return new GenericCommandResult(false, "Senha inválida", password.Notifications);

            // Gerar as senhas cripttografadas
            password.CreatePasswordHash(command.Password);

            // Gerar a entidade
            var user = new User(command.Name, command.UserName, password);

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
            var user = _userRepository.Authenticate(command.UserName);

            // Verificar se o usuário existe
            if (user == null)
                return new GenericCommandResult(false, "Erro ao autenticar o usuário", command.Notifications);

            // Verificar a senha criptografada
            var password = Password.VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt);

            // Verificar se as senhas são iguais
            if (!password)
                return new GenericCommandResult(false, "Senha incorreta", Notifications);

            // Agrupar as validações
            AddNotifications(user);

            // Checar as notificações
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao autenticar o usuário", command.Notifications);

            // Gerar o token
            var token = _tokenService.GenerateToken(user);

            // Retornar informações
            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", token);

        }
    }
}
