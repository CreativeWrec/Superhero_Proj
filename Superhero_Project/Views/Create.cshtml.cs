using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Superhero_Project.Data;
using Superhero_Project.Models;

namespace Superhero_Project.Views
{
    public class CreateModel : PageModel
    {
        private readonly Superhero_Project.Data.ApplicationDbContext _context;

        public CreateModel(Superhero_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Superhero Superhero { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.superheroes.Add(Superhero);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
