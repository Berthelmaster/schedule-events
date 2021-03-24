using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using IP_Sniffer.Models;
using Microsoft.EntityFrameworkCore;
using IP_Sniffer.Database;

namespace IP_Sniffer.Controllers
{
    [ApiController]
    [Route("")]
    public class GeoLocationController : Controller
    {
        private readonly AppDbContext _context;

        public GeoLocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<string> Get(bool allowForwarded = true)
        {
            if (allowForwarded)
            {
                // if you are allowing these forward headers, please ensure you are restricting context.Connection.RemoteIpAddress
                // to cloud flare ips: https://www.cloudflare.com/ips/
                string header = (HttpContext.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault());
                if (IPAddress.TryParse(header, out IPAddress ip))
                {
                    return Task.FromResult(ip.ToString());
                }
            }
            return Task.FromResult(HttpContext.Connection.RemoteIpAddress.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> Post(GeoLocation geoLocation)
        {
            var ip = await _context.GeoLocations.Where(x => x.Query == geoLocation.Query).FirstOrDefaultAsync();

            if(ip == null)
            {
                await _context.GeoLocations.AddAsync(geoLocation);
                await _context.SaveChangesAsync();
            }

            return new OkObjectResult("Thank you!");
        }

        // Added Comment
        // Test
    }
}
