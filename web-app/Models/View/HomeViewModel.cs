using Microsoft.AspNetCore.Identity;
using web_app.Models.Procedure;
using web_app.Models.Repository;

namespace web_app.Models.View;

public partial class HomeViewModel
{

    public partial class IndexViewModel
    {
        public IEnumerable<CheckoutProcedureModel.V2?>? CheckoutProcedureModelV2Enumerable { get; set; }
        public AspNetUser? AspNetUser { get; set; }
    }
    public partial class AccountViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public AspNetUserLogin? AspNetUserLogin { get; set; }
    }
    public partial class CheckoutViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public IEnumerable<CheckoutBasketProcedureModel.V1?>? CheckoutBasketProcedureModelV1Enumerable { get; set; }
        public double Total { get; set; }
    }
}
