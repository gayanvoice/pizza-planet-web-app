using System.Data;

namespace web_app.Models.Procedure;

public partial class ProductProcedureModel
{
    [Obsolete]
    public V1? ProductProcedureModelV1 { get; set; }
    [Obsolete]
    public V2? ProductProcedureModelV2 { get; set; }
    public V3? ProductProcedureModelV3 { get; set; }
    public partial class V1
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public int Kcal { get; set; }
        public double Price { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? Guide { get; set; }
        public string? Content { get; set; }
        public string? ContentImageUrl { get; set; }
        public string? Allergy { get; set; }
        public string? AllergyImageUrl { get; set; }
        public static V1 FromDataTable(DataRow dataRow)
        {
            V1 v1 = new V1();
            string? ProductId = dataRow["ProductId"].ToString();
            string? Name = dataRow["Name"].ToString();
            string? Description = dataRow["Description"].ToString();
            string? Size = dataRow["Size"].ToString();
            string? Type = dataRow["Type"].ToString();
            string? Kcal = dataRow["Kcal"].ToString();
            string? Price = dataRow["Price"].ToString();
            string? ProductImageUrl = dataRow["ProductImageUrl"].ToString();
            string? Guide = dataRow["Guide"].ToString();
            string? Content = dataRow["Content"].ToString();
            string? ContentImageUrl = dataRow["ContentImageUrl"].ToString();
            string? Allergy = dataRow["Allergy"].ToString();
            string? AllergyImageUrl = dataRow["AllergyImageUrl"].ToString();

            if (ProductId is not null) v1.ProductId = int.Parse(ProductId); else v1.ProductId = 0;
            v1.Name = Name;
            v1.Description = Description;
            v1.Size = Size;
            v1.Type = Type;
            if (Kcal is not null) v1.Kcal = int.Parse(Kcal); else v1.Kcal = 0;
            if (Price is not null) v1.Price = double.Parse(Price); else v1.Price = 0.0;
            v1.ProductImageUrl = ProductImageUrl;
            v1.Guide = Guide;
            v1.Content = Content;
            v1.ContentImageUrl = ContentImageUrl;
            v1.Allergy = Allergy;
            v1.AllergyImageUrl = AllergyImageUrl;
            return v1;
        }
    }
    public partial class V2
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public int Kcal { get; set; }
        public double Price { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? ContentName { get; set; }
        public string? ContentCode { get; set; }
        public int? RecipeQuantity { get; set; }
        public string? RecipeMeasurement { get; set; }
        public string? GuideName { get; set; }
        public string? GuideImageUrl { get; set; }
        public static V2 FromDataTable(DataRow dataRow)
        {
            V2 v2 = new V2();
            string? ProductId = dataRow["ProductId"].ToString();
            string? Name = dataRow["Name"].ToString();
            string? Description = dataRow["Description"].ToString();
            string? Size = dataRow["Size"].ToString();
            string? Type = dataRow["Type"].ToString();
            string? Kcal = dataRow["Kcal"].ToString();
            string? Price = dataRow["Price"].ToString();
            string? ProductImageUrl = dataRow["ProductImageUrl"].ToString();
            string? ContentName = dataRow["ContentName"].ToString();
            string? ContentCode = dataRow["ContentCode"].ToString();
            string? RecipeQuantity = dataRow["RecipeQuantity"].ToString();
            string? RecipeMeasurement = dataRow["RecipeMeasurement"].ToString();
            string? GuideName = dataRow["GuideName"].ToString();
            string? GuideImageUrl = dataRow["GuideImageUrl"].ToString();

            if (ProductId is not null) v2.ProductId = int.Parse(ProductId); else v2.ProductId = 0;
            v2.Name = Name;
            v2.Description = Description;
            v2.Size = Size;
            v2.Type = Type;
            if (Kcal is not null) v2.Kcal = int.Parse(Kcal); else v2.Kcal = 0;
            if (Price is not null) v2.Price = double.Parse(Price); else v2.Price = 0.0;
            v2.ProductImageUrl = ProductImageUrl;
            v2.ContentName = ContentName;
            v2.ContentCode = ContentCode;
            if (RecipeQuantity is not null) v2.RecipeQuantity = int.Parse(RecipeQuantity); else v2.Kcal = 0;
            v2.RecipeMeasurement = RecipeMeasurement;
            v2.GuideName = GuideName;
            v2.GuideImageUrl = GuideImageUrl;
            return v2;
        }
    }
    public partial class V3
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public int Kcal { get; set; }
        public double Price { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? ContentName { get; set; }
        public string? ContentCode { get; set; }
        public int? RecipeQuantity { get; set; }
        public string? RecipeMeasurement { get; set; }
        public static V3 FromDataTable(DataRow dataRow)
        {
            V3 v3 = new V3();
            string? ProductId = dataRow["ProductId"].ToString();
            string? Name = dataRow["Name"].ToString();
            string? Description = dataRow["Description"].ToString();
            string? Size = dataRow["Size"].ToString();
            string? Type = dataRow["Type"].ToString();
            string? Kcal = dataRow["Kcal"].ToString();
            string? Price = dataRow["Price"].ToString();
            string? ProductImageUrl = dataRow["ProductImageUrl"].ToString();
            string? ContentName = dataRow["ContentName"].ToString();
            string? ContentCode = dataRow["ContentCode"].ToString();
            string? RecipeQuantity = dataRow["RecipeQuantity"].ToString();
            string? RecipeMeasurement = dataRow["RecipeMeasurement"].ToString();

            if (ProductId is not null) v3.ProductId = int.Parse(ProductId); else v3.ProductId = 0;
            v3.Name = Name;
            v3.Description = Description;
            v3.Size = Size;
            v3.Type = Type;
            if (Kcal is not null) v3.Kcal = int.Parse(Kcal); else v3.Kcal = 0;
            if (Price is not null) v3.Price = double.Parse(Price); else v3.Price = 0.0;
            v3.ProductImageUrl = ProductImageUrl;
            v3.ContentName = ContentName;
            v3.ContentCode = ContentCode;
            if (RecipeQuantity is not null) v3.RecipeQuantity = int.Parse(RecipeQuantity); else v3.Kcal = 0;
            v3.RecipeMeasurement = RecipeMeasurement;
            return v3;
        }
    }
}