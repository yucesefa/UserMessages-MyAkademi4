using Microsoft.AspNetCore.Mvc;

namespace UserMessages.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
