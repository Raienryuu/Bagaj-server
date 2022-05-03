using bAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace bAPI.Controllers
{
    [Route("api/bids/")]
    public class BidController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public BidController(DatabaseContext context)
        {
            _databaseContext = context;
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> AddBid(string token, [FromBody] BidModel b)
        {

            if (token is null || b is null || b.BidValue <= 0 || b.PackageId <= 0)
            {
                return NotFound();
            }

            var session = await _databaseContext.UserSessions.FirstOrDefaultAsync(
                x => x.Token == token);
            if (session is null)
            {
                return NotFound();
            }

            var bidder = await _databaseContext.Users.FirstOrDefaultAsync(
                x => x.Id == session.UserId);

            if (bidder is null)
            {
                return NotFound();
            }

            var package = await _databaseContext.Packages.FirstOrDefaultAsync(
                x => x.Id == b.PackageId);

            if (package.LowestBid >= 1) {
                if (b.BidValue >= package.LowestBid)
                {
                    return NotFound();
                }
            }

            if (package is null || bidder.Id == package.SenderId)
            {
                return NotFound();
            }

            var newBid = new BidModel
            {
                PackageId = b.PackageId,
                Package = package,
                BidderId = bidder.Id,
                Bidder = bidder,
                BidValue = b.BidValue
            };

            _databaseContext.Bids.Add(newBid);

            

            await _databaseContext.SaveChangesAsync();

            package.LowestBid = newBid.BidValue;
            package.LowestBidId = newBid.Id;

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        
    }
}
