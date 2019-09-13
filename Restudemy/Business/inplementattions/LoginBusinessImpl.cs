using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Restudemy.Data.Converters;
using Restudemy.Data.VO;
using Restudemy.Model;
using Restudemy.Repository;
using Restudemy.Repository.Generic;
using Restudemy.Secutity.Configuration;

namespace Restudemy.Business.inplementattions
{
    public class LoginBusinessImpl : ILoginBusiness
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfiguration _tokenConfiguration;
        public LoginBusinessImpl(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfiguration tokenConfiguration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin(UserVO user)
        {
            bool credentialIsValid = false;
            if(user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);
                credentialIsValid = (baseUser != null && user.Login == baseUser.Login && user.AccessKey == baseUser.Accesskey);
            }
            if (credentialIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login,"Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                    }
                    );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
           
                return SuccessObject( createDate, expirationDate, token);
            }
            else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securiryToke = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securiryToke);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate,string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message= "ok"
            };
        }

        private object ExceptionObject()
        {
            return new {
                autenticated = false,
                accessToken= "Failed to autheticate"
            };

        }
    }
}
