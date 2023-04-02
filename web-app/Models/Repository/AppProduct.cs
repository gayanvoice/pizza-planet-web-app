using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Size { get; set; } = null!;

    public int Kcal { get; set; }

    public double Price { get; set; }

    public DateTimeOffset CreateTime { get; set; }

    public DateTimeOffset ModifyTime { get; set; }

    public string Status { get; set; } = null!;

    public string? Type { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<AppBasket> AppBaskets { get; } = new List<AppBasket>();

    public virtual ICollection<AppProductguide> AppProductguides { get; } = new List<AppProductguide>();

    public virtual ICollection<AppRecipe> AppRecipes { get; } = new List<AppRecipe>();
}
