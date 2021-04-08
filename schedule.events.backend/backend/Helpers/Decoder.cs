using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers
{
    public class Decoder
    {
        public static string DecodeJwt(string token, string requestedClaim)
        {
            var stream = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var _claim = tokenS.Claims.First(claim => claim.Type == requestedClaim)?.Value;

            return _claim;
        }
    }
}
