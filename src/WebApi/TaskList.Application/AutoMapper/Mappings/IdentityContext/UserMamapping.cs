using TaskList.Application.IdentityContext.InputModels;
using TaskList.Domain.IdentityContext.Commands;

namespace TaskList.Application.AutoMapper.Mappings.IdentityContext
{
    public static class UserMamapping
    {
        public static void UserMapper(this InputModelToDomainMappingProfile profile)
        {
            profile.CreateMap<AuthenticateUserInputModel, AuthenticateUserCommand>()
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .ConstructUsing(x => AuthenticateUserCommand.Create(
                    x.UserName,
                    x.Password));
        }
    }
}
