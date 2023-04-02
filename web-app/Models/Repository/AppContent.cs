using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppContent
{
    public int ContentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public string? Code { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<AppContentallergy> AppContentallergies { get; } = new List<AppContentallergy>();

    public virtual ICollection<AppRecipe> AppRecipes { get; } = new List<AppRecipe>();
}
