using Microsoft.AspNetCore.Mvc;

namespace CarFlowX.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
