using Microsoft.AspNetCore.Mvc;
using MVC_Event.Models;

namespace MVC_Event.Controllers
{
    public class LoginResisterController : Controller
    {
        private readonly EventDBContext _bookContext;

        public LoginResisterController(EventDBContext bookContext)
        {
            _bookContext = bookContext;
        }
  
        public IActionResult Register()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Register(User User)
        {
            if (!string.IsNullOrWhiteSpace(User.UserName) && !string.IsNullOrWhiteSpace(User.Password))
            {
                bool Exists = _bookContext.Users.Any(u => u.UserName == User.UserName);
                if (Exists)
                {
                    ViewBag.Msg = "Account Already Exist";
                    return View(User);
                }

                _bookContext.Users.Add(User);
                _bookContext.SaveChanges();
              

                return RedirectToAction("Login" , "Event");
            }

            ViewBag.Msg = "Please enter valid data";
            return View(User);
        }

    
        public IActionResult Login()
        {
            return View();
        }

  
        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                ViewBag.Msg = "Please enter UserName and Password";
                return View();
            }

            var User = _bookContext.Users.FirstOrDefault(u =>
                u.UserName.ToLower() == UserName.ToLower() &&
                u.Password == Password);

            if (User != null)
            {
                return RedirectToAction("Index", "Event"); 
            }

            ViewBag.Msg = "Invalid UserName or Password";
            return View();
        }
    }
}