using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace web_app.Models.Repository;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; } = new List<AspNetUserToken>();

    public virtual ICollection<AspNetRole> Roles { get; } = new List<AspNetRole>();
    public static AspNetUser FromIdentityUser(IdentityUser User)
    {
        AspNetUser aspNetUser = new AspNetUser();
        aspNetUser.Id = User.Id;
        aspNetUser.UserName = User.UserName;
        aspNetUser.NormalizedUserName = User.NormalizedUserName;
        aspNetUser.Email = User.Email;
        aspNetUser.NormalizedEmail = User.NormalizedEmail;
        aspNetUser.EmailConfirmed = User.EmailConfirmed;
        aspNetUser.PasswordHash = User.PasswordHash;
        aspNetUser.SecurityStamp = User.SecurityStamp;
        aspNetUser.ConcurrencyStamp = User.ConcurrencyStamp;
        aspNetUser.PhoneNumber = User.PhoneNumber;
        aspNetUser.PhoneNumberConfirmed = User.PhoneNumberConfirmed;
        aspNetUser.TwoFactorEnabled = User.TwoFactorEnabled;
        aspNetUser.LockoutEnd = User.LockoutEnd;
        aspNetUser.LockoutEnabled = User.LockoutEnabled;
        aspNetUser.AccessFailedCount = User.AccessFailedCount;
        return aspNetUser;
    }
}
