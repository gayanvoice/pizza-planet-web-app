using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppRecipe
{
    public int RecipeId { get; set; }

    public double Quantity { get; set; }

    public string Measurement { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int ContentIdId { get; set; }

    public int ProductIdId { get; set; }

    public virtual AppContent ContentId { get; set; } = null!;

    public virtual AppProduct ProductId { get; set; } = null!;
}
