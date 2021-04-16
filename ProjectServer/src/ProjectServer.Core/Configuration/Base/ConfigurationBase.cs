using System.Collections.Generic;

namespace ProjectServer.Core.Configuration.Base
{
    public class ConfigurationBase
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
