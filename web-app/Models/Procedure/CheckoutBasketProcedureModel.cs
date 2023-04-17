using System.Data;

namespace web_app.Models.Procedure;

public partial class CheckoutBasketProcedureModel
{
    [Obsolete]
    public V1? CheckoutBasketProcedureModelV1 { get; set; }
    public V2? CheckoutBasketProcedureModelV2 { get; set; }
    public V4? CheckoutBasketProcedureModelV4 { get; set; }
    public partial class V1
    {
        public int CheckoutId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Kcal { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public static V1 FromDataTable(DataRow dataRow)
        {
            V1 v1 = new V1();
            string? CheckoutId = dataRow["CheckoutId_id"].ToString();
            string? Quantity = dataRow["Quantity"].ToString();
            string? Price = dataRow["Price"].ToString();
            string? Kcal = dataRow["Kcal"].ToString();
            string? ModifyTime = dataRow["ModifyTime"].ToString();

            if (CheckoutId is not null) v1.CheckoutId = int.Parse(CheckoutId); else v1.CheckoutId = 0;
            v1.Name = dataRow["Name"].ToString();
            if (Quantity is not null) v1.Quantity = int.Parse(Quantity); else v1.Quantity = 0;
            if (Price is not null) v1.Price = double.Parse(Price); else v1.Price = 0.0;
            if (Kcal is not null) v1.Kcal = int.Parse(Kcal); else v1.Kcal = 0;
            v1.Size = dataRow["Size"].ToString();
            v1.Type = dataRow["Type"].ToString();
            if (ModifyTime is not null) v1.ModifyTime = DateTimeOffset.Parse(ModifyTime); else v1.ModifyTime = DateTimeOffset.UtcNow;
            return v1;
        }
    }
    public partial class V2
    {
        public int CheckoutId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Kcal { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public static V2 FromDataTable(DataRow dataRow)
        {
            V2 v2 = new V2();
            string? CheckoutId = dataRow["CheckoutId_id"].ToString();
            string? Quantity = dataRow["Quantity"].ToString();
            string? ProductId = dataRow["ProductId"].ToString();
            string? Price = dataRow["Price"].ToString();
            string? Kcal = dataRow["Kcal"].ToString();
            string? ModifyTime = dataRow["ModifyTime"].ToString();

            if (CheckoutId is not null) v2.CheckoutId = int.Parse(CheckoutId); else v2.CheckoutId = 0;
            v2.Name = dataRow["Name"].ToString();
            if (Quantity is not null) v2.Quantity = int.Parse(Quantity); else v2.Quantity = 0;
            if (ProductId is not null) v2.ProductId = int.Parse(ProductId); else v2.ProductId = 0;
            if (Price is not null) v2.Price = double.Parse(Price); else v2.Price = 0.0;
            if (Kcal is not null) v2.Kcal = int.Parse(Kcal); else v2.Kcal = 0;
            v2.Size = dataRow["Size"].ToString();
            v2.Type = dataRow["Type"].ToString();
            if (ModifyTime is not null) v2.ModifyTime = DateTimeOffset.Parse(ModifyTime); else v2.ModifyTime = DateTimeOffset.UtcNow;
            return v2;
        }
    }
    public partial class V3
    {
        public int CheckoutId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Kcal { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public static V3 FromDataTable(DataRow dataRow)
        {
            V3 v3 = new V3();
            string? CheckoutId = dataRow["CheckoutId_id"].ToString();
            string? Quantity = dataRow["Quantity"].ToString();
            string? ProductId = dataRow["ProductId"].ToString();
            string? Price = dataRow["Price"].ToString();
            string? Kcal = dataRow["Kcal"].ToString();
            string? ImageUrl = dataRow["ImageUrl"].ToString();
            string? ModifyTime = dataRow["ModifyTime"].ToString();

            if (CheckoutId is not null) v3.CheckoutId = int.Parse(CheckoutId); else v3.CheckoutId = 0;
            v3.Name = dataRow["Name"].ToString();
            if (Quantity is not null) v3.Quantity = int.Parse(Quantity); else v3.Quantity = 0;
            if (ProductId is not null) v3.ProductId = int.Parse(ProductId); else v3.ProductId = 0;
            if (Price is not null) v3.Price = double.Parse(Price); else v3.Price = 0.0;
            if (Kcal is not null) v3.Kcal = int.Parse(Kcal); else v3.Kcal = 0;
            v3.Size = dataRow["Size"].ToString();
            v3.Type = dataRow["Type"].ToString();
            v3.ImageUrl = dataRow["ImageUrl"].ToString();
            if (ModifyTime is not null) v3.ModifyTime = DateTimeOffset.Parse(ModifyTime); else v3.ModifyTime = DateTimeOffset.UtcNow;
            return v3;
        }
    }
    public partial class V4
    {
        public int CheckoutId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Kcal { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }
        public string? Status { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public static V4 FromDataTable(DataRow dataRow)
        {
            V4 v4 = new V4();
            string? CheckoutId = dataRow["CheckoutId_id"].ToString();
            string? Quantity = dataRow["Quantity"].ToString();
            string? ProductId = dataRow["ProductId"].ToString();
            string? Price = dataRow["Price"].ToString();
            string? Kcal = dataRow["Kcal"].ToString();
            string? ModifyTime = dataRow["ModifyTime"].ToString();

            if (CheckoutId is not null) v4.CheckoutId = int.Parse(CheckoutId); else v4.CheckoutId = 0;
            v4.Name = dataRow["Name"].ToString();
            if (Quantity is not null) v4.Quantity = int.Parse(Quantity); else v4.Quantity = 0;
            if (ProductId is not null) v4.ProductId = int.Parse(ProductId); else v4.ProductId = 0;
            if (Price is not null) v4.Price = double.Parse(Price); else v4.Price = 0.0;
            if (Kcal is not null) v4.Kcal = int.Parse(Kcal); else v4.Kcal = 0;
            v4.Size = dataRow["Size"].ToString();
            v4.Type = dataRow["Type"].ToString();
            v4.ImageUrl = dataRow["ImageUrl"].ToString();
            v4.Status = dataRow["Status"].ToString();
            if (ModifyTime is not null) v4.ModifyTime = DateTimeOffset.Parse(ModifyTime); else v4.ModifyTime = DateTimeOffset.UtcNow;
            return v4;
        }
    }
}