using ProjectServer.Core.Configuration;
using System;

namespace ProjectServer.Core.Models.DTOs.Response
{
    public class SharedFileResponse : SharedFileResult
    {
        public string RecordNo { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExt { get; set; }
        public string FileMime { get; set; }
        public string Description { get; set; }
        public byte ShareState { get; set; }
        public DateTime SharingDate { get; set; }
        public bool IsOwner { get; set; }
        public string UserId { get; set; }
    }
}
