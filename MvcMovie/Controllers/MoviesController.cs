using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcMovie.Data;
using MvcMovie.Models;
using NuGet.Protocol;
using Serilog;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly ILogger<MoviesController> _logger;
        private readonly AppOptions _options;

        /*
        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }
        */
        
        /*
        public MoviesController(MvcMovieContext context, ILogger<MoviesController> logger)
        {
            _context = context;
            _logger = logger;
        }
        */
        
        public MoviesController(MvcMovieContext context, ILogger<MoviesController> logger, IOptions<AppOptions> options)
        {
            _context = context;
            _logger = logger;
            _options = options.Value;
            _logger.LogInformation("MoviesController::MoviesController - AppOptions: {AppOptions}", _options.ToJson());
        }
        
        // GET: Movies
        public async Task<IActionResult> Index(string searchString)
        {
            _logger.LogInformation("--> MoviesController::Index");
            _logger.LogError("--> MoviesController::Index - Error example");
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var movies = from m in _context.Movie
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await movies.ToListAsync());
        }
        
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            _logger.LogInformation("MoviesController::Details - id: {Id}", id);
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        
        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // log the id
            _logger.LogInformation("MoviesController::Delete - id: {Id}", id);
            
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _logger.LogInformation("MoviesController::DeleteConfirmed -id : {Id}", id);
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            _logger.LogInformation("MoviesController::Create");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            _logger.LogInformation("MoviesController::Create ${Movie}", movie.ToJson());
            _logger.LogError("MoviesController::Create ${Movie}", movie.ToJson());
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _logger.LogInformation("MoviesController::Edit - id: {Id}", id);
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            _logger.LogInformation("MoviesController::Edit - id: {Id}, ${movie}", id, movie.ToJson());
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }
        
        private bool MovieExists(int id)
        {
            _logger.LogInformation("MoviesController::Edit ${id}", id);
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
