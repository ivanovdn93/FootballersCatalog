using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballersCatalog.Data;
using FootballersCatalog.Models;
using FootballersCatalog.ViewModels;

namespace FootballersCatalog.Controllers
{
    public class FootballersController : Controller
    {
        private readonly FootballersCatalogContext _context;

        public FootballersController(FootballersCatalogContext context)
        {
            _context = context;
        }

        [Route("/Footballers")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Footballers.ToListAsync());
        }

        [Route("/")]
        public IActionResult Create()
        {
            return View(new FootballerModel { Teams = _context.Teams });
        }

        [Route("/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Surname,Gender,DateOfBirth,TeamName,Country")] Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                footballer.Team = _context.Teams.Any(t => t.Name == footballer.TeamName) 
                    ? _context.Teams.Single(t => t.Name == footballer.TeamName) 
                        : new Team { Name = footballer.TeamName };

                _context.Add(footballer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var footballerModel = new FootballerModel { Footballer = footballer, Teams = _context.Teams };

            return View(footballerModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballers.FindAsync(id);
            if (footballer == null)
            {
                return NotFound();
            }

            var footballerModel = new FootballerModel { Footballer = footballer, Teams = _context.Teams };

            return View(footballerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("Id,Name,Surname,Gender,DateOfBirth,TeamName,Country")] Footballer footballer)
        {
            if (id != footballer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    footballer.Team = _context.Teams.Any(t => t.Name == footballer.TeamName)
                        ? _context.Teams.Single(t => t.Name == footballer.TeamName)
                            : new Team { Name = footballer.TeamName };

                    _context.Update(footballer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballerExists(footballer.Id))
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

            var footballerModel = new FootballerModel { Footballer = footballer, Teams = _context.Teams };

            return View(footballerModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballer == null)
            {
                return NotFound();
            }

            return View(footballer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            _context.Footballers.Remove(footballer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballerExists(int id)
        {
            return _context.Footballers.Any(e => e.Id == id);
        }
    }
}
