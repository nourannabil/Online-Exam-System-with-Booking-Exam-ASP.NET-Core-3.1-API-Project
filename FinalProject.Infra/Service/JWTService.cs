using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class JWTService: IJWTService
    {
        private readonly IJWTRepository _jWTRepository;

        public JWTService(IJWTRepository jWTRepository)
        {
            _jWTRepository = jWTRepository;
        }

        public string UserLogin(JWT jwt)
        {
            var result = _jWTRepository.UserLogin(jwt);
            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                if (result.Imagepath != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Username", result.Username),
                        new Claim("Roleid", result.Roleid.ToString()),
                        new Claim("Userid", result.Userid.ToString()),
                        new Claim("FirstName", result.Fname),
                        new Claim("LastName", result.Lname),
                        new Claim("Image", result.Imagepath),
                        new Claim("Email", result.Email)

                    };
                    var tokeOptions = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return tokenString;
                }else
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Username", result.Username),
                        new Claim("Roleid", result.Roleid.ToString()),
                        new Claim("Userid", result.Userid.ToString()),
                        new Claim("FirstName", result.Fname),
                        new Claim("LastName", result.Lname),
                        new Claim("Email", result.Email)

                    };
                    var tokeOptions = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return tokenString;
                }

            }
        }
    }
}
