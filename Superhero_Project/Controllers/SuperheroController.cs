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
            List<Superhero> superheroes = _context.superheroes.Where(s => s.Id == id).ToList();
            return View();
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
