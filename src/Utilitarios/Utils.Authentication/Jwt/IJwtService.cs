
namespace Utils.Authentication.Jwt
{
    public interface IJwtService
    {
        Authorization CreateAccessToken(IUser user);
    }
}
