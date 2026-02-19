using Microsoft.AspNetCore.Mvc;

namespace CarFlowX.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
