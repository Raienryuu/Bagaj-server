using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Controllers
{
    [Route("api/tools/")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public AdminAPIController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpDelete("packages")]
        public async Task<IActionResult> DeleteAllPackages()
        {
            if (_databaseContext.Packages.Any())
            {
                var packages = await _databaseContext.Packages.Where(x => x.Id > 0).ToListAsync();

                foreach (var p in packages)
                {
                    _databaseContext.Remove(p);
                }

            }
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("bids")]
        public async Task<IActionResult> DeleteAllBids()
        {
            if (_databaseContext.Packages.Any())
            {
                var packages = await _databaseContext.Bids.Where(x => x.Id > 0).ToListAsync();

                foreach (var p in packages)
                {
                    _databaseContext.Remove(p);
                }

            }
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("users")]
        public async Task<IActionResult> DeleteAllUsers()
        {
            if (_databaseContext.Packages.Any())
            {
                var packages = await _databaseContext.Users.Where(x => x.Id > 0).ToListAsync();

                foreach (var p in packages)
                {
                    _databaseContext.Remove(p);
                }

            }
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("sessions")]
        public async Task<IActionResult> DeleteAllSessions()
        {
            if (_databaseContext.Packages.Any())
            {
                var packages = await _databaseContext.UserSessions.Where(x => x.Id > 0).ToListAsync();

                foreach (var p in packages)
                {
                    _databaseContext.Remove(p);
                }

            }
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("ratings")]
        public async Task<IActionResult> DeleteAllRatings()
        {
            if (_databaseContext.Packages.Any())
            {
                var packages = await _databaseContext.Ratings.Where(x => x.Id > 0).ToListAsync();

                foreach (var p in packages)
                {
                    _databaseContext.Remove(p);
                }

            }
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }
    }
}
