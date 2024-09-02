using Microsoft.AspNetCore.Mvc;
using UserAuthenticationTask.Data;
using UserAuthenticationTask.Models;

namespace UserAuthenticationTask.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUser = _context.Users.Where(models => models.UserName == user.UserName && models.Password == user.Password);
            if (checkUser.Any())
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "Invalid User Name Or Password";
            return View(user);
        }
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }
        public IActionResult ChangeUserActivity(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user.IsActive == false)
            {
                user.IsActive = true;
            }
            else
            {
                user.IsActive = false;
            }
            _context.SaveChanges();
            return (RedirectToAction(nameof(Index)));
        }
    }
}
