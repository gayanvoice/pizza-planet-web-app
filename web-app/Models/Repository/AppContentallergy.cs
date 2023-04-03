using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppContentallergy
{
    public int AllergyContentId { get; set; }

    public string Status { get; set; } = null!;

    public int AllergyIdId { get; set; }

    public int ContentIdId { get; set; }

    public virtual AppAlergy AllergyId { get; set; } = null!;

    public virtual AppContent ContentId { get; set; } = null!;
}
