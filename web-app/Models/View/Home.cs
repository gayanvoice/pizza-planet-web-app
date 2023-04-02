using Microsoft.AspNetCore.Identity;

namespace web_app.Models.Repository.View;

public partial class Home
{

    public partial class Index
    {
        public IEnumerable<AppCheckout?>? CheckoutEnumerable { get; set; }
        public AspNetUser? AspNetUser { get; set; }
        public static AspNetUser FromUser(IdentityUser User)
        {
            AspNetUser aspNetUser = new AspNetUser();
            aspNetUser.Id = User.Id;
            aspNetUser.UserName = User.UserName;
            aspNetUser.NormalizedUserName = User.NormalizedUserName;
            aspNetUser.Email = User.Email;
            aspNetUser.NormalizedEmail = User.NormalizedEmail;
            aspNetUser.EmailConfirmed = User.EmailConfirmed;
            aspNetUser.PasswordHash = User.PasswordHash;
            aspNetUser.SecurityStamp = User.PasswordHash;
            aspNetUser.ConcurrencyStamp = User.PasswordHash;
            aspNetUser.PhoneNumber = User.PasswordHash;
            aspNetUser.PhoneNumberConfirmed = User.PhoneNumberConfirmed;
            aspNetUser.TwoFactorEnabled = User.TwoFactorEnabled;
            aspNetUser.LockoutEnd = User.LockoutEnd;
            aspNetUser.LockoutEnabled = User.LockoutEnabled;
            aspNetUser.AccessFailedCount = User.AccessFailedCount;
            return aspNetUser;
        }
    }
}
