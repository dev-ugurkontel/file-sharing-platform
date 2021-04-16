using ProjectServer.Core.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectServer.Core.Models.DTOs.Response;

namespace ProjectServer.Core.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProjectServerContext _context;

        public UsersController(ProjectServerContext context)
        {
            _context = context;
        }

        // GET: api/v1/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Users(string userId)
        {
            var items = _context.Users
                .Where(e => e.Id != userId)
                .Select(
                    p => 
                        new { 
                            p.Id, 
                            p.UserName
                        }
                ).OrderBy(e => e.UserName);

            if (items.Count() > 0)
                return Ok(await items.ToListAsync());

            return NotFound(new UserResponse()
            {
                Errors = new List<string>() {
                            "No files found"
                        },
                Success = false
            });
        }

        // GET: api/v1/<UsersController>/{id}/Files
        [HttpGet]
        [Route("{id}/Files")]
        public async Task<IActionResult> GetFilesByUserId(string id)
        {
            if (id == null)
            {
                return BadRequest(new UserResponse()
                {
                    Errors = new List<string>() {
                        "Invalid payload"
                    },
                    Success = false
                });
            }

            var items = _context.FileUser
                .Include(e => e.File)
                .Where(
                    e => 
                        e.UserId == id || 
                        e.File.ShareState == 1
                )
                .OrderByDescending(e => e.File.SharingDate);

            if (items.Count() > 0)
                return Ok(await items.ToListAsync());

            return NotFound(new UserResponse()
                {
                    Errors = new List<string>() {
                            "No files found"
                        },
                    Success = false
            });
        }
    }
}
