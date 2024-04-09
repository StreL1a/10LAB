using Lab_10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_10.Controllers
{
    public class ApplicationFormController : Controller
    {
        private static List<ApplicationForm> _applications = new List<ApplicationForm>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ApplicationForm model)
        {
            if (ModelState.IsValid)
            {
                _applications.Add(model);
                int lastIndex = _applications.Count - 1;
                return RedirectToAction("Confirmation", new { id = lastIndex });
            }
            return View(model);
        }

        public IActionResult Confirmation(int id)
        {
            var model = _applications[id];
            return View(model);
        }
    }
}