using Microsoft.AspNetCore.Mvc;

namespace UserMessages.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
