using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class DjangoSession
{
    public string SessionKey { get; set; } = null!;

    public string SessionData { get; set; } = null!;

    public DateTimeOffset ExpireDate { get; set; }
}
