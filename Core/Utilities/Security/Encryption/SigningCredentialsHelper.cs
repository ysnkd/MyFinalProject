using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //signingcredeantial :kullanıcı adı pardoladır.
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
            //hangi anahtar,hangi algoritma
        }
    }
}
