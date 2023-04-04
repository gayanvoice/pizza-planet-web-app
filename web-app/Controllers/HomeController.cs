using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using web_app.Context;
using web_app.Helper;
using web_app.Models;
using web_app.Models.Procedure;
using web_app.Models.Repository;
using web_app.Models.View;
using static web_app.Models.View.HomeViewModel;

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
                IndexViewModel indexViewModel = new IndexViewModel();
                List<CheckoutProcedureModel.V2?> v2List = new List<CheckoutProcedureModel.V2?>();
                foreach (DataRow dataRow in SqlProcedureHelper.GetDataTable("web_app_orders_v2", new SqlParameter("@AspNetUsersId", user.Id)).Rows)
                {
                    v2List.Add(CheckoutProcedureModel.V2.FromDataTable(dataRow));
                }
                indexViewModel.CheckoutProcedureModelV2Enumerable = v2List;
                indexViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                return View(indexViewModel);
            }
            else
            {
                return View(new HomeViewModel.IndexViewModel());
            }
        }

        public async Task<IActionResult> Account()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AspNetUserLogin? aspNetUserLogin = rsMssqlContext.AspNetUserLogins.Where(s => s.UserId == user.Id).FirstOrDefault();
                    AccountViewModel account = new AccountViewModel();
                    account.AspNetUserLogin = aspNetUserLogin;
                    account.AspNetUser = AspNetUser.FromIdentityUser(user);
                    return View(account);
                }
            }
            else
            {
                return View(new HomeViewModel.AccountViewModel());
            }
        }
        public async Task<IActionResult> Checkout(int CheckoutId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AppCheckout? appCheckout = rsMssqlContext.AppCheckouts
                        .Where(c => c.CheckoutId == CheckoutId && c.AspNetUsersId == user.Id).FirstOrDefault();
                    if (appCheckout is not null)
                    {
                        CheckoutViewModel checkoutViewModel = new CheckoutViewModel();
                        List<CheckoutBasketProcedureModel.V1?> v1List = new List<CheckoutBasketProcedureModel.V1?>();
                        foreach (DataRow dataRow in SqlProcedureHelper
                            .GetDataTable("web_app_order_basket_v1", new SqlParameter("@CheckoutId", appCheckout.CheckoutId)).Rows)
                        {
                            v1List.Add(CheckoutBasketProcedureModel.V1.FromDataTable(dataRow));
                        }
                        checkoutViewModel.CheckoutBasketProcedureModelV1Enumerable = v1List;
                        checkoutViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                        v1List.ForEach((v1) =>
                        {
                            if (v1 is not null)
                            {
                                checkoutViewModel.Total = checkoutViewModel.Total + (v1.Quantity * v1.Price);
                            }
                            
                        });
                        return View(checkoutViewModel);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}