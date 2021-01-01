using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MsToken = Microsoft.IdentityModel.Tokens;

namespace TomatoFarm.Api.Identity
{

    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _issuer = string.Empty;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            var audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            var symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var securityKey = new MsToken.SymmetricSecurityKey(keyByteArray);
            var signingCredentials = new MsToken.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token); ;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}
