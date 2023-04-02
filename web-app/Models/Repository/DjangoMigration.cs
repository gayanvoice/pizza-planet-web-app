using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class DjangoMigration
{
    public long Id { get; set; }

    public string App { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTimeOffset Applied { get; set; }
}
