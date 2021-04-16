using ProjectServer.Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectServer.Core.Entities
{
    public class SharedFile : Entity
    {
        public SharedFile()
        {
        }

        public string RecordNo { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExt { get; set; }
        public string FileMime { get; set; }
        public string Description { get; set; }    
        public byte ShareState { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime SharingDate { get; set; }

        [NotMapped]
        public virtual FileUser FileUser { get; set; }

        [NotMapped]
        public bool IsOwner { get; set; }

        [NotMapped]
        public string UserId { get; set; }
    }
}
