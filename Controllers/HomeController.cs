using Microsoft.AspNetCore.Mvc;
using ControlNobreak.Models;
using System.Diagnostics;

namespace ControlNobreak.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
