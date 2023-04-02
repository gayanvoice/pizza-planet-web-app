using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_app.Context;
using web_app.Models;
using web_app.Models.View;

namespace web_app.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using(RsMssqlContext rsMssqlContext = new RsMssqlContext()){
                    Home.Index index = new Home.Index();
                    index.CheckoutEnumerable = rsMssqlContext.AppCheckouts.Where(s => s.AspNetUsersId == user.Id).ToList();
                    index.AspNetUser = Home.Index.FromUser(user);
                    return View(index);
                }
            }
            else
            {
                return View(new Home.Index());
            }
        }

        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}