using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class RefuelController : BaseController
    {
        [HttpGet]
        public IActionResult Refuel()
        {
            var refuel = new RefuelViewModel();
            return View(refuel);
        }
        [HttpPost]
        public IActionResult Refuel(RefuelViewModel refuel)
        {
            if (!ModelState.IsValid)
            {
                return View(refuel);
            }
            return RedirectToAction("Index");
        }
    }
}
