using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Controllers.Resources;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly CoreDbContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(CoreDbContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;            
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResource>> Rgeister(RegisterResource registerResource)
        {
            if (await UserExists(registerResource.Username)) return BadRequest("Username is taken.");
            
            using var hmac = new HMACSHA512();
            
            var user = new AppUser
            {
                UserName = registerResource.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerResource.Password)),
                PasswordSalt = hmac.Key
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return new UserResource
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResource>> Login(LoginResource loginResource)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.UserName.ToLower() == loginResource.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username.");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginResource.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password.");
            }

            return new UserResource
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.User.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
 
}