using EntityLayer.UserMessages.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserMessages.Models;

namespace UserMessages.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserInfoUpdateViewModel viewModel = new UserInfoUpdateViewModel();
            viewModel.Name = values.Name;
            viewModel.Surname = values.Surname;
            viewModel.PictureUrl = values.IamgeUrl;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserInfoUpdateViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var savePath = resource + "/wwwroot/userimage/" + imageName;
                var stream = new FileStream(savePath, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.IamgeUrl = imageName;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
