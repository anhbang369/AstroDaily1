using AstroDailyLast.testDir;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroDailyLast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirebaseEmailController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public FirebaseEmailController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("/")]
        public IActionResult GetData()
        {
            return Ok();
        }

    }
}
