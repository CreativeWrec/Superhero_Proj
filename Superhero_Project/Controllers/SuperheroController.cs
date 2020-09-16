using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero_Project.Data;
using Superhero_Project.Models;

namespace Superhero_Project.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        // GET: SuperheroController //Pull Superhero Table & Send it to the View()
        public ActionResult Index()
        {
            List<Superhero> superheroes = _context.superheroes.ToList();

            return View(superheroes);
            
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = _context.superheroes.Where(s => s.Id == id).FirstOrDefault();

            return View(superhero);
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = _context.superheroes.Find(id);
            return View(superhero);
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                Superhero superheroEdit = _context.superheroes.Find(id);
                _context.superheroes.Attach(superheroEdit);

                superheroEdit.Name = superhero.Name;
                superheroEdit.PrimaryAbility = superhero.PrimaryAbility;
                superheroEdit.AlterEgo = superhero.AlterEgo;
                superheroEdit.SecondaryAbility = superhero.SecondaryAbility;
                superheroEdit.Catchphrase = superhero.Catchphrase;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = _context.superheroes.Find(id);
            return View(superhero);
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                superhero = _context.superheroes.Find(id);

                _context.superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
