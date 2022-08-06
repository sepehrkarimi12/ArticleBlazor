﻿using BlazorApp2.Server.Context;
using BlazorApp2.Shared.Entities;
using BlazorApp2.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Controllers
{
    namespace BlazorApp2.Server.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly IConfiguration _config;
            private readonly AppDbContext _db;
            private readonly ProtectPasswordHelper _protectPassword;
            public AuthController(IConfiguration config, AppDbContext db,
                ProtectPasswordHelper protect)
            {
                _config = config;
                _db = db;
                _protectPassword = protect;
            }
            [HttpPost("Login")]
            public async Task<ActionResult<TokenDataHelper>> Login([FromBody] UserDataHelper userData)
            {
                var query = _db.Users.Where(p => p.Email == userData.Email);
                if (query != null && query.Count() > 0)
                {
                    User user = query.Include(p => p.Role).FirstOrDefault();

                    if (user != null && _protectPassword.ValidatePassword(userData.Password, user.Password))
                    {
                        return await GenerateToken(user);
                    }
                    else
                    {
                        return new TokenDataHelper
                        {
                            Token = null,
                            Expiration = null,
                            Status = false,
                            Message = "نام کاربری یا کلمه عبور اشتباه است"
                        };
                    }
                }
                else
                {
                    return new TokenDataHelper
                    {
                        Token = null,
                        Expiration = null,
                        Status = false,
                        Message = "نام کاربری یا کلمه عبور اشتباه است"
                    };
                }
            }
            private async Task<TokenDataHelper> GenerateToken(User user)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.Name),
                new Claim("LastName" , user.LastName),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role , user.Role.EnCaption)
            };
                _config["jwt:key"] = "2Hw9hskCNlK7XSumGcD1QePRoyaJLvtEdMjgxApO3YnFr5ifUTZBW6bIq48zV0";
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //var expiration = DateTime.Now.AddDays(30);
                var expiration = DateTime.Now.AddMinutes(1);
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: cred
                );
                return await Task.FromResult(new TokenDataHelper
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration,
                    Status = true,
                    Message = "Success"
                });
            }
        }
    }
}
