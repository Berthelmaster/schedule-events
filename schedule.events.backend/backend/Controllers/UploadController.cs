using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Database;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace backend.Controllers
{
    [ApiController]
    [Route("")]
    public class UploadController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UploadController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return Task.FromResult("Ok!");
        }

        [HttpPost("upload")]
        public async Task<ActionResult> UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("website", "storage");
                if (file.Length > 0)
                {
                    var userid = _httpContextAccessor.HttpContext.Request.Cookies["userid"];
                    var worthyfilename = file.ContentDisposition + userid;
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(folderName, worthyfilename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return new OkResult();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
