using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface IPasswordHasher
    {
        byte[] Hash(byte[] salt, string password);
    }
}
