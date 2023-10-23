using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    public class StudentTablesController : Controller
    {
        private readonly SchoolContext _context;

        public StudentTablesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: StudentTables
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.StudentTables.Include(s => s.Class);
            return View(await schoolContext.ToListAsync());
        }

        // GET: StudentTables/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTable == null)
            {
                return NotFound();
            }

            return View(studentTable);
        }

        // GET: StudentTables/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.ClassTables, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Dob,ClassId,CreatedDate,ModificationDate")] StudentTable studentTable)
        {
            if (ModelState.IsValid)
            {
                studentTable.Id = Guid.NewGuid();
                studentTable.CreatedDate = DateTime.Now;
                studentTable.ModificationDate = DateTime.Now;
                _context.Add(studentTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.ClassTables, "Id", "Id", studentTable.ClassId);
            return View(studentTable);
        }

        // GET: StudentTables/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables.FindAsync(id);
            if (studentTable == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.ClassTables, "Id", "Id", studentTable.ClassId);
            return View(studentTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Gender,Dob,ClassId,CreatedDate,ModificationDate")] StudentTable studentTable)
        {
            if (id != studentTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    studentTable.ModificationDate = DateTime.Now;
                    _context.Update(studentTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTableExists(studentTable.Id))
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
            ViewData["ClassId"] = new SelectList(_context.ClassTables, "Id", "Id", studentTable.ClassId);
            return View(studentTable);
        }

        // GET: StudentTables/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTable == null)
            {
                return NotFound();
            }

            return View(studentTable);
        }

        // POST: StudentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.StudentTables == null)
            {
                return Problem("Entity set 'SchoolContext.StudentTables'  is null.");
            }
            var studentTable = await _context.StudentTables.FindAsync(id);
            if (studentTable != null)
            {
                _context.StudentTables.Remove(studentTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTableExists(Guid id)
        {
          return (_context.StudentTables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
