using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Net;
using web_app.Context;
using web_app.Helper;
using web_app.Models;
using web_app.Models.Api;
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
                    account.AddressEnumerable = rsMssqlContext.AppAddresses.Where(s => s.AspNetUsersId != null && s.AspNetUsersId == user.Id).ToList();
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
        public async Task<IActionResult> Process(string CheckoutId)
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

                            ProcessViewModel processViewModel = new ProcessViewModel();
                            processViewModel.CheckoutBasketProcedureModelV4Enumerable = HomeHelper.GetCheckoutBasketProcedureModelV4(appCheckout.CheckoutId);
                            processViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                            processViewModel.AppCheckout = appCheckout;
                            return View(processViewModel);
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
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AppCheckout? appCheckout = rsMssqlContext.AppCheckouts
                           .Where(c => (c.AspNetUsersId == user.Id) && (c.Status == "ORDER")).FirstOrDefault();
                    if (appCheckout is null)
                    {
                        AppCheckout newAppCheckout = new AppCheckout();
                        newAppCheckout.CreateTime = DateTime.Now;
                        newAppCheckout.ModifyTime = DateTime.Now;
                        newAppCheckout.Status = "ORDER";
                        newAppCheckout.DeliveryMethod = "DELIVERY";
                        newAppCheckout.AspNetUsersId = user.Id;
                        rsMssqlContext.AppCheckouts.Add(newAppCheckout);
                        rsMssqlContext.SaveChanges();
                        return RedirectToAction("Checkout");
                    }
                    else
                    {
                        CheckoutViewModel checkoutViewModel = new CheckoutViewModel();
                        checkoutViewModel.CheckoutBasketProcedureModelV3Enumerable = HomeHelper.GetCheckoutBasketProcedureModelV3(appCheckout.CheckoutId);
                        checkoutViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                        return View(checkoutViewModel);
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
                            appBasket.Status = "PROCESS";
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
        public async Task<IActionResult> Address(string? addressId, string? postCode)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AddressViewModel addressViewModel = new AddressViewModel();
                    addressViewModel.Form = new AddressViewModel.FormViewModel();
                    addressViewModel.Search = new AddressViewModel.SearchViewModel();
                    if (addressId is not null)
                    {
                        AppAddress? appAddress = rsMssqlContext.AppAddresses.Where(a => a.AspNetUsersId == user.Id && a.AddressId == int.Parse(addressId)).FirstOrDefault();
                        if (appAddress is not null)
                        {
                            addressViewModel.Form = AddressViewModel.FromAppAddressToForm(appAddress);
                            addressViewModel.Search = AddressViewModel.FromAppAddressUserToSearch(appAddress);
                        }
                        return RedirectToAction("Account", "Home");
                    }
                    else
                    {
                        if (postCode is not null)
                        {
                            PostcodeApiModel? postCodeApiModel = await PostCodeApiHelper.GetFromPostCodesIo(postCode);
                            if (postCodeApiModel is not null)
                            {
                                addressViewModel.Form = AddressViewModel.FromPostCodeApiModelToForm(postCodeApiModel);
                                addressViewModel.Search = AddressViewModel.FromPostCodeApiModelToSearch(postCodeApiModel);
                            }
                        }
                    }
                    addressViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                    return View(addressViewModel);
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Address(AddressViewModel addressViewModel)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AspNetUser aspNetUser = AspNetUser.FromIdentityUser(user);
                    AppAddress appAddress = new AppAddress();
                    appAddress.AspNetUsersId = aspNetUser.Id;
                    appAddress.HouseNumber = addressViewModel.Form.HouseNumber;
                    appAddress.Street = addressViewModel.Form.Street;
                    appAddress.PostCode = addressViewModel.Form.PostCode;
                    appAddress.Country = addressViewModel.Form.Country;
                    appAddress.Region = addressViewModel.Form.Region;
                    appAddress.Longitude = addressViewModel.Form.Longitude;
                    appAddress.Latitude = addressViewModel.Form.Latitude;
                    appAddress.ModifyTime = DateTimeOffset.Now;
                    appAddress.CreateTime = DateTimeOffset.Now;
                    rsMssqlContext.AppAddresses.Add(appAddress);
                    rsMssqlContext.SaveChanges();
                }
            }
            return RedirectToAction("Account", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAddress(int id)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AspNetUser aspNetUser = AspNetUser.FromIdentityUser(user);
                    AppAddress appAddress = rsMssqlContext.AppAddresses.Where(a => a.AddressId == id).First();
                    rsMssqlContext.AppAddresses.Remove(appAddress);
                    rsMssqlContext.SaveChanges();
                }
            }
            return RedirectToAction("Account", "Home");
        }
        public async Task<IActionResult> Order()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    OrderViewModel orderViewModel = new OrderViewModel();
                    orderViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                    orderViewModel.AppCheckout = rsMssqlContext.AppCheckouts.Where(c => c.AspNetUsersId == user.Id && c.Status == "ORDER").FirstOrDefault();
                    return View(orderViewModel);
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<IActionResult> OrderMethod(string deliveryType)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AppCheckout? appCheckout = rsMssqlContext.AppCheckouts.Where(c => c.AspNetUsersId == user.Id && c.Status == "ORDER").FirstOrDefault();
                    if (appCheckout is not null)
                    {
                        appCheckout.DeliveryMethod = deliveryType;
                        rsMssqlContext.AppCheckouts.Update(appCheckout);
                        rsMssqlContext.SaveChanges();
                        return RedirectToAction("Order", "Home");
                    }
                    return RedirectToAction("Checkout", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<IActionResult> DeliveryAddress(int addressId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AppCheckout? appCheckout = rsMssqlContext.AppCheckouts.Where(c => c.AspNetUsersId == user.Id && c.Status == "ORDER").FirstOrDefault();
                    if (appCheckout is not null)
                    {
                        appCheckout.AddressId = addressId;
                        rsMssqlContext.AppCheckouts.Update(appCheckout);
                        rsMssqlContext.SaveChanges();
                        return RedirectToAction("Delivery", "Home");
                    }
                    return RedirectToAction("Checkout", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<IActionResult> Delivery()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    DeliveryViewModel deliveryViewModel = new DeliveryViewModel();
                    deliveryViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                    deliveryViewModel.AppCheckout = rsMssqlContext.AppCheckouts.Where(c => c.AspNetUsersId == user.Id && c.Status == "ORDER").FirstOrDefault();
                    deliveryViewModel.AppAddressIEnumerable = rsMssqlContext.AppAddresses.Where(a => a.AspNetUsersId == user.Id).ToList();
                    return View(deliveryViewModel);
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public async Task<IActionResult> Payment()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    PaymentViewModel paymentViewModel = new PaymentViewModel();
                    paymentViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                    paymentViewModel.AppCheckout = rsMssqlContext.AppCheckouts.Where(c => c.AspNetUsersId == user.Id && c.Status == "ORDER").FirstOrDefault();
                    return View(paymentViewModel);
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentViewModel paymentViewModel)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
                {
                    AppCheckout? appCheckout = rsMssqlContext.AppCheckouts.Where(c => c.AspNetUsersId == user.Id && c.Status == "ORDER").FirstOrDefault();
                    if (appCheckout is not null)
                    {
                        IEnumerable<CheckoutBasketProcedureModel.V2?>? v2 = HomeHelper.GetCheckoutBasketProcedureModelV2(appCheckout.CheckoutId);
                        if (v2 is not null)
                        {
                            AspNetUser aspNetUser = AspNetUser.FromIdentityUser(user);
                            AppPayment appPayment = new AppPayment();
                            appPayment.CheckoutIdId = appCheckout.CheckoutId;
                            appPayment.Type = paymentViewModel.Form.PaymentMethod;
                            appPayment.Comment = paymentViewModel.Form.Comment;
                            appPayment.TotalAmount = v2.Sum(v2 => v2.Quantity * v2.Price);
                            appPayment.RemainingAmount = v2.Sum(v2 => v2.Quantity * v2.Price);
                            appPayment.ModifyTime = DateTimeOffset.Now;
                            appPayment.CreateTime = DateTimeOffset.Now;
                            appPayment.Status = "ENABLE";
                            rsMssqlContext.AppPayments.Add(appPayment);
                            appCheckout.Status = "PROCESS";
                            rsMssqlContext.AppCheckouts.Update(appCheckout);
                            rsMssqlContext.SaveChanges();
                            return RedirectToAction("Invoice", "Home", new { CheckoutId = appCheckout.CheckoutId });
                        }
                        
                    }
                    
                }
            }
            return RedirectToAction("Account", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> AddToCheckout(int ProductId)
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
                        return RedirectToAction("Checkout", "Home");
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
        public async Task<IActionResult> RemoveFromCheckout(int ProductId)
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
                            if (exisitingAppBasket.Quantity > 1)
                            {
                                exisitingAppBasket.Quantity = exisitingAppBasket.Quantity - 1;
                                rsMssqlContext.AppBaskets.Update(exisitingAppBasket);
                                rsMssqlContext.SaveChanges();
                            }
                            else
                            {
                                rsMssqlContext.AppBaskets.Remove(exisitingAppBasket);
                                rsMssqlContext.SaveChanges();
                            }
                          
                        }
                        return RedirectToAction("Checkout", "Home");
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
    }
}