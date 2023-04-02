using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppBasket
{
    public int BasketId { get; set; }

    public double Quantity { get; set; }

    public DateTimeOffset CreateTime { get; set; }

    public DateTimeOffset ModifyTime { get; set; }

    public string Status { get; set; } = null!;

    public int CheckoutIdId { get; set; }

    public int ProductIdId { get; set; }

    public virtual AppCheckout CheckoutId { get; set; } = null!;

    public virtual AppProduct ProductId { get; set; } = null!;
}
