using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astronauts.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Astronauts.Pages.AstronautFolder
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Astronaut Astronaut { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Astronaut.AddAsync(Astronaut);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else 
            {
                return Page();
            }
        }
    }
}
