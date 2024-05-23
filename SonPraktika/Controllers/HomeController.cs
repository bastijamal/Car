using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace SonPraktika.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}