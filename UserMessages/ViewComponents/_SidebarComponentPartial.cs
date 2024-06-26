﻿using DataAccessLayer.UserMessages.Context;
using EntityLayer.UserMessages.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UserMessages.ViewComponents
{
    public class _SidebarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly UserMessageContext _context;
        public _SidebarComponentPartial(UserManager<AppUser> userManager, UserMessageContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Inbox = _context.UserMessages.Where(x => x.ReceiverMail == values.Email).Count();
            ViewBag.Sendbox = _context.UserMessages.Where(x => x.SenderMail == values.Email && x.Status == true && x.IsDraft == false).Count();
            ViewBag.Draft = _context.Drafts.Count();
            ViewBag.Delete = _context.UserMessages.Where(x => x.Status == false).Count();
            return View(values);
        }
    }
}
