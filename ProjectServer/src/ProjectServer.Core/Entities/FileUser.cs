using Microsoft.AspNetCore.Identity;
using ProjectServer.Core.Entities.Base;
using System.ComponentModel;

namespace ProjectServer.Core.Entities
{
    public class FileUser : Entity
    {
        public FileUser()
        {
        }

        public string UserId { get; set; }
        public int FileId { get; set; }

        [DefaultValue("false")]
        public bool IsOwner { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual SharedFile File { get; set; }
    }
}
