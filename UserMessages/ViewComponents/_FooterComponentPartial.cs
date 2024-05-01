using Microsoft.AspNetCore.Mvc;

namespace UserMessages.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
