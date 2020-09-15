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
    public class IndexModel : PageModel
    {
        private readonly Superhero_Project.Data.ApplicationDbContext _context;

        public IndexModel(Superhero_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Superhero> Superhero { get;set; }

        public async Task OnGetAsync()
        {
            Superhero = await _context.superheroes.ToListAsync();
        }
    }
}
