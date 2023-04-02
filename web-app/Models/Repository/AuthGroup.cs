using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AuthGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; } = new List<AuthGroupPermission>();

    public virtual ICollection<AuthUserGroup> AuthUserGroups { get; } = new List<AuthUserGroup>();
}
