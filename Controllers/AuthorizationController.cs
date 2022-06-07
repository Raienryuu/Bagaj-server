using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace bAPI.Controllers
{

    [Route("api/authorization/")]
    public class AuthorizationController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        private static string HashPassword(string p)
        {
            byte[] byteSalt = Convert.FromBase64String("412G3AS/jBnm6bbgZp4LWw==");

            string hashedpw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: p,
                salt: byteSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 64
                ));

            return hashedpw;
        }

        public AuthorizationController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<UserDataModel>> GetUsers(string token)
        {
            var user = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);

            if (user == null)
            {
                return new List<UserDataModel>();
            }
            return await _databaseContext.Users.ToListAsync();
        }
        [HttpGet]
        [Route("listAll")]
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

        [HttpDelete]
        [Route("sessions/wipe")]
        public async Task<IActionResult> WipeSessions()
        {
            if (_databaseContext.UserSessions.Any())
            {
                var session = await _databaseContext.UserSessions.Where(x => x.Id > 0).ToListAsync();
                if (session == null)
                    {
                    return NotFound();
                }

                foreach (var ses in session) {
                    _databaseContext.Remove(ses);
                }
                
            }
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Login(UserDataModel u)
        {
            SessionModel newSession = new();

            u.Password = HashPassword(u.Password);

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

            _databaseContext.UserSessions.Add(newSession);

            await _databaseContext.SaveChangesAsync();
            TokenModel tok = new();
            tok.Token = newSession.Token;

            return Ok(tok);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDataModel u)
        {
            

            if (u is null || u.Login is null || u.Password is null || u.Name is null || u.Lastname is null || u.ContactInfo is null) {
                return NotFound();
            }

            if (u.Login.Length < 6 || u.Password.Length < 3 || u.Name.Length < 1 || u.Lastname.Length < 1 || u.ContactInfo.Length < 1)
            {
                return NotFound();
            }

            var r = CheckIfLoginIsAvailable(u.Login);

            if(r.Result.ToString() == "Microsoft.AspNetCore.Mvc.OkResult")
            {
                return NotFound();
            }

            u.Password = HashPassword(u.Password);

            var newUser = new UserDataModel
            {
                Login = u.Login,
                Password = u.Password,
                Name = u.Name,
                Lastname = u.Lastname,
                ContactInfo = u.ContactInfo,
                Rating = -1
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
            {
                    return Ok();
            }

            _databaseContext.Remove(session);
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("checkUsername/{login}")]
        public async Task<IActionResult> CheckIfLoginIsAvailable(string login)
        {
            var session = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (session == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        [Route("getUsername/{id}")]
        public async Task<IActionResult> GetUserFromId(int id)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var u = new UserDataModel
            {
                Rating = user.Rating,
                Login = user.Login
            };

            return Ok(u);
        }

        [HttpGet]
        [Route("getMyUser/{token}")]
        public async Task<IActionResult> GetMyUser(string token)
        {
            var session = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);
            if (session == null)
            {
                return NotFound();
            }

            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == session.UserId);
            if (user == null)
            {
                return NotFound();
            }
            user.Password = "";

            return Ok(user);
        }

        [HttpGet]
        [Route("getSenderUser/{packageId}/{token}")]
        public async Task<IActionResult> GetSenderUser(int packageId, string token)
        {
            var session = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);
            if (session == null)
            {
                return NotFound();
            }

            var package = await _databaseContext.Packages.FirstOrDefaultAsync(x => x.Id == packageId);

            if (package == null)
            {
                return NotFound();
            }

            var senderUser = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == package.SenderId);

            if (senderUser is null)
            {
                return NotFound();
            }

            senderUser.Password = "";

            return Ok(senderUser);
        }

        [HttpGet]
        [Route("getTransporterUser/{packageId}/{token}")]
        public async Task<IActionResult> GetTransporterUser(int packageId, string token)
        {

            var session = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);
            if (session == null)
            {
                return NotFound("");
            }

            var package = await _databaseContext.Packages.FirstOrDefaultAsync(x => x.Id == packageId && (x.SenderId == session.UserId
            || x.TransporterId == session.UserId ));

            if (package == null)
            {
                return NotFound("");
            }

            var lowestBid = await _databaseContext.Bids.FirstOrDefaultAsync(b => b.PackageId == package.Id);

            var transporterUser = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == package.TransporterId || x.Id == lowestBid.BidderId);

            if (transporterUser is null)
            {
                return NotFound("");
            }

            transporterUser.Password = "";

            return Ok(transporterUser);
        }

    }

}

