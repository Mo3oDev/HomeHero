using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeHero.Data;
using HomeHero.Models;
using HomeHero.Filters;

namespace HomeHero.Controllers
{
    [AuthorizeUsers(Roles = "Admon")]
    public class UsersController : Controller
    {
        private readonly HomeHeroContext _context;

        public UsersController(HomeHeroContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var homeHeroContext = _context.User.Include(u => u.LocationResidence).Include(u => u.Role_User);
            return View(await homeHeroContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["LocationResidenceID"] = new SelectList(_context.Location, "LocationID", "City");
            ViewData["RoleID_User"] = new SelectList(_context.Role, "RoleID", "NameRole");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleID_User,RealUserID,NamesUser,SurnamesUser,ProfilePicture,VolunteerVoucher,QualificationUser,Email,LocationResidenceID,SexUser,Curriculum,VolunteerPermises")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationResidenceID"] = new SelectList(_context.Location, "LocationID", "City", user.LocationResidenceID);
            ViewData["RoleID_User"] = new SelectList(_context.Role, "RoleID", "NameRole", user.RoleID_User);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["LocationResidenceID"] = new SelectList(_context.Location, "LocationID", "City", user.LocationResidenceID);
            ViewData["RoleID_User"] = new SelectList(_context.Role, "RoleID", "NameRole", user.RoleID_User);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,RoleID_User,RealUserID,NamesUser,SurnamesUser,ProfilePicture,VolunteerVoucher,QualificationUser,Email,LocationResidenceID,SexUser,Curriculum,VolunteerPermises")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            ViewData["LocationResidenceID"] = new SelectList(_context.Location, "LocationID", "City", user.LocationResidenceID);
            ViewData["RoleID_User"] = new SelectList(_context.Role, "RoleID", "NameRole", user.RoleID_User);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'HomeHeroContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
