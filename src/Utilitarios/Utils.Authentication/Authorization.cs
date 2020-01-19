
namespace Utils.Authentication
{
    public struct Authorization
    {
        public string Token { get; }

        public string Method { get; }

        private Authorization(string token, string method)
        {
            Token = token;
            Method = method;
        }

        public static Authorization Create(string token, string method = "Bearer") =>
            new Authorization(token, method);

        public static readonly Authorization Empty = new Authorization();
    }
}
