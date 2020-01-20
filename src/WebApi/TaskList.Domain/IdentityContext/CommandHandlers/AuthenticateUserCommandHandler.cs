using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskList.Domain.IdentityContext.Commands;
using TaskList.Domain.IdentityContext.Interfaces.Repositories;
using TaskList.Domain.IdentityContext.Models;
using TaskList.Domain.IdentityContext.OutputModels;
using TaskList.Domain.SharedContext.CommandHandler;
using TaskList.Domain.SharedContext.Notifications;
using Utils.Authentication;
using Utils.Authentication.Jwt;
using Utils.Domain.Interfaces;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Domain.IdentityContext.CommandHandlers
{
    public sealed class AuthenticateUserCommandHandler :
        CommandHandler,
        IRequestHandler<AuthenticateUserCommand, Authorization>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthenticateUserCommandHandler(
            IMediatorService mediatorService, 
            IDbContext dbContext,
            IUserRepository userRepository,
            IJwtService jwtService) : base(mediatorService, dbContext)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<Authorization> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: arrumar
            var superoUser = await _userRepository.GetByName("supero");
            if (superoUser == null)
            {
                await _userRepository.Add(User.Create("supero", "123456"));
                await Commit();
            }


            if (!await CommandIsValid(request)) return Authorization.Empty;

            var user = await _userRepository.GetByName(request.UserName);
            if(user == null) 
            {
                await _mediatorService.SendNotification(new DomainNotification(request.Name, "Usuário não encontrado!"));
                return Authorization.Empty;
            }

            if(user.Password != request.Password)
            {
                await _mediatorService.SendNotification(new DomainNotification(request.Name, "Senha inválida!"));
                return Authorization.Empty;
            }

            var userAuthorizationOutputModel = new UserAuthorizationOutputModel(user.Id, user.Name);
            return _jwtService.CreateAccessToken(userAuthorizationOutputModel);
        }

        public override void Dispose()
        {
            _userRepository.Dispose();
            base.Dispose();
        }
    }
}
