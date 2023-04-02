using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppProductguide
{
    public int ProductGuideId { get; set; }

    public string Status { get; set; } = null!;

    public int GuideIdId { get; set; }

    public int ProductIdId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual AppGuide GuideId { get; set; } = null!;

    public virtual AppProduct ProductId { get; set; } = null!;
}
