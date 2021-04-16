using ProjectServer.Core.Configuration.Base;

namespace ProjectServer.Core.Configuration
{
    public class AuthResult : ConfigurationBase
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
