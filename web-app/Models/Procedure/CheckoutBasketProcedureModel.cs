using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Globalization;
using web_app.Models.Repository;

namespace web_app.Models.Procedure;

public partial class CheckoutBasketProcedureModel
{
    public V1? CheckoutBasketProcedureModelV1 { get; set; }
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
}