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
using HomeHero.Services;

namespace HomeHero.Controllers
{
    [AuthorizeUsers(Roles = "Admon")]
    public class UsersController : Controller
    {
        private readonly HomeHeroContext _context;
        private readonly HHeroServices _heroServices;

        public UsersController(HomeHeroContext context)
        {
            _context = context;
            _heroServices = new HHeroServices(context);
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
            var data1 = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data1, "LocationID", "City");
            var data2 = _context.Role.ToList();
            ViewBag.RolesData = new SelectList(data2, "RoleID", "NameRole");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] int RoleID_User, [FromForm] string name, [FromForm] string surnames, [FromForm] int LocationResidenceID, [FromForm] string email, [FromForm] string password)
        {
            User user = new User();
            if (ModelState.IsValid)
            {
                byte[] salt = _heroServices.HHeroEncrypt.GenerateSalt();
                user.RoleID_User = RoleID_User;
                user.NamesUser = name;
                user.SurnamesUser = surnames;
                user.LocationResidenceID = LocationResidenceID;
                user.Email = email;
                user.Salt = salt;
                user.Password = _heroServices.HHeroEncrypt.HashPassword(password, salt);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            };
            var data1 = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data1, "LocationID", "City");
            var data2 = _context.Role.ToList();
            ViewBag.RolesData = new SelectList(data2, "RoleID", "NameRole");
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
            var data1 = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data1, "LocationID", "City");
            var data2 = _context.Role.ToList();
            ViewBag.RolesData = new SelectList(data2, "RoleID", "NameRole");
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] int RoleID_User, [FromForm] string RealUserID, [FromForm] string NamesUser, [FromForm] string SurnamesUser, [FromForm] int LocationResidenceID, [FromForm] string Email,[FromForm] string VolunteerPermises)
        {
            User user = _context.User.Find(id);
            if (ModelState.IsValid)
            {
                try
                {
                    user.RoleID_User = RoleID_User;
                    user.RealUserID = RealUserID;
                    user.NamesUser = NamesUser;
                    user.SurnamesUser = SurnamesUser;
                    user.LocationResidenceID = LocationResidenceID;
                    user.Email = Email;
                    user.VolunteerPermises = Convert.ToBoolean(VolunteerPermises);
                    _context.User.Update(user);
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
            var data1 = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data1, "LocationID", "City");
            var data2 = _context.Role.ToList();
            ViewBag.RolesData = new SelectList(data2, "RoleID", "NameRole");
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
