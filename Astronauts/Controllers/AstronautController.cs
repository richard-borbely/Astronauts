using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astronauts.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Astronauts.Controllers
{
    [Route("api/Astronaut")]
    [ApiController]
    public class AstronautController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AstronautController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            return Json(new { data = _db.Astronaut.ToList() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var astronautFromDb = await _db.Astronaut.FirstOrDefaultAsync(u => u.Id == id);
            if(astronautFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Astronaut.Remove(astronautFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
