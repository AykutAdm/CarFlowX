using Microsoft.AspNetCore.Mvc;

namespace CarFlowX.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
