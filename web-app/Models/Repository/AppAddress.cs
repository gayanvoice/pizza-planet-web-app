namespace web_app.Models.Repository;

public partial class AppAddress
{
    public int AddressId { get; set; }
    public string? AspNetUsersId { get; set; } = null!;
    public string? HouseNumber { get; set; }
    public string? Street { get; set; }
    public string PostCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset ModifyTime { get; set; }
}