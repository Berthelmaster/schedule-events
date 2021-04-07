using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> GenerateToken(string role, string email, string userid);
    }
}
