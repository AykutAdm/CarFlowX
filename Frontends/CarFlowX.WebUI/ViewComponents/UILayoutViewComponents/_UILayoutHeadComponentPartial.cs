using Microsoft.AspNetCore.Mvc;

namespace CarFlowX.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(bool isDarkTheme = false)
        {
            ViewBag.IsDarkTheme = isDarkTheme;
            return View();
        }
    }
}
