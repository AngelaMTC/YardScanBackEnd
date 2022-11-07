using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YardScanAPI.Models;

namespace Yard_Scan_API.Controllers
{
    [EnableCors("ionic")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly IConfiguration _config;
            private readonly IUserService _userService;
            private readonly IMapper _mapper;
            public UserController(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }


            // Constructor
            public UserController(IConfiguration config)
            {
                _config = config;
            }


        //public async Task<ActionResult> GetUser(GetUserDto getUserDto)
        //{
        //    return Ok(await _userService.getUser);
        //}

        // Login
        [HttpPost("login")]
            public async Task<ActionResult<string>>Login(GetUserDto request)
            {
                // Inspect connection
                SqlConnection sqlConnection = new(_config.GetConnectionString("InspectConnection"));



                var username = UserService.GetUser(sqlConnection, request.Code);



                if (username == "")
                {
                    return BadRequest("User not found!");
                }



                var token = CreateToken(username);



                return Ok(token);
            }



            private string CreateToken(string username)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };



                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                     _config.GetSection("AppSettings:Token").Value));



                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);



                var token = new JwtSecurityToken(
                     claims: claims,
                     expires: DateTime.Now.AddDays(1),
                     signingCredentials: cred);



                var jwt = new JwtSecurityTokenHandler().WriteToken(token);



                return jwt;
            }
        }
    }

