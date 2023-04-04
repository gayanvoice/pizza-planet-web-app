using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using web_app.Context;
using web_app.Helper;
using web_app.Models;
using web_app.Models.Procedure;
using web_app.Models.Repository;
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
                    HomeViewModel.IndexViewModel indexViewModel = new HomeViewModel.IndexViewModel();
                    using (var command = rsMssqlContext.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "web_app_orders_v2";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@AspNetUsersId", user.Id));
                        rsMssqlContext.Database.OpenConnection();
                        DbDataReader dbDataReader = command.ExecuteReader();
                        var dataTable = new DataTable();
                        dataTable.Load(dbDataReader);
                        List<CheckoutProcedureModel.V2?> v2List = new List<CheckoutProcedureModel.V2?>();
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            v2List.Add(CheckoutProcedureModel.V2.FromDataTable(dataRow));
                        }
                        indexViewModel.CheckoutProcedureModelV2Enumerable = v2List;
                    }
                    indexViewModel.AspNetUser = AspNetUser.FromIdentityUser(user);
                    return View(indexViewModel);
                }
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
                    HomeViewModel.AccountViewModel account = new HomeViewModel.AccountViewModel();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}