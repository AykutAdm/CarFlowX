using Microsoft.AspNetCore.Mvc;

namespace CarFlowX.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutMainCoverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}