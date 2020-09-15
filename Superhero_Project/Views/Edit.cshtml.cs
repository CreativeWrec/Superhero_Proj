using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Superhero_Project.Data;
using Superhero_Project.Models;

namespace Superhero_Project.Views
{
    public class EditModel : PageModel
    {
        private readonly Superhero_Project.Data.ApplicationDbContext _context;

        public EditModel(Superhero_Project.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Superhero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperheroExists(Superhero.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SuperheroExists(int id)
        {
            return _context.superheroes.Any(e => e.Id == id);
        }
    }
}
