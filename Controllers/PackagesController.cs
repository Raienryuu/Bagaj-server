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
        private readonly DatabaseContext _context;

        public async Task<ActionResult<SessionModel>> VerifyUser(string token)
        {
            var session = await _context.UserSessions.FirstOrDefaultAsync(x => x.Token == token);

            if (session == null)
            {
                return new SessionModel();
            }

            return session;
        }

        public PackagesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        [Route("releated/{token}")]
        public async Task<ActionResult<IEnumerable<PackageModel>>> GetPackageModel(string token)
        {
            SessionModel session = VerifyUser(token).Result.Value;

            //if (session.Id == 0)
            //{
            //    Console.WriteLine("session not found");
            //    return NotFound();
            //}

            var list = await _context.PackageModel.ToListAsync();

            foreach (var item in list)
            {
                item.LowestBid = new BidModel();

                item.LowestBid.BidderId = 5;
                item.LowestBid.BidValue = 150;
                item.LowestBid.PackageId = item.Id;

                Console.WriteLine(item.LowestBid);
            }

            return list;
            //return await _context.PackageModel.Where(x => x.SenderId == session.UserId).ToListAsync();
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageModel>> GetPackageModel(int id)
        {
            var packageModel = await _context.PackageModel.FindAsync(id);

            if (packageModel == null)
            {
                return NotFound();
            }

            return packageModel;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackageModel(int id, PackageModel packageModel)
        {
            if (id != packageModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(packageModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PackageModel>> PostPackageModel(PackageModel packageModel)
        {
            

            _context.PackageModel.Add(packageModel);

            

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageModel", new { id = packageModel.Id }, packageModel);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageModel(int id)
        {
            var packageModel = await _context.PackageModel.FindAsync(id);
            if (packageModel == null)
            {
                return NotFound();
            }

            _context.PackageModel.Remove(packageModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageModelExists(int id)
        {
            return _context.PackageModel.Any(e => e.Id == id);
        }
    }
}
