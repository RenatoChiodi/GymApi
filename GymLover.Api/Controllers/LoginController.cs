//using GymLover.DataAccess.Context;
//using GymLover.Domain;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Security.Principal;

//namespace GymLover.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        private readonly GymLoverDbContext _context;
//        public LoginController(GymLoverDbContext context)
//        {
//            _context = context;
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public object Post(
//            [FromBody]User usuario,
// //           [FromServices]SigningConfigurations signingConfigurations,
// //           [FromServices]TokenConfigurations tokenConfigurations)
//        {
//            bool credenciaisValidas = false;
//            User usuarioBase = null;

//            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UserName))
//            {
//                usuarioBase = _context.User.Where(u => u.UserName == usuario.UserName)
//                .Select(s => s).FirstOrDefault();

//                credenciaisValidas = (usuarioBase != null &&
//                    usuario.UserName == usuarioBase.UserName &&
//                    usuario.PasswordHash == usuarioBase.PasswordHash);
//            }

//            if (credenciaisValidas)
//            {
//                ClaimsIdentity identity = new ClaimsIdentity(
//                new GenericIdentity(usuario.UserName, "Login"),
//                    new[] {
//                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
//                            new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName)
//                    }
//                );

//                DateTime dataCriacao = DateTime.Now;
//                DateTime dataExpiracao = dataCriacao +
//                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

//                var handler = new JwtSecurityTokenHandler();
//                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
//                {
//                    Issuer = tokenConfigurations.Issuer,
//                    Audience = tokenConfigurations.Audience,
// //                   SigningCredentials = signingConfigurations.SigningCredentials,
//                    Subject = identity,
//                    NotBefore = dataCriacao,
//                    Expires = dataExpiracao
//                });
//                var token = handler.WriteToken(securityToken);

//                return new
//                {
//                    userId = usuarioBase.Id,
//                    authenticated = true,
//                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
//                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
//                    accessToken = token,
//                    message = "OK"
//                };
//            }
//            else
//            {
//                return new
//                {
//                    authenticated = false,
//                    message = "Falha ao autenticar"
//                };
//            }

//        }
//    }
//}