using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backEnd.Models;

namespace backEnd.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class updoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public updoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
   public IActionResult Get()
   {
     // return the list of haircolors
     return Ok(_context.updo);
   }

   
   [HttpPut ("{id}")]
    public void Put (int id, [FromBody] updo upDo) { }

    [HttpDelete ("{id}")]
    public void Delete (int id) { }

        // GET: updo
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.updo.ToListAsync());
        // }

        // // GET: updo/Details/5
        // public async Task<IActionResult> Details(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var updo = await _context.updo
        //         .FirstOrDefaultAsync(m => m.id == id);
        //     if (updo == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(updo);
        // }

        // // GET: updo/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: updo/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("id,name")] updo updo)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(updo);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(updo);
        // }

        // // GET: updo/Edit/5
        // public async Task<IActionResult> Edit(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var updo = await _context.updo.FindAsync(id);
        //     if (updo == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(updo);
        // }

        // // POST: updo/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(long id, [Bind("id,name")] updo updo)
        // {
        //     if (id != updo.id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(updo);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!updoExists(updo.id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(updo);
        // }

        // // GET: updo/Delete/5
        // public async Task<IActionResult> Delete(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var updo = await _context.updo
        //         .FirstOrDefaultAsync(m => m.id == id);
        //     if (updo == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(updo);
        // }

        // // POST: updo/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(long id)
        // {
        //     var updo = await _context.updo.FindAsync(id);
        //     _context.updo.Remove(updo);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool updoExists(long id)
        // {
        //     return _context.updo.Any(e => e.id == id);
        // }
    }
}
