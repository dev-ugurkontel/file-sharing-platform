using System;

namespace ProjectServer.Core.Configuration
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public TimeSpan ExpiryTimeFrame { get; internal set; }
    }
}
