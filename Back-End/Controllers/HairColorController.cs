using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class HairColorController : Controller {
        private readonly ApplicationDbContext _context;

        public HairColorController (ApplicationDbContext context) {
            _context = context;
        }

        // GET: HairColor
        // public async Task<IActionResult> Index () {
        //     return View (await _context.HairColor.ToListAsync ());
        // }
        [HttpGet]
   public IActionResult Get()
   {
     // return the list of haircolors
     return Ok(_context.HairColor);
   }

   [HttpPost]
   public IActionResult Post([FromBody] HairColor hairColor){
     _context.HairColor.Add(hairColor);
     _context.SaveChanges();
     return Ok(hairColor);
   }

   [HttpPut ("{id}")]
    public void Put (int id, [FromBody] HairColor hairColor) { }

    [HttpDelete ("{id}")]
    public void Delete (int id) { }

        // GET: HairColor/Details/5
//         public async Task<IActionResult> Details (long? id) {
//             if (id == null) {
//                 return NotFound ();
//             }

//             var hairColor = await _context.HairColor
//                 .FirstOrDefaultAsync (m => m.id == id);
//             if (hairColor == null) {
//                 return NotFound ();
//             }

//             return View (hairColor);
//         }

//         // GET: HairColor/Create
//         public IActionResult Create () {
//             return View ();
//         }

//         // POST: HairColor/Create
//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create ([Bind ("id,name")] HairColor hairColor) {
//             if (ModelState.IsValid) {
//                 _context.Add (hairColor);
//                 await _context.SaveChangesAsync ();
//                 return RedirectToAction (nameof (Index));
//             }
//             return View (hairColor);
//         }

//         // GET: HairColor/Edit/5
//         public async Task<IActionResult> Edit (long? id) {
//             if (id == null) {
//                 return NotFound ();
//             }

//             var hairColor = await _context.HairColor.FindAsync (id);
//             if (hairColor == null) {
//                 return NotFound ();
//             }
//             return View (hairColor);
//         }

//         // POST: HairColor/Edit/5
//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit (long id, [Bind ("id,name")] HairColor hairColor) {
//             if (id != hairColor.id) {
//                 return NotFound ();
//             }

//             if (ModelState.IsValid) {
//                 try {
//                     _context.Update (hairColor);
//                     await _context.SaveChangesAsync ();
//                 } catch (DbUpdateConcurrencyException) {
//                     if (!HairColorExists (hairColor.id)) {
//                         return NotFound ();
//                     } else {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction (nameof (Index));
//             }
//             return View (hairColor);
//         }

//         // GET: HairColor/Delete/5
//         public async Task<IActionResult> Delete (long? id) {
//             if (id == null) {
//                 return NotFound ();
//             }

//             var hairColor = await _context.HairColor
//                 .FirstOrDefaultAsync (m => m.id == id);
//             if (hairColor == null) {
//                 return NotFound ();
//             }

//             return View (hairColor);
//         }

//         // POST: HairColor/Delete/5
//         [HttpPost, ActionName ("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed (long id) {
//             var hairColor = await _context.HairColor.FindAsync (id);
//             _context.HairColor.Remove (hairColor);
//             await _context.SaveChangesAsync ();
//             return RedirectToAction (nameof (Index));
//         }

//         private bool HairColorExists (long id) {
//             return _context.HairColor.Any (e => e.id == id);
//         }
    }
}