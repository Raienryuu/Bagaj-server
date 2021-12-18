using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly DatabaseContext _databaseContext;

        public ValuesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get(string token)
        {
            var session = await _databaseContext.UserSessions.FirstOrDefaultAsync(x => x.Token == token);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == session.FK_UserId));
        }

    }
}
