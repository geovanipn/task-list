using System.Collections.Generic;
using Utils.Authentication;

namespace TaskList.Domain.IdentityContext.OutputModels
{
    public sealed class UserAuthorizationOutputModel : IUser
    {
        private IDictionary<string, string> _additionalInformations;

        public string UserName { get; }

        public long Id { get; }

        public UserAuthorizationOutputModel(in long id, in string userName)
        {
            UserName = userName;
            Id = id;
        }

        public IDictionary<string, string> AdditionalInformations
        {
            get
            {
                return _additionalInformations ??
                    (_additionalInformations = LoadAdditionalInformations());
            }
        }

        private IDictionary<string, string> LoadAdditionalInformations() =>
            new Dictionary<string, string>
            {
                { "IdUser", Id.ToString() },
            };
    }
}
