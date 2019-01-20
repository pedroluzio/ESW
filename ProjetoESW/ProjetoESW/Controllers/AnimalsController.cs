using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models.Animals;

namespace ProjetoESW.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Animal.Include(a =>a.Breed).Include(b=>b.Colony);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Breed)
                .Include(a => a.Colony)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create/2
        public IActionResult Create(int? id)
        {
            ViewData["BreedID"] = new SelectList(_context.Breed, "ID", "Name");
            ViewData["ColonyID"] = new SelectList(_context.Colony, "ID", "ID");
            ViewData["Colony"] = id;
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> MyCreate(string name, string dataNascimento, string anoNascimento, string breed, string color, string gender, string colony)
        {

            Gender newGender = Gender.Indefinido;

            if (gender == "Fêmea")
                newGender = Gender.Fêmea;
            else if (gender == "Macho")
                newGender = Gender.Macho;

            Animal animal = new Animal()
            {
                Name = name,
                BreedID = Convert.ToInt32(breed),
                Color = color,
                Gender = newGender,
                ColonyID = Convert.ToInt32(colony)
            };

            if (!(dataNascimento is null))
                animal.Birthdate = Convert.ToDateTime(dataNascimento);
            else if (!(anoNascimento is null))
                animal.YearOfBirth = Convert.ToInt32(anoNascimento);

            _context.Add(animal);
            await _context.SaveChangesAsync();
            return Accepted();
        }

      
        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Birthdate,YearOfBirth,Gender,BreedID,Color,OVHDate,ColonyID")] Animal animal)
        {
            if (id != animal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedID"] = new SelectList(_context.Breed, "ID", "Name", animal.BreedID);
            ViewData["ColonyID"] = new SelectList(_context.Colony, "ID", "ID", animal.ColonyID);
            return View(animal);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return Accepted();
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.ID == id);
        }
    }
}
