using System.Data;

namespace web_app.Models.Procedure;

public partial class ProductAllergyProcedureModel
{
    [Obsolete]
    public V1? CheckoutAllergyProcedureModelV1 { get; set; }
    public V2? CheckoutAllergyProcedureModelV2 { get; set; }
    public partial class V1
    {
        public int ProductId { get; set; }
        public string? IngredientName { get; set; }
        public string? AllergyName { get; set; }
        public static V1 FromDataTable(DataRow dataRow)
        {
            V1 v1 = new V1();
            string? ProductId = dataRow["ProductId"].ToString();
            string? IngredientName = dataRow["IngredientName"].ToString();
            string? AllergyName = dataRow["AllergyName"].ToString();
            

            if (ProductId is not null) v1.ProductId = int.Parse(ProductId); else v1.ProductId = 0;
            v1.IngredientName = IngredientName;
            v1.AllergyName = AllergyName;
            return v1;
        }
    }
    public partial class V2
    {
        public int ProductId { get; set; }
        public string? IngredientName { get; set; }
        public string? AllergyName { get; set; }
        public string? AllergyDescription { get; set; }
        public string? AllergyImageUrl { get; set; }
        public static V2 FromDataTable(DataRow dataRow)
        {
            V2 v2 = new V2();
            string? ProductId = dataRow["ProductId"].ToString();
            string? IngredientName = dataRow["IngredientName"].ToString();
            string? AllergyName = dataRow["AllergyName"].ToString();
            string? AllergyDescription = dataRow["AllergyDescription"].ToString();
            string? AllergyImageUrl = dataRow["AllergyImageUrl"].ToString();


            if (ProductId is not null) v2.ProductId = int.Parse(ProductId); else v2.ProductId = 0;
            v2.IngredientName = IngredientName;
            v2.AllergyName = AllergyName;
            v2.AllergyDescription = AllergyDescription;
            v2.AllergyImageUrl = AllergyImageUrl;
            return v2;
        }
    }
}