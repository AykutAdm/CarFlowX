using Microsoft.AspNetCore.Mvc;

namespace CarFlowX.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
