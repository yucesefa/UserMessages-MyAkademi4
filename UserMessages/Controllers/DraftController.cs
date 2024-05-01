using BusinessLayer.UserMessages.Concrete;
using DataAccessLayer.UserMessages.Context;
using DataAccessLayer.UserMessages.Entity_Framework;
using EntityLayer.UserMessages.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UserMessages.Controllers
{
    public class DraftController : Controller
    {
        UserMessageContext context = new UserMessageContext();
        DraftManager draftManager = new DraftManager(new EfDraftDal());
        private readonly UserManager<AppUser> _userManager;

        public DraftController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult DraftMessageList()
        {
            var values = draftManager.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult DraftMessageSave()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DraftMessageSave(Draft draft)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name+ " " + values.Surname;
            draft.Date=DateTime.Now;
            draft.SenderMail = mail;
            draft.SenderName = name;
            draft.Status = true;
            var username = context.Users.Where(x => x.Email == draft.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            draft.ReceiverName = username;
            draftManager.TInsert(draft);
            return RedirectToAction("DraftMessageList");

        }
        public IActionResult RemoveFromDraft(int id)
        {
            draftManager.TDelete(id);
            return RedirectToAction("DraftMessageList");
        }
    }
}
