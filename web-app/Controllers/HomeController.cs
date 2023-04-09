using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using web_app.Context;
using web_app.Helper;
using web_app.Models;
using web_app.Models.Procedure;
using web_app.Models.Repository;
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
                foreach (DataRow dataRow in SqlProcedureHelper.GetDataTable("web_app_checkout_v2", new SqlParameter("@AspNetUsersId", user.Id)).Rows)
                {
                    v2List.Add(CheckoutProcedureModel.V2.FromDataTable(dataRow));
                }
                indexViewModel.CheckoutProcedureModelV2Enumerable = v2List;
                indexViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                return View(indexViewModel);
            }
            else
            {
                return View(new IndexViewModel());
            }
        }

        public async Task<IActionResult> Account()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AspNetUserLogin? aspNetUserLogin = rsMssqlContext.AspNetUserLogins
                        .Where(s => s.UserId == user.Id).FirstOrDefault();
                    AccountViewModel account = new AccountViewModel();
                    account.AspNetUserLogin = aspNetUserLogin;
                    account.AspNetUser = AspNetUser.FromIdentityUser(user);
                    account.AddressEnumerable = rsMssqlContext.AppAddresses.Where(s => s.AspNetUsersId == user.Id).ToList();
                    return View(account);
                }
            }
            else
            {
                return View(new AccountViewModel());
            }
        }
        public async Task<IActionResult> Invoice(string CheckoutId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    if (CheckoutId is null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AppCheckout? appCheckout = rsMssqlContext.AppCheckouts
                            .Where(c => c.CheckoutId == int.Parse(CheckoutId) && c.AspNetUsersId == user.Id).FirstOrDefault();
                        if (appCheckout is not null)
                        {

                            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
                            invoiceViewModel.CheckoutBasketProcedureModelV1Enumerable = HomeHelper
                                .GetCheckoutBasketProcedureModelV1(appCheckout.CheckoutId);
                            invoiceViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                            invoiceViewModel.AppCheckout = appCheckout;
                            return View(invoiceViewModel);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Checkout(string CheckoutId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    if (CheckoutId is null)
                    {
                        AppCheckout? appCheckout = rsMssqlContext.AppCheckouts
                            .Where(c => (c.AspNetUsersId == user.Id) && (c.Status == "ORDER")).FirstOrDefault();
                        if (appCheckout is null)
                        {
                            AppCheckout newAppCheckout = new AppCheckout();
                            newAppCheckout.CreateTime = DateTime.Now;
                            newAppCheckout.ModifyTime = DateTime.Now;
                            newAppCheckout.Status = "ORDER";
                            newAppCheckout.AspNetUsersId = user.Id;
                            rsMssqlContext.AppCheckouts.Add(newAppCheckout);
                            rsMssqlContext.SaveChanges();
                            return RedirectToAction("Checkout");
                        }
                        else
                        {
                            return RedirectToAction("Checkout", new { CheckoutId = appCheckout.CheckoutId });
                        }
                    }
                    else
                    {
                        AppCheckout? appCheckout = rsMssqlContext.AppCheckouts
                            .Where(c => c.CheckoutId == int.Parse(CheckoutId) && c.AspNetUsersId == user.Id).FirstOrDefault();
                        if (appCheckout is not null)
                        {
                           
                            CheckoutViewModel checkoutViewModel = new CheckoutViewModel();
                            checkoutViewModel.CheckoutBasketProcedureModelV1Enumerable = HomeHelper.GetCheckoutBasketProcedureModelV1(appCheckout.CheckoutId);
                            checkoutViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                            return View(checkoutViewModel);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Product()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AppCheckout? appCheckout = rsMssqlContext.AppCheckouts
                           .Where(c => c.Status == "ORDER" && c.AspNetUsersId == user.Id).FirstOrDefault();
                    if (appCheckout is not null)
                    {
                        AspNetUserLogin? aspNetUserLogin = rsMssqlContext.AspNetUserLogins.Where(s => s.UserId == user.Id).FirstOrDefault();
                        ProductViewModel productViewModel = new ProductViewModel();
                        productViewModel.ProductProcedureModelV3Enumerable = HomeHelper.GetProductProcedureModelV3();
                        productViewModel.ProductAllergyProcedureModelV2Enumerable = HomeHelper.GetProductAllergyProcedureModelV2();
                        productViewModel.ProductContentProcedureModelV1Enumerable = HomeHelper.GetProductContentProcedureModelV1();
                        productViewModel.CheckoutBasketProcedureModelV2Enumerable = HomeHelper.GetCheckoutBasketProcedureModelV2(appCheckout.CheckoutId);
                        productViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                        return View(productViewModel);
                    }
                    else
                    {
                        return RedirectToAction("Checkout", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> AddToBasket(int ProductId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AppCheckout? appCheckout = rsMssqlContext.AppCheckouts
                           .Where(c => c.Status == "ORDER" && c.AspNetUsersId == user.Id).FirstOrDefault();
                    if (appCheckout is not null)
                    {
                        AppBasket? exisitingAppBasket = rsMssqlContext.AppBaskets
                            .Where(b => b.CheckoutIdId == appCheckout.CheckoutId && b.ProductIdId == ProductId).FirstOrDefault();
                        if (exisitingAppBasket is not null)
                        {
                            exisitingAppBasket.Quantity = exisitingAppBasket.Quantity + 1;
                            rsMssqlContext.AppBaskets.Update(exisitingAppBasket);
                            rsMssqlContext.SaveChanges();
                        }
                        else
                        {
                            AppBasket appBasket = new AppBasket();
                            appBasket.Quantity = 1;
                            appBasket.CreateTime = DateTimeOffset.Now;
                            appBasket.ModifyTime = DateTimeOffset.Now;
                            appBasket.Status = "ENABLE";
                            appBasket.CheckoutIdId = appCheckout.CheckoutId;
                            appBasket.ProductIdId = ProductId;
                            rsMssqlContext.AppBaskets.Add(appBasket);
                            rsMssqlContext.SaveChanges();
                        }
                        return RedirectToAction("Product", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Checkout", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Address()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                //using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                //{
                //    IEnumerable<AppAddress?>? appAddressEnumerable = rsMssqlContext.AppAddresses.Where(s => s.AspNetUsersId == user.Id).ToList();
                //    AccountViewModel account = new AccountViewModel();
                //    account.AspNetUserLogin = aspNetUserLogin;
                //    account.AspNetUser = AspNetUser.FromIdentityUser(user);
                //    account.AddressEnumerable = rsMssqlContext.AppAddresses.Where(s => s.AspNetUsersId == user.Id).ToList();
                //    return View(account);
                //}
                return View();
            }
            else
            {
                return View(new AccountViewModel());
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}