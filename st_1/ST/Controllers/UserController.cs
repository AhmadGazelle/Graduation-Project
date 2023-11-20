using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST.Models;

namespace ST.Controllers
{
    public class UserController : Controller
    {
        private readonly studentContext _context;

        public UserController(studentContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var studentContext = _context.Users.Include(u => u.Sm).Include(u => u.UserTypeNavigation);
            return View(await studentContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Sm)
                .Include(u => u.UserTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {


            int maxAge1 = _context.Users.Max(p => p.Id);
             ViewBag.idUser = maxAge1 + 1;




            ViewData["SmId"] = new SelectList(_context.StudentMasters, "Id", "Name");
            ViewData["UId"] = new SelectList(_context.CodeUniversties, "Id", "NameAr");
            ViewData["CId"] = new SelectList(_context.Companies, "Id", "NameAr");


            ViewData["UserType"] = new SelectList(_context.UserTypes, "Id", "UserTypeAr");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SmId,UId,CId,UserName,Password,Phon,Email,UserType")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SmId"] = new SelectList(_context.StudentMasters, "Id", "Id", user.SmId);
            ViewData["UserType"] = new SelectList(_context.UserTypes, "Id", "Id", user.UserType);
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["SmId"] = new SelectList(_context.StudentMasters, "Id", "Id", user.SmId);
            ViewData["UserType"] = new SelectList(_context.UserTypes, "Id", "Id", user.UserType);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SmId,UId,CId,UserName,Password,Phon,Email,UserType")] User user)
        {
            if (id != user.Id)
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
                    if (!UserExists(user.Id))
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
            ViewData["SmId"] = new SelectList(_context.StudentMasters, "Id", "Id", user.SmId);
            ViewData["UserType"] = new SelectList(_context.UserTypes, "Id", "Id", user.UserType);
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Sm)
                .Include(u => u.UserTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(User userLogin)
        {
            // using (studentContext db= new studentContext())
            //
            //  {
            var usr = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userLogin.UserName && u.Password == userLogin.Password);
            if (usr != null)
            {
                ViewBag.SmId = usr.SmId.ToString();
        

                ViewBag.SmId = usr.SmId.ToString();
                ViewBag.UId = usr.UId.ToString();
                ViewBag.UserName = usr.UserName.ToString();
                ViewBag.Password = usr.Password.ToString();
                ViewBag.CId= usr.CId.ToString();


                   if ((Int32.Parse(ViewBag.UId) == 1) && Int32.Parse(ViewBag.SmId) == 1)
                {
                    return RedirectToAction("Admin", "StudentMaster");
                }

                else if (Int32.Parse(ViewBag.CId) != 0)
                {
                    return RedirectToAction("companySite", "Company");
                }

                else if (Int32.Parse(ViewBag.SmId) != 0)
                {
                    return RedirectToAction("UserSite", "User");

                }
                else if (Int32.Parse(ViewBag.UId) != 0)
                {
                    return RedirectToAction("universitySite", "University");
                }


            }
            else if (usr == null)
            {
                ViewBag.errorMSG = "Your Password or UserName  are invalid";
            }


            return View();

        }

        public ActionResult LoggedIn()
        {
            if (Request.Cookies["userID"] != null)
            {
                ViewData["userID"] = Request.Cookies["userID"];
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult UserSite()
        {
            return View();
        }

        public IActionResult registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {

            return View();
        }


    }

}



