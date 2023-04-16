using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppCheckout
{
    public int CheckoutId { get; set; }

    public DateTimeOffset CreateTime { get; set; }

    public DateTimeOffset ModifyTime { get; set; }

    public string Status { get; set; } = null!;
    public string? DeliveryMethod { get; set; }

    public string? AspNetUsersId { get; set; }

    public int? AuthUserId { get; set; }

    public virtual ICollection<AppBasket> AppBaskets { get; } = new List<AppBasket>();

    public virtual ICollection<AppPayment> AppPayments { get; } = new List<AppPayment>();
}
