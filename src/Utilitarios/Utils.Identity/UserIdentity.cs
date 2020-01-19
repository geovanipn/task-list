using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Utils.Authentication;

namespace Utils.Identity
{
    public sealed class UserIdentity : IUser
    {
        private static readonly IUser empty = new UserIdentity();

        public static IUser Empty() => empty;

        public IDictionary<string, string> AdditionalInformations { get; private set; } = new Dictionary<string, string>();

        public string UserName { get; private set; }

        public long Id { get; private set; }

        public static IUser Create(IUser user) =>
            new UserIdentity
            {
                UserName = user.UserName,
                AdditionalInformations = user.AdditionalInformations
            };

        internal static IUser Create(IHttpContextAccessor httpContextAcessor)
        {
            var claims = httpContextAcessor.HttpContext.User.Claims;
            var additionalInformations = claims;
            var userIdentity = new UserIdentity
            {
                UserName = httpContextAcessor.HttpContext.User.Identity.Name,
            };

            foreach (var additionalInformation in additionalInformations)
            {
                userIdentity.AdditionalInformations.Add(additionalInformation.Type, additionalInformation.Value);
            }

            return userIdentity;
        }
    }
}
