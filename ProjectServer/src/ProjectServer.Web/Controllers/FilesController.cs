using ProjectServer.Core.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectServer.Core.Models.DTOs.Requests;
using System.IO;
using ProjectServer.Core.Models.DTOs.Response;
using ProjectServer.Core.Entities;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ProjectServer.Core.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ProjectServerContext _context;

        public FilesController(ProjectServerContext context)
        {
            _context = context;
        }

        // POST: api/v1/<FilesController>
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Files([FromForm] SharedFileRequest files)
        {
            if (files == null)
                return Content("file not selected");

            try
            {
                var random = new Random();
                var chars = "abcdefghijklmopqrstuwxyz0123456789";
                var newStr = new string(Enumerable.Repeat(chars, 32)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                var file = Request.Form.Files[0];
                var fileName = files.FileName;
                var fileExt = Path.GetExtension(file.FileName);
                var fileMime = file.ContentType;
                var fileDescription = files.Description;
                var fileShareState = files.ShareState;
                var isOwner = files.IsOwner;
                var userId = files.UserId;
                var folderName = "uploads/files/";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var recordNo = GetRecordNo();
                var physicalFilePath = Path.Combine(pathToSave, (recordNo + "-" + newStr) + fileExt);
                var virtualFilePath = (folderName + recordNo + "-" + newStr + fileExt);

                if (file.Length > 0)
                {
                    var data = new SharedFileRequest()
                    {
                        Success = true,
                        RecordNo = recordNo,
                        FilePath = virtualFilePath,
                        FileName = fileName,
                        FileExt = fileExt,
                        FileMime = fileMime,
                        Description = fileDescription,
                        ShareState = fileShareState,
                        SharingDate = DateTime.Now,
                        IsOwner = true,
                        UserId = userId,
                        UsersIds = files.UsersIds
                    };

                    if (SaveFileToDatabase(data).Result)
                    {
                        using (var stream = new FileStream(physicalFilePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        return Ok(data);
                    }

                    return BadRequest(new SharedFileResponse()
                    {
                        Errors = new List<string>() {
                                "Error"
                            },
                        Success = false
                    });
                }
                else
                {
                    return BadRequest(new SharedFileResponse()
                    {
                        Errors = new List<string>() {
                                "Error"
                            },
                        Success = false
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // PUT: api/v1/<FilesController>/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFile(long id, [FromForm] SharedFileRequest file)
        {
            Debug.WriteLine(id, file.Description);

            try
            {
                if (id <= 0)
                {
                    return BadRequest(new SharedFileResponse()
                    {
                        Errors = new List<string>() {
                                "Error"
                            },
                        Success = false
                    });
                }

                var entity = _context.Files.FirstOrDefault(e => e.Id == id);

                if (entity != null)
                {
                    entity.Description = file.Description;

                    _context.Attach(entity);
                    _context.Entry(entity).Property(p => p.Description).CurrentValue = file.Description;

                    await _context.SaveChangesAsync();

                    return Ok(new SharedFileResponse()
                    {
                        Success = true,
                        Description = file.Description
                    });
                }

                return BadRequest(new SharedFileResponse()
                {
                    Errors = new List<string>() {
                                "Error"
                            },
                    Success = false
                });
            }
            catch
            {
                return NotFound(new SharedFileResponse()
                {
                    Errors = new List<string>() {
                                "Error"
                            },
                    Success = false
                });
            }
        }

        // DELETE: api/v1/<FilesController>/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteFile(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid file id");

                var data = _context.Files
                    .Where(e => e.Id == id)
                    .FirstOrDefault();

                if (data == null)
                {
                    return BadRequest(new SharedFileResponse()
                    {
                        Errors = new List<string>() {
                                "Error"
                            },
                        Success = false
                    });
                }

                var filePath = _context.Files
                    .Where(e => e.Id == id)
                    .Select(
                        p =>
                            new {
                                p.RecordNo,
                                p.FileExt
                            }
                    );

                if (filePath != null)
                {
                    foreach (var item in filePath)
                    {
                        var folderName = Path.Combine("Uploads", "Files\\");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        var recordNo = GetRecordNo();
                        var physicalFilePath = Path.Combine(pathToSave, item.RecordNo + item.FileExt);

                        if (physicalFilePath != null)
                            System.IO.File.Delete(physicalFilePath);

                    }
                }

                _context.Files.Remove(data);
                _context.SaveChanges();

                return Ok(new SharedFileResponse()
                {
                    Success = true
                });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetRecordNo()
        {
            var fileCount = _context.Files
                .Select(
                    p =>
                        new {
                            p.Id
                        }
                );

            return (DateTime.Today.ToString("yy.MM.") + (fileCount.Count() + 1).ToString("D5"));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<bool> SaveFileToDatabase(SharedFileRequest file)
        {
            if (file == null)
                return false;

            try
            {
                SharedFile sharedFileData = new SharedFile()
                {
                    RecordNo = file.RecordNo,
                    FilePath = file.FilePath,
                    FileName = file.FileName,
                    FileExt = file.FileExt,
                    FileMime = file.FileMime,
                    Description = file.Description,
                    ShareState = file.ShareState,
                    SharingDate = file.SharingDate,
                    IsOwner = file.IsOwner,
                    UserId = file.UserId
                };

                FileUser fileUserData;

                // if file isPublic with select dropdown users
                List<SharedFileRequest> items = JsonConvert.DeserializeObject<List<SharedFileRequest>>(file.UsersIds);
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        fileUserData = new FileUser()
                        {
                            IsOwner = false,
                            UserId = item.id
                        };
                        fileUserData.File = sharedFileData;
                        _context.FileUser.AddRange(fileUserData);
                    }
                }

                // if file owner, add every request
                fileUserData = new FileUser()
                {
                    IsOwner = true,
                    UserId = file.UserId
                };

                fileUserData.File = sharedFileData;
                _context.FileUser.Add(fileUserData);
                _context.Files.Add(sharedFileData);
                var created = await _context.SaveChangesAsync();

                return created > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
