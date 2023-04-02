using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AppConfiguration
{
    public int ConfigurationId { get; set; }

    public string Attribute { get; set; } = null!;

    public string Value { get; set; } = null!;
}
