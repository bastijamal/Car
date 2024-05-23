using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SonPraktika.AccountVm;
using SonPraktika.Models;

namespace SonPraktika.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager= userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if(!ModelState.IsValid)  return View();

            User user = new User()
            {
                Name = registerVm.Name,
                Email = registerVm.Email,
            };

            var result= await _userManager.CreateAsync(user,registerVm.Password);

            if(!result.Succeeded) {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }


            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginVm loginVm)
        {
            return View();
        }

    }
}
