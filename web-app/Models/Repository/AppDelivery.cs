namespace web_app.Models.Repository;

public partial class AppDelivery
{
    public int DeliveryId { get; set; }
    public string? AuthUserId { get; set; }
    public string? CheckoutId { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? Status { get; set; }
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset ModifyTime { get; set; }
}
