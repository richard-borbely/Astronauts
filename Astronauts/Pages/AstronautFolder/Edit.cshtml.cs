using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astronauts.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Astronauts.Pages.AstronautFolder
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Astronaut Astronaut { get; set; }
        public async Task OnGet(int id)
        {
            Astronaut = await _db.Astronaut.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var AstronautFromDb = await _db.Astronaut.FindAsync(Astronaut.Id);
                AstronautFromDb.Name = Astronaut.Name;
                AstronautFromDb.Surname = Astronaut.Surname;
                AstronautFromDb.Date = Astronaut.Date;
                AstronautFromDb.Superpower = Astronaut.Superpower;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
