using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Configuration;
using System.Web.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            GenerateJwtToken();

            // Web API routes
            config.MapHttpAttributeRoutes();

           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static string GenerateJwtToken()
        {
            // Set the secret key used to sign the token
            var secretKey = "Password123!!!Pasword123!!!Password123!!!";
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Create a signing credentials object using the symmetric key
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature, secretKey);

            // Create a list of claims (optional)
            var claims = new[]
            {
                new Claim("ClaimName1", "ClaimValue1"),
                new Claim("ClaimName2", "ClaimValue2")
                // Add additional claims as needed
            };

            // Create the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),// Set the token expiration time
                SigningCredentials = signingCredentials
            };

            // Create a token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate the JWT token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Serialize the token to a string
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
   
}
