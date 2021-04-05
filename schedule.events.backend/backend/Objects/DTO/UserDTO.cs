using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Objects.DTO
{
    public class UserDTO
    {
        public UserDTO(User user, string token)
        {
            Email = user.Email;
            FullName = user.FullName;
            Token = token;
            Birthday = user.Birth;
        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public string Birthday { get; set; }
    }
}
