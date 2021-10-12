using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astronauts.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Astronauts.Pages.AstronautFolder
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Astronaut> Astronauts { get; set; }
        public async Task OnGet()
        {
            Astronauts = await _db.Astronaut.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Astronaut.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Astronaut.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
