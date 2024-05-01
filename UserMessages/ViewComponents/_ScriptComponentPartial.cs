using Microsoft.AspNetCore.Mvc;

namespace UserMessages.ViewComponents
{
    public class _ScriptComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
