using Microsoft.AspNetCore.Http;
using System;
using Utils.Authentication;
using Utils.Identity.Interfaces;

namespace Utils.Identity
{
    public class Identity : IIdentity
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public Identity(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool HasAuthenticatedUser =>
            httpContextAccessor != null &&
            httpContextAccessor.HttpContext != null &&
            httpContextAccessor.HttpContext.User != null &&
            httpContextAccessor.HttpContext.User.Identity != null &&
            httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public IUser AuthenticatedUser =>
            HasAuthenticatedUser
                ? UserIdentity.Create(httpContextAccessor)
                : null;

        public long GetAddtionInformationToInt64(string key) =>
            GetAdditionalInformationFromAuthenticatedUser(key, Convert.ToInt64);

        private T GetAdditionalInformationFromAuthenticatedUser<T>(string key, Func<string, T> funcConversionValue)
        {
            if (!HasAuthenticatedUser) return default(T);

            return funcConversionValue.Invoke(AuthenticatedUser.AdditionalInformations[key]);
        }
    }
}
