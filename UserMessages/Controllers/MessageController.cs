using BusinessLayer.UserMessages.Concrete;
using DataAccessLayer.UserMessages.Context;
using DataAccessLayer.UserMessages.Entity_Framework;
using EntityLayer.UserMessages.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace UserMessages.Controllers
{
    public class MessageController : Controller
    {
        UserMessageContext context = new UserMessageContext();
        UserMessageManager messageManager = new UserMessageManager(new EfUserMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult>Inbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p=values.Email;
            var message = messageManager.GetListReceiverMessage(p);
            return View(message);
        }
        public IActionResult InboxMessageDetails(int id)
        {
            UserMessage userMessage = messageManager.TGetById(id);
            return View(userMessage);
        }
        public async Task<IActionResult> Sendbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var message = messageManager.GetListSenderMessage(p);
            return View(message);
        }
        public IActionResult SendboxMessageDetails(int id)
        {
            UserMessage userMessage = messageManager.TGetById(id);
            return View(userMessage);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(UserMessage message)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            message.Date = DateTime.Now;
            message.SenderMail = mail;
            message.SenderName= name;
            message.Status = true;
            message.IsDraft = false;
            message.IsRead = false;

            var username = context.Users.Where(x => x.Email == message.ReceiverMail).Select(y => y.Name + "" + y.Surname).FirstOrDefault();
            message.ReceiverName = username;
            messageManager.TInsert(message);
            return RedirectToAction("Inbox");
        }
        public IActionResult TrashMessageList()
        {
            var values = messageManager.GetListDeleteMessage();
            return View(values);
        }
        public IActionResult TrashMessages(int id)
        {
            var values = context.UserMessages.Where(x => x.UserMessageId == id).FirstOrDefault();
            values.Status = false;
            context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }
        public IActionResult TakeBackTheTrashMessage(int id)
        {
            var values = context.UserMessages.Where(x => x.UserMessageId == id).FirstOrDefault();
            values.Status = true;
            context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }
    }
}
