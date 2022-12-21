﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Online_platform_for_vegetables.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private IMapper mapper;

        public UserManager<Role> userManager;


        public RoleController(IMapper mapper, UserManager<Role> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;

        }


        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register(RoleRegister roleRegister)
        {
            var role = mapper.Map<Role>(roleRegister);
            var result = await userManager.CreateAsync(role, roleRegister.Password);

            if (result.Succeeded)
            {
                return Ok(201);
            }

            return BadRequest(result.Errors);

        }


        [Route("login")]
        [HttpPost]

        public async Task<ActionResult> Login(Loginrole loginRole)
        {
            var role = await userManager.FindByEmailAsync(loginRole.Email_or_phonenumber);
            if (role != null && await userManager.CheckPasswordAsync(role, loginRole.Password))
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>() {
                        new Claim("role",role.Rolename),new Claim("name",role.FirstName),new Claim("photo",role.Profile_Photo),new Claim("id",role.RoleId.ToString())},
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized("login failed");
        }

        
    }
}
