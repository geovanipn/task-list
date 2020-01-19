using Utils.Authentication;

namespace Utils.Identity.Interfaces
{
    public interface IIdentity
    {
        bool HasAuthenticatedUser { get; }

        IUser AuthenticatedUser { get; }

        long GetAddtionInformationToInt64(string key);
    }
}
