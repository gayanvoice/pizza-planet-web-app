using Microsoft.Data.SqlClient;
using System.Data;
using web_app.Models.Procedure;
using web_app.Models.Repository;

namespace web_app.Helper
{
    public static class HomeHelper
    {
        public static List<ProductProcedureModel.V3?>? GetProductProcedureModelV3()
        {
            List<ProductProcedureModel.V3?>? list = new List<ProductProcedureModel.V3?>();
            foreach (DataRow dataRow in SqlProcedureHelper.GetDataTable("web_app_product_v3", default).Rows)
            {
                list.Add(ProductProcedureModel.V3.FromDataTable(dataRow));
            }
            return list;
        }
        public static List<ProductAllergyProcedureModel.V2?>? GetProductAllergyProcedureModelV2()
        {
            List<ProductAllergyProcedureModel.V2?>? list = new List<ProductAllergyProcedureModel.V2?>();
            foreach (DataRow dataRow in SqlProcedureHelper
                .GetDataTable("web_app_product_allergy_v2", default).Rows)
            {
                list.Add(ProductAllergyProcedureModel.V2.FromDataTable(dataRow));
            }
            return list;
        }
        public static List<ProductContentProcedureModel.V1?>? GetProductContentProcedureModelV1()
        {
            List<ProductContentProcedureModel.V1?>? list = new List<ProductContentProcedureModel.V1?>();
            foreach (DataRow dataRow in SqlProcedureHelper
                .GetDataTable("web_app_product_content_v1", default).Rows)
            {
                list.Add(ProductContentProcedureModel.V1.FromDataTable(dataRow));
            }
            return list;
        }
        [Obsolete]
        public static List<CheckoutBasketProcedureModel.V1?>? GetCheckoutBasketProcedureModelV1(int checkoutId)
        {
            List<CheckoutBasketProcedureModel.V1?>? list = new List<CheckoutBasketProcedureModel.V1?>();
            foreach (DataRow dataRow in SqlProcedureHelper
                .GetDataTable("web_app_checkout_basket_v1", new SqlParameter("@CheckoutId", checkoutId)).Rows)
            {
                list.Add(CheckoutBasketProcedureModel.V1.FromDataTable(dataRow));
            }
            return list;
        }
        public static List<CheckoutBasketProcedureModel.V2?>? GetCheckoutBasketProcedureModelV2(int checkoutId)
        {
            List<CheckoutBasketProcedureModel.V2?>? list = new List<CheckoutBasketProcedureModel.V2?>();
            foreach (DataRow dataRow in SqlProcedureHelper
                .GetDataTable("web_app_checkout_basket_v2", new SqlParameter("@CheckoutId", checkoutId)).Rows)
            {
                list.Add(CheckoutBasketProcedureModel.V2.FromDataTable(dataRow));
            }
            return list;
        }
    }
}
