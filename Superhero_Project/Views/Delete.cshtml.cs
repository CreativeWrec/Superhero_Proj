using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Superhero_Project.Data;
using Superhero_Project.Models;

namespace Superhero_Project.Views
{
    public class DeleteModel : PageModel
    {
        private readonly Superhero_Project.Data.ApplicationDbContext _context;

        public DeleteModel(Superhero_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Superhero Superhero { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Superhero = await _context.superheroes.FirstOrDefaultAsync(m => m.Id == id);

            if (Superhero == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Superhero = await _context.superheroes.FindAsync(id);

            if (Superhero != null)
            {
                _context.superheroes.Remove(Superhero);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
