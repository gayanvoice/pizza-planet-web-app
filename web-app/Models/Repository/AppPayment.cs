using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppPayment
{
    public int PaymentId { get; set; }

    public string? Type { get; set; } = null!;

    public string? Comment { get; set; }

    public double TotalAmount { get; set; }

    public double RemainingAmount { get; set; }

    public DateTimeOffset CreateTime { get; set; }

    public DateTimeOffset ModifyTime { get; set; }

    public string Status { get; set; } = null!;

    public int CheckoutIdId { get; set; }

    public virtual AppCheckout CheckoutId { get; set; } = null!;
}
