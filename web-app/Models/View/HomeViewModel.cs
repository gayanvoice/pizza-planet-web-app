using Microsoft.AspNetCore.Identity;
using web_app.Models.Api;
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
        public IEnumerable<AppAddress?>? AddressEnumerable { get; set; }
    }
    public partial class AddressViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public SearchViewModel? Search { get; set; }
        public FormViewModel? Form { get; set; }
        public class SearchViewModel
        {
            public string? PostCode { get; set;}
        }
        public class FormViewModel
        {
            public string? HouseNumber { get; set; }
            public string? Street { get; set; }
            public string? PostCode { get; set; }
            public string? Country { get; set; }
            public string? Region { get; set; }
            public string? Longitude { get; set; }
            public string? Latitude { get; set; }
            public DateTimeOffset? CreateTime { get; set; }
            public DateTimeOffset? ModifyTime { get; set; }
        }
        public static SearchViewModel FromPostCodeApiModelToSearch(PostcodeApiModel postcodeApiModel)
        {
            SearchViewModel searchViewModel = new SearchViewModel();
            if (postcodeApiModel.result is not null)
            {
                searchViewModel.PostCode = postcodeApiModel.result.postcode;
            }

            return searchViewModel;
        }

        public static FormViewModel? FromPostCodeApiModelToForm(PostcodeApiModel postcodeApiModel)
        {
            FormViewModel formViewModel = new FormViewModel();
            if (postcodeApiModel.result is not null)
            {
                formViewModel.PostCode = postcodeApiModel.result.postcode;
                formViewModel.Country = postcodeApiModel.result.country;
                formViewModel.Region = postcodeApiModel.result.region;
                formViewModel.Longitude = postcodeApiModel.result.longitude.ToString();
                formViewModel.Latitude = postcodeApiModel.result.latitude.ToString();
            }
            return formViewModel;
        }
        public static SearchViewModel FromAppAddressUserToSearch(AppAddress appAddress)
        {
            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.PostCode = appAddress.PostCode;
            return searchViewModel;
        }
        public static FormViewModel FromAppAddressToForm(AppAddress appAddress)
        {
            FormViewModel formViewModel = new FormViewModel();
            formViewModel.HouseNumber = appAddress.HouseNumber;
            formViewModel.Street = appAddress.Street;
            formViewModel.PostCode = appAddress.PostCode;
            formViewModel.Country = appAddress.Country;
            formViewModel.Region = appAddress.Region;
            formViewModel.Longitude = appAddress.Longitude;
            formViewModel.Latitude = appAddress.Latitude;
            formViewModel.CreateTime = appAddress.CreateTime;
            formViewModel.ModifyTime = appAddress.ModifyTime;
            return formViewModel;
        }
    }
    public partial class CheckoutViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public IEnumerable<CheckoutBasketProcedureModel.V3?>? CheckoutBasketProcedureModelV3Enumerable { get; set; }
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

    public partial class DeliveryViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public AppCheckout? AppCheckout { get; set; }
        public IEnumerable<AppAddress?>? AppAddressIEnumerable { get; set; }
    }
    public partial class OrderViewModel
    {
        public AspNetUser? AspNetUser { get; set; }
        public AppCheckout? AppCheckout { get; set; }
    }
}
