using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;

using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinanceProcessor.Core.Aggregates.security
{
    public class AuthorizationService : IAuthorizationService
    {
        private const string claimsPath = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        private const string AuthKey = "09CMB101N02748B842989813F19E4BF7668B3A509167A94FF9E35E4AF0EA2F39";

        private readonly ISecurity _security = new SecurityCrypts();

        public string? GenerateToken(PayLoad model)
        {
            var payload = JsonConvert.SerializeObject(model);
            IdentityModelEventSource.ShowPII = true;

            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthKey));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var secToken = new JwtSecurityToken(signingCredentials: credentials,
                    //issuer: _authenticationOptions.BFFDomain,
                    audience: null, claims: new[] { new Claim(JwtRegisteredClaimNames.Sub, payload) },
                    expires: DateTime.UtcNow.AddHours(1));

                var handler = new JwtSecurityTokenHandler();

                var tokenString = handler.WriteToken(secToken);

                var encrypt = _security.EncryptStringToBytes(tokenString);

                return Convert.ToBase64String(encrypt);
            }
            catch (Exception e)
            {
                Trace.TraceError($"AuthricationService GenerateToken\n Error Message: {e}");
                throw;
            }
        }

        public bool ValidateToken(string? token, UserRole userRole, PayLoad payload)
        {
            bool isValidate = false;
            IdentityModelEventSource.ShowPII = true;
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = GetValidationParameters(/*BFFDomain*/null, null, AuthKey); ;

                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

                var claim = principal.Claims.SingleOrDefault(a => a.Type == claimsPath);

                if (claim is null)
                {
                    return false;
                }

                var result = JsonConvert.DeserializeObject<PayLoad>(claim.Value);

                _ = Enum.TryParse(result?.UserRole, out UserRole tokenUserRole);

                if (result.WebId.Equals(payload.WebId, StringComparison.Ordinal)
                    && GetDozens((int)tokenUserRole) >= GetDozens((int)userRole))
                {
                    isValidate = true;
                }

                return isValidate;
            }
            catch (Exception e)
            {
                Trace.TraceError($"AuthricationService ValidateToken\n Error Message {e}");
                return isValidate;
            }
        }

        private static int GetDozens(int tokenUserRole)
        {
            float role = tokenUserRole / 10;
            return (int)role;
        }

        private static TokenValidationParameters GetValidationParameters(string issuer, string? audience, string authKey)
        {
            return new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(authKey))
            };
        }
    }
}
