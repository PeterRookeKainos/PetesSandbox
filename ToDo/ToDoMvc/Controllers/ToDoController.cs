using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDoMvc.Models;

namespace ToDoMvc.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;
        private readonly ILogger<ToDoController> _logger;
        
        public ToDoController(ToDoContext context, ILogger<ToDoController> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogInformation("--> ToDoController constructor initialized with context and logger.");
        }
        

        // GET: ToDo
        public async Task<IActionResult> Index()
        {
            // log the action
            _logger.LogInformation("--> Index GET action called in ToDoController.");
            return View(await _context.ToDo.ToListAsync());
        }

        // GET: ToDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // log the action
            _logger.LogInformation("--> Details GET action called in ToDoController for ID: {Id}", id);
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDo/Create
        public IActionResult Create()
        {
            _logger.LogInformation("--> Create GET action called in ToDoController.");

            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ToDoName,ToDoDescription,IsComplete,DateCompleted,UserName")] Models.ToDo toDo)
        {
            // log the action
            _logger.LogInformation("--> Create POST action called in ToDoController with ToDoName: {ToDoName}", toDo.ToDoName);
            
            if (ModelState.IsValid)
            {
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _logger.LogInformation("--> Edit GET action called in ToDoController for ID: {Id}", id);

            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDo.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ToDoName,ToDoDescription,IsComplete,DateCompleted,UserName")] Models.ToDo toDo)
        {
            // log the action
            _logger.LogInformation("--> Edit POST action called in ToDoController for ID: {Id} with ToDoName: {ToDoName}", id, toDo.ToDoName);
            
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
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
            return View(toDo);
        }

        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            _logger.LogInformation("--> Delete GET action called in ToDoController for ID: {Id}", id);
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //output to the _logger 
            _logger.LogInformation("--> Delete POST action called in ToDoController for ID: {Id}", id);
            
            var toDo = await _context.ToDo.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDo.Remove(toDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
            // log the action
            _logger.LogInformation("--> Checking if ToDo with ID: {Id} exists in the database.", id);
            return _context.ToDo.Any(e => e.Id == id);
        }
    }
}
