using System.Collections.Generic;

namespace Utils.Authentication
{
    public interface IUser
    {
        string UserName { get; }

        long Id { get; }

        IDictionary<string, string> AdditionalInformations { get; }
    }
}
