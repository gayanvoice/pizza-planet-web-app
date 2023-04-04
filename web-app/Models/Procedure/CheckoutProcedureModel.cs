using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Globalization;
using web_app.Models.Repository;

namespace web_app.Models.Procedure;

public partial class CheckoutProcedureModel
{
    public V1? CheckoutProcedureModelV1 { get; set; }
    public V2? CheckoutProcedureModelV2 { get; set; }
    public partial class V1
    {
        public int CheckoutId { get; set; }
        public string? AspNetUsersId { get; set; }
        public string? Status { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public static V1 FromDataTable(DataRow dataRow)
        {
            V1 v1 = new V1();
            string? CheckoutId = dataRow["CheckoutId"].ToString();
            string? ModifyTime = dataRow["ModifyTime"].ToString();
            string? Quantity = dataRow["Quantity"].ToString();
            string? Price = dataRow["Price"].ToString();

            if (CheckoutId is not null) v1.CheckoutId = int.Parse(CheckoutId); else v1.CheckoutId = 0;
            v1.AspNetUsersId = dataRow["AspNetUsersId"].ToString();
            v1.Status = dataRow["Status"].ToString();
            if (ModifyTime is not null) v1.ModifyTime = DateTimeOffset.Parse(ModifyTime); else v1.ModifyTime = DateTimeOffset.UtcNow;
            v1.Name = dataRow["CheckoutId"].ToString();
            if (Quantity is not null) v1.Quantity = double.Parse(Quantity); else v1.Quantity = 0.0;
            if (Price is not null) v1.Price = double.Parse(Price); else v1.Price = 0.0;
            return v1;
        }
    }
    public partial class V2
    {
        public int CheckoutId { get; set; }
        public string? AspNetUsersId { get; set; }
        public string? Status { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public string? Item { get; set; }
        public double Sum { get; set; }
        public static V2 FromDataTable(DataRow dataRow)
        {
            V2 v2 = new V2();
            string? CheckoutId = dataRow["CheckoutId"].ToString();
            string? ModifyTime = dataRow["ModifyTime"].ToString();
            string? Sum = dataRow["Sum"].ToString();

            if (CheckoutId is not null) v2.CheckoutId = int.Parse(CheckoutId); else v2.CheckoutId = 0;
            v2.AspNetUsersId = dataRow["AspNetUsersId"].ToString();
            v2.Status = dataRow["Status"].ToString();
            if (ModifyTime is not null) v2.ModifyTime = DateTimeOffset.Parse(ModifyTime); else v2.ModifyTime = DateTimeOffset.UtcNow;
            v2.Item = dataRow["Item"].ToString();
            if (Sum is not null) v2.Sum = double.Parse(Sum.ToString()); else v2.Sum = 0.0;
            return v2;
        }
    }
}