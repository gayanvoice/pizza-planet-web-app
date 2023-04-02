using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_app.Context;
using web_app.Models;
using Microsoft.AspNetCore.Identity;
using web_app.Models.Repository.View;
using static web_app.Models.Repository.View.Common;

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

        public async Task<Home.Index> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using(RsMssqlContext rsMssqlContext = new RsMssqlContext()){
                    Home.Index index = new Home.Index();
                    index.CheckoutEnumerable = rsMssqlContext.AppCheckouts.Where(s => s.AspNetUsersId == user.Id).ToList();
                    index.AspNetUser = Home.Index.FromUser(user);
                    return index;
                }
            }
            else
            {
                return new Home.Index();
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