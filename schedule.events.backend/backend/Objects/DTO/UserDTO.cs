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

        public UserDTO(User user)
        {
            Email = user.Email;
            FullName = user.FullName;
            Birthday = user.Birth;
            IsApproved = user.IsApproved;
            Role = user.Role;
        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public string Birthday { get; set; }
        public bool IsApproved { get; set; }
        public string Role { get; set; }
    }
}
