using System.Diagnostics;
using GameForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameForum.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        { 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
