using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers
{
    public class Decoder
    {
        public enum RequestedClaims
        {
            role,
            name,
            actort,
            nbf,
            exp,
            iat,
            iss,
            aud
        }
        public static string DecodeJwt(string token, RequestedClaims requestedClaim)
        {
            var request = GetClaim(requestedClaim);
            var stream = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var _claim = tokenS.Claims.First(claim => claim.Type == request)?.Value;

            if (_claim == null) return null;

            return _claim;
        }

        private static string GetClaim(RequestedClaims claims)
        {
            return claims switch
            {
                RequestedClaims.role => "role",
                RequestedClaims.name => "name",
                RequestedClaims.actort => "actort",
                RequestedClaims.nbf => "nbf",
                RequestedClaims.exp => "exp",
                RequestedClaims.iat => "iat",
                RequestedClaims.iss => "iss",
                RequestedClaims.aud => "aud",
                _ => null,
            };
        }
    }
}
