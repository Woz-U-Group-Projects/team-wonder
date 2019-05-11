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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
   public IActionResult Get()
   {
     // return the list of haircolors
     return Ok(_context.User);
   }

   [HttpPost]
   public IActionResult Post([FromBody] User user){
     _context.User.Add(user);
     _context.SaveChanges();
     return Ok(user);
   }

   [HttpPut ("{id}")]
    public void Put (int id, [FromBody] User user) { }

    [HttpDelete ("{id}")]
    public void Delete (int id) { }

        // GET: User
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.User.ToListAsync());
        // }

        // // GET: User/Details/5
        // public async Task<IActionResult> Details(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var user = await _context.User
        //         .FirstOrDefaultAsync(m => m.id == id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(user);
        // }

        // // GET: User/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: User/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("id,userName,password")] User user)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(user);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(user);
        // }

        // // GET: User/Edit/5
        // public async Task<IActionResult> Edit(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var user = await _context.User.FindAsync(id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(user);
        // }

        // // POST: User/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(long id, [Bind("id,userName,password")] User user)
        // {
        //     if (id != user.id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(user);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!UserExists(user.id))
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
        //     return View(user);
        // }

        // // GET: User/Delete/5
        // public async Task<IActionResult> Delete(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var user = await _context.User
        //         .FirstOrDefaultAsync(m => m.id == id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(user);
        // }

        // // POST: User/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(long id)
        // {
        //     var user = await _context.User.FindAsync(id);
        //     _context.User.Remove(user);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool UserExists(long id)
        // {
        //     return _context.User.Any(e => e.id == id);
        // }
    }
}
