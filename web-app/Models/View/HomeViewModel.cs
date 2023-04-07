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
    }
    public partial class InvoiceViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public AppCheckout? AppCheckout { get; set; }
        public IEnumerable<CheckoutBasketProcedureModel.V1?>? CheckoutBasketProcedureModelV1Enumerable { get; set; }
    }
    public partial class ProductViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public IEnumerable<ProductProcedureModel.V3?>? ProductProcedureModelV3Enumerable { get; set; }
        public IEnumerable<ProductAllergyProcedureModel.V2?>? ProductAllergyProcedureModelV2Enumerable { get; set; }
        public IEnumerable<ProductContentProcedureModel.V1?>? ProductContentProcedureModelV1Enumerable { get; set; }
        public IEnumerable<CheckoutBasketProcedureModel.V2?>? CheckoutBasketProcedureModelV2Enumerable { get; set; }
    }
}
