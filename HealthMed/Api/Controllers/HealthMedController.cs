using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HealthMedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
