using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController
    {
        private static string FrontendVersion => "1";

        [HttpGet]
        public Task<string> Get()
        {
            return Task.FromResult(FrontendVersion);
        }
    }
}
