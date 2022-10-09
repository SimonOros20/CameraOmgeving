using Microsoft.AspNetCore.Mvc;
using CameraOmgeving.Models;

namespace CameraOmgeving.Controllers
{
    public class LoginPageController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public List<User> PutValue()
    {
        var users = new List<User>();
        {
            new User { id = 1, name = "gebruikersnaam" };
        }
        return users;
    }
        [HttpPost]
        public IActionResult Verify(User user)
        {
            var u = PutValue();
            var ue = u.Where(u => u.name.Equals(user.name));
            if (ue.Count() == 1)
            {
                ViewBag.message = "login succeeded";
                return View("LoginSucces");  
            }
            else
            {
                ViewBag.message = "loginFailed";
                return View("Login");

            }
        }


    }
}
