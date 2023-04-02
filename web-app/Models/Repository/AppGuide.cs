using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppGuide
{
    public int GuideId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<AppProductguide> AppProductguides { get; } = new List<AppProductguide>();
}
