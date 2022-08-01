using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class CourierController : ControllerBase
    {
        private IMapper mapper;

        public UserManager<Courier> userManager;

        public CourierController(IMapper mapper, UserManager<Courier> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;

        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register(CourierRegister courierRegister)
        {
            var user = mapper.Map<Courier>(courierRegister);
            var result = await userManager.CreateAsync(user, courierRegister.Password);

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
            var user = await userManager.FindByEmailAsync(loginRole.Email_or_phonenumber);
            if (user != null && await userManager.CheckPasswordAsync(user, loginRole.Password))
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>() {
                        new Claim("role","courier"),new Claim("name",user.UserName),new Claim ("photo",user.Vehicle_Photo)},
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