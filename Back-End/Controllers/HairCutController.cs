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
    public class HairCutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HairCutController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HairCut
        [HttpGet]
   public IActionResult Get()
   {
     // return the list of haircolors
     return Ok(_context.HairCut);
   }

   [HttpPost]
   public IActionResult Post([FromBody] HairCut hairCut){
     _context.HairCut.Add(hairCut);
     _context.SaveChanges();
     return Ok(hairCut);
   }

   [HttpPut ("{id}")]
    public void Put (int id, [FromBody] HairCut hairCut) { }

    [HttpDelete ("{id}")]
    public void Delete (int id) { }
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.HairCut.ToListAsync());
        // }

        // // GET: HairCut/Details/5
        // public async Task<IActionResult> Details(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var hairCut = await _context.HairCut
        //         .FirstOrDefaultAsync(m => m.id == id);
        //     if (hairCut == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(hairCut);
        // }

        // // GET: HairCut/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: HairCut/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("id,name")] HairCut hairCut)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(hairCut);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(hairCut);
        // }

        // // GET: HairCut/Edit/5
        // public async Task<IActionResult> Edit(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var hairCut = await _context.HairCut.FindAsync(id);
        //     if (hairCut == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(hairCut);
        // }

        // // POST: HairCut/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(long id, [Bind("id,name")] HairCut hairCut)
        // {
        //     if (id != hairCut.id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(hairCut);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!HairCutExists(hairCut.id))
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
        //     return View(hairCut);
        // }

        // // GET: HairCut/Delete/5
        // public async Task<IActionResult> Delete(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var hairCut = await _context.HairCut
        //         .FirstOrDefaultAsync(m => m.id == id);
        //     if (hairCut == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(hairCut);
        // }

        // // POST: HairCut/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(long id)
        // {
        //     var hairCut = await _context.HairCut.FindAsync(id);
        //     _context.HairCut.Remove(hairCut);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool HairCutExists(long id)
        // {
        //     return _context.HairCut.Any(e => e.id == id);
        // }
    }
}
