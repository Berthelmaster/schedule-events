using backend.Database;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using backend.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(Register register)
        {
            var user = await _context.Users.Where(x => x.Email == register.Email).FirstOrDefaultAsync();

            if(user != null)
            {
                return new BadRequestResult();
            }

            var salt = Guid.NewGuid().ToByteArray();

            var createUser = new User
            {
                FullName = register.FullName,
                Email = register.Email,
                Birth = register.Birth,
                Salt = salt,
                Hash = _passwordHasher.Hash(salt, register.Password)
            };

            await _context.Users.AddAsync(createUser);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login login)
        {
            var user = await _context.Users.Where(x => x.Email == login.Email).FirstOrDefaultAsync();

            if(user == null)
            {
                return new BadRequestResult();
            }

            if (!user.IsApproved)
            {
                return new BadRequestResult();
            }

            if(!user.Hash.SequenceEqual(_passwordHasher.Hash(user.Salt, login.Password)))
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(user);
        }
    }
}
