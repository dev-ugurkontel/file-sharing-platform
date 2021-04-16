using ProjectServer.Core.Configuration;
using System;
using System.ComponentModel;

namespace ProjectServer.Core.Models.DTOs.Requests
{
    public class SharedFileRequest : SharedFileResult
    {
        public string RecordNo { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExt { get; set; }
        public string FileMime { get; set; }
        public string Description { get; set; }

        [DefaultValue("getdate()")]
        public byte ShareState { get; set; }

        [DefaultValue("getdate()")]
        public DateTime SharingDate { get; set; }
        public bool IsOwner { get; set; }
        public string UserId { get; set; }
        public string UsersIds { get; set; }
        public string id { get; set; }
    }
}
