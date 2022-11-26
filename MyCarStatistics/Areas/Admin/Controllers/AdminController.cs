using Microsoft.AspNetCore.Mvc;

namespace MyCarStatistics.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
