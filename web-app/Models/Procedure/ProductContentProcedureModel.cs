using System.Data;

namespace web_app.Models.Procedure;

public partial class ProductContentProcedureModel
{
    public V1? ProductContentProcedureModelV1 { get; set; }
    public partial class V1
    {
        public int ProductId { get; set; }
        public string? GuideName { get; set; }
        public string? GuideImageUrl { get; set; }
        public static V1 FromDataTable(DataRow dataRow)
        {
            V1 v1 = new V1();
            string? ProductId = dataRow["ProductId"].ToString();
            string? GuideName = dataRow["GuideName"].ToString();
            string? GuideImageUrl = dataRow["GuideImageUrl"].ToString();
            

            if (ProductId is not null) v1.ProductId = int.Parse(ProductId); else v1.ProductId = 0;
            v1.GuideName = GuideName;
            v1.GuideImageUrl = GuideImageUrl;
            return v1;
        }
    }
}