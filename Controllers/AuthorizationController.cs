using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bAPI.Controllers
{
    
    [Route("api/authorization/")]
    public class AuthorizationController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        //private Dictionary<string, int> sessionList;

        public AuthorizationController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            //sessionList = new();
        }

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<UserDataModel>> GetUsers()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        [HttpGet]
        [Route("sessions")]
        public async Task<IEnumerable<SessionModel>> GetSessions()
        {
            return await _databaseContext.UserSessions.ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> Login(UserDataModel u)
        {
            SessionModel newSession = new();

            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Login == u.Login && x.Password == u.Password);

            if (user == null)
            {
                return NotFound();
            }
            var g = Guid.NewGuid().ToString();
            while (await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == g) != null)
            {
                g = Guid.NewGuid().ToString();
            }

            newSession.Token = g;
            newSession.UserId = user.Id;



            //sessionList.Add( token.Token, user.Id);
            //Console.WriteLine(sessionList.Count);


            _databaseContext.UserSessions.Add(newSession);

            await _databaseContext.SaveChangesAsync();
            TokenModel tok = new();
            tok.Token = newSession.Token;

            return Ok(tok);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDataModel u)
        {
            if (u.Login.Length == 0 && u.Password.Length == 0 && u.Name.Length == 0 && u.Lastname.Length == 0)
            {
                return NotFound();
            }

            var newUser = new UserDataModel
            {
                Login = u.Login,
                Password = u.Password,
                Name = u.Name,
                Lastname = u.Lastname
            };


            _databaseContext.Users.Add(newUser);

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("logout/{token}")]
        public async Task<IActionResult> Logout(string token)
        {
            var session = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);
            if (session == null)
                return NotFound();

            _databaseContext.Remove(session);
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

    }
}
