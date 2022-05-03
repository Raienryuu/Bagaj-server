using bAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Controllers
{
    [Route("api/ratings/")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public RatingController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost("rateAndCloseOffer/{token}")]
        public async Task<IActionResult> RateAndCloseOffer(string token, [FromBody] RatingModel u)
        {

            if (u is null || u.PackageId < 1 || u.RatedBySender < 1 || u.RatedBySender > 10)
            {
                return NotFound("invalid data");
            }

            var senderSession = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);

            if (senderSession is null)
            {
                return NotFound();
            }

            var sender = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == senderSession.UserId);

            var package = await _databaseContext.Packages.FirstOrDefaultAsync(x => x.Id == u.PackageId && senderSession.UserId == x.SenderId);

            var transporter = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == package.TransporterId);

            var rating = await _databaseContext.Ratings.FirstOrDefaultAsync(x => x.PackageId == package.Id);

                if (package is null || sender is null || transporter is null || rating is not null)
                {
                return NotFound();
                }

            

            var newRating = new RatingModel
            {
                SenderId = senderSession.UserId,
                Sender = sender,
                TransporterId = package.TransporterId,
                Transporter = transporter,
                PackageId = package.Id,
                Package = package,
                RatedBySender = u.RatedBySender,
                RatedByTransporter = -1
            };

            package.OfferState = 2;


            _databaseContext.Ratings.Add(newRating);

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("rateAsTransporter/{token}")]
        public async Task<IActionResult> RateAsTransporter(string token, [FromBody] RatingModel u)
        {

            if (u is null || u.PackageId < 1 || u.RatedByTransporter < 1 || u.RatedByTransporter > 10)
            {
                return NotFound("invalid data");
            }

            var transporterSession = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);

            var rating = await _databaseContext.Ratings.FirstOrDefaultAsync(x => x.PackageId == u.PackageId);

            if (transporterSession is null || rating is null)
            {
                return NotFound();
            }

            rating.RatedByTransporter = u.RatedByTransporter;

            var sender = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == rating.SenderId);
            var transporter = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == rating.TransporterId);

            var senderRats = await _databaseContext.Ratings.Where(x => sender.Id == x.SenderId || sender.Id == x.TransporterId).ToListAsync();

            var sSum = 0.0f;
            if (senderRats.Count > 4) { 
            foreach (RatingModel p in senderRats)
            {
                if (p.SenderId == sender.Id)
                {
                    sSum += p.RatedByTransporter;
                } else if (p.TransporterId == sender.Id)
                {
                    sSum += p.RatedBySender;
                }
            }

            sender.Rating = (sSum / senderRats.Count);

            }

            var transporterRats = await _databaseContext.Ratings.Where(x => transporter.Id == x.SenderId || transporter.Id == x.TransporterId).ToListAsync();

            if (transporterRats.Count > 4)
            {
                sSum = 0f;

                foreach (RatingModel p in transporterRats)
                {
                    if (p.SenderId == transporter.Id)
                    {
                        sSum += p.RatedByTransporter;
                    }
                    else if (p.TransporterId == transporter.Id)
                    {
                        sSum += p.RatedBySender;
                    }
                }

                transporter.Rating = (sSum / transporterRats.Count);
            }
            var pack = await _databaseContext.Packages.FirstOrDefaultAsync(x => x.Id == rating.PackageId);

            pack.OfferState = 3; // 3 state - completed and rated

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }
    }
}
