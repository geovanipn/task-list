using TaskList.Application.IdentityContext.Interfaces;
using System.Threading.Tasks;
using TaskList.Application.IdentityContext.InputModels;
using AutoMapper;
using MediatR;
using TaskList.Domain.IdentityContext.Commands;
using Utils.Authentication;
using Utils.Domain.Interfaces;

namespace TaskList.Application.IdentityContext.Services
{
    public sealed class LoginAppService : ILoginAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorService _mediatorService;

        public LoginAppService(
            IMediatorService mapperService,
            IMapper mapper)
        {
            _mapper = mapper;
            _mediatorService = mapperService;
        }

        public async Task<Authorization> Authenticate(AuthenticateUserInputModel authenticateUserInputModel)
        {
            return await _mediatorService.SendCommand(_mapper.Map<AuthenticateUserCommand>(authenticateUserInputModel));
        }
    }
}
