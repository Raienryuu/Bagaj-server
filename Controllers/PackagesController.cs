using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bAPI;
using bAPI.Models;

namespace bAPI.Controllers
{
    [Route("api/packages/")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public async Task<ActionResult<int>> VerifyUser(string token)
        {
            var session = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);
            if (session is null)
            {
                return -1;
            }
            return session.UserId;
        }

        public PackagesController(DatabaseContext context)
        {
            _databaseContext = context;
        }

        // GET: api/Packages
        [HttpGet]
        [Route("releated/{token}")]
        public async Task<ActionResult<IEnumerable<PackageModel>>> GetPackageModel(string token)
        {
            int userId = VerifyUser(token).Result.Value;

            if (userId < 0)
            {
                return NotFound();
            }

            var packages = await _databaseContext.Packages.Where(x => x.SenderId == userId || x.TransporterId == userId).ToListAsync();

            var userBids = await _databaseContext.Bids.Where(x => x.BidderId == userId).Select(x => x.PackageId).Distinct().ToListAsync();

            var pack = new PackageModel();

            foreach (var bid in userBids)
            {
                pack = await _databaseContext.Packages.FirstOrDefaultAsync(x => x.Id == bid && x.OfferState < 1);
                if (pack is not null)
                {
                    packages.Add(pack);
                }
            }

            return packages;
        }

        [HttpGet]
        [Route("market/{token}")]
        public async Task<ActionResult<IEnumerable<PackageModel>>> GetMarketPackages(string token)
        {
            int userId = VerifyUser(token).Result.Value;

            if (userId < 0)
            {
                return NotFound();
            }


            return await _databaseContext.Packages.Where(x => x.OfferState == 0  && x.SenderId != userId).ToListAsync();
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<PackageModel>>> GetPackageModel()
        {
            return await _databaseContext.Packages.ToListAsync();
        }


        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{token}")]
        public async Task<ActionResult<PackageModel>> PostPackageModel(string token, [FromBody] PackageModel packageModel)
        {

            int userId = VerifyUser(token).Result.Value;

            if (userId < 0)
            {
                return NotFound();
            }

            packageModel.SenderId = userId;
            packageModel.TransporterId = -1;
            packageModel.LowestBidId = -1;
            packageModel.OfferState = 0;
            packageModel.CreationDate = DateTime.UtcNow;
            packageModel.LowestBid = -1;

            _databaseContext.Packages.Add(packageModel);

            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction("GetPackageModel", new { id = packageModel.Id }, packageModel);
        }

        [HttpPut("cancel/{token}")]
        public async Task<ActionResult<PackageModel>> CancelPackage(string token, [FromBody] PackageModel packageModel)
        {

            int userId = VerifyUser(token).Result.Value;

            if (userId < 0)
            {
                return NotFound();
            }

            var package = await _databaseContext.Packages.FirstOrDefaultAsync(
                x => x.Id == packageModel.Id);

            if (package.SenderId != userId)
            {
                return NotFound();
            }

            package.OfferState = 4; // 4 state - cancelled

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("accept/{token}")]
        public async Task<ActionResult<PackageModel>> AcceptTransporterPackage(string token, [FromBody] PackageModel packageModel)
        {

            int userId = VerifyUser(token).Result.Value;

            if (userId < 0)
            {
                return NotFound();
            }

            var package = await _databaseContext.Packages.FirstOrDefaultAsync(
                x => x.Id == packageModel.Id);

            if (package.SenderId != userId || package.LowestBidId <= 0)
            {
                return NotFound();
            }

            var bid = await _databaseContext.Bids.FirstOrDefaultAsync(b => b.Id == package.LowestBidId);

            package.OfferState = 1; // 1 state - in progress
            package.TransporterId = bid.BidderId;

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("finalize/{token}")]
        public async Task<ActionResult<PackageModel>> FinalizePackage(string token, [FromBody] PackageModel packageModel)
        {

            int userId = VerifyUser(token).Result.Value;

            if (userId < 0)
            {
                return NotFound();
            }

            var package = await _databaseContext.Packages.FirstOrDefaultAsync(
                x => x.Id == packageModel.Id);

            if (package.SenderId != userId || package.TransporterId <= 0)
            {
                return NotFound();
            }

            package.OfferState = 3; // 3 state - finished

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageModel(int id)
        {
            var packageModel = await _databaseContext.Packages.FindAsync(id);
            if (packageModel == null)
            {
                return NotFound();
            }

            _databaseContext.Packages.Remove(packageModel);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }

        

        private bool PackageModelExists(int id)
        {
            return _databaseContext.Packages.Any(e => e.Id == id);
        }
    }
}
