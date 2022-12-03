using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class RepairController : BaseController
    {
        private readonly IRepairService serviceService;

        public RepairController(IRepairService _serviceService)
        {
            serviceService = _serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int carId)
        {
            var model = await serviceService.GetCar(carId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RepairViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await serviceService.AddService(model);
            return RedirectToAction(nameof(All), model.CarId);
        }

        [HttpGet]
        public async Task<IActionResult> All(int carId)
        {
            var all = await serviceService.GetServices(carId);
            ViewBag.Id = carId;
            return View(all);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int serviceId)
        {
            var carId = await serviceService.Delete(serviceId);
            return RedirectToAction(nameof(All), carId);
        }
    }
}
