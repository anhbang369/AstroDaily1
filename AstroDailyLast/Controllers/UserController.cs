using AstroDaily.Model;
using AstroDailyLast.testDir;
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
    public class UserController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public UserController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateAccount(UserModel userModel)
        {
            try
            {
                _context.Add(userModel);
                _context.SaveChanges();
                return Ok(userModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditProfile(string id, UserModel userModel)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (user != null)
            {
                user.Email = userModel.Email;
                user.Phone = userModel.Phone;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.DobDay = userModel.DobDay;
                user.DobMonth = userModel.DobMonth;
                user.DobYear = userModel.DobYear;
                user.BirthPlace = userModel.BirthPlace;
                user.BirthTime = userModel.BirthTime;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }


        }

        [HttpPut("{Id}")]
        public IActionResult DeleteAccount(string id)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.Id == id);
            if (user != null)
            {
                user.Status = 0;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }


        }
    }
}
