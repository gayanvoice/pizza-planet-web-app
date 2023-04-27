using Microsoft.EntityFrameworkCore;
using web_app.Models.Repository;

namespace web_app.Context;

public partial class RsMssqlContext : DbContext
{
    public RsMssqlContext()
    {
    }

    public RsMssqlContext(DbContextOptions<RsMssqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppAddress> AppAddresses { get; set; }
    public virtual DbSet<AppAlergy> AppAllergies { get; set; }

    public virtual DbSet<AppBasket> AppBaskets { get; set; }

    public virtual DbSet<AppCheckout> AppCheckouts { get; set; }

    public virtual DbSet<AppConfiguration> AppConfigurations { get; set; }

    public virtual DbSet<AppContent> AppContents { get; set; }

    public virtual DbSet<AppContentallergy> AppContentallergies { get; set; }
    public virtual DbSet<AppDelivery> AppDeliverys { get; set; }
    public virtual DbSet<AppGuide> AppGuides { get; set; }

    public virtual DbSet<AppPayment> AppPayments { get; set; }

    public virtual DbSet<AppProduct> AppProducts { get; set; }

    public virtual DbSet<AppProductguide> AppProductguides { get; set; }

    public virtual DbSet<AppRecipe> AppRecipes { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<AuthGroup> AuthGroups { get; set; }

    public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermissions { get; set; }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; }

    public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }

    public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=tcp:rs-mssql.database.windows.net,1433;Initial Catalog=rs-mssql;Persist Security Info=False;User ID=rsuser;Password=rspassword1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__app_addr__091C2AFB72F9216C");

            entity.ToTable("app_address");

            entity.Property(e => e.AspNetUsersId).HasMaxLength(450);
            entity.Property(e => e.HouseNumber).HasMaxLength(450);
            entity.Property(e => e.Street).HasMaxLength(450);
            entity.Property(e => e.PostCode).HasMaxLength(20);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.Region).HasMaxLength(40);
            entity.Property(e => e.Longitude).HasMaxLength(20);
            entity.Property(e => e.Latitude).HasMaxLength(20);
        });

        modelBuilder.Entity<AppAlergy>(entity =>
        {
            entity.HasKey(e => e.AllergyId).HasName("PK__app_alle__A49EBE42DA86C170");

            entity.ToTable("app_allergy");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<AppBasket>(entity =>
        {
            entity.HasKey(e => e.BasketId).HasName("PK__app_bask__8FDA77B5A5CFC75F");

            entity.ToTable("app_basket");

            entity.HasIndex(e => e.CheckoutIdId, "app_basket_CheckoutId_id_4e815cf2");

            entity.HasIndex(e => e.ProductIdId, "app_basket_ProductId_id_c8d51ab2");

            entity.Property(e => e.CheckoutIdId).HasColumnName("CheckoutId_id");
            entity.Property(e => e.ProductIdId).HasColumnName("ProductId_id");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.CheckoutId).WithMany(p => p.AppBaskets)
                .HasForeignKey(d => d.CheckoutIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_basket_CheckoutId_id_4e815cf2_fk_app_checkout_CheckoutId");

            entity.HasOne(d => d.ProductId).WithMany(p => p.AppBaskets)
                .HasForeignKey(d => d.ProductIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_basket_ProductId_id_c8d51ab2_fk_app_product_ProductId");
        });

        modelBuilder.Entity<AppCheckout>(entity =>
        {
            entity.HasKey(e => e.CheckoutId).HasName("PK__app_chec__E07EF5FC9BDEBEFE");

            entity.ToTable("app_checkout");

            entity.Property(e => e.AspNetUsersId).HasMaxLength(450);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<AppConfiguration>(entity =>
        {
            entity.HasKey(e => e.ConfigurationId).HasName("PK__app_conf__95AA53BB1ED4401E");

            entity.ToTable("app_configuration");

            entity.Property(e => e.Attribute).HasMaxLength(256);
            entity.Property(e => e.Value).HasMaxLength(1024);
        });

        modelBuilder.Entity<AppContent>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__app_cont__2907A81EB546DE3B");

            entity.ToTable("app_content");

            entity.Property(e => e.Code).HasMaxLength(8);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<AppContentallergy>(entity =>
        {
            entity.HasKey(e => e.AllergyContentId).HasName("PK__app_alle__B7B236D92CD65DD6");

            entity.ToTable("app_contentallergy");

            entity.HasIndex(e => e.AllergyIdId, "app_allergycontent_AllergyId_id_43a9bebe");

            entity.HasIndex(e => e.ContentIdId, "app_allergycontent_ContentId_id_17804b61");

            entity.Property(e => e.AllergyIdId).HasColumnName("AllergyId_id");
            entity.Property(e => e.ContentIdId).HasColumnName("ContentId_id");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.AllergyId).WithMany(p => p.AppContentallergies)
                .HasForeignKey(d => d.AllergyIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_allergycontent_AllergyId_id_43a9bebe_fk_app_allergy_AllergyId");

            entity.HasOne(d => d.ContentId).WithMany(p => p.AppContentallergies)
                .HasForeignKey(d => d.ContentIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_allergycontent_ContentId_id_17804b61_fk_app_content_ContentId");
        });
        modelBuilder.Entity<AppDelivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__app_deli__626D8FCE507791E3");

            entity.ToTable("app_delivery");

            entity.HasIndex(e => e.DeliveryId);
            entity.HasIndex(e => e.AuthUserId);
            entity.Property(e => e.CheckoutId);
            entity.Property(e => e.Status);
            entity.Property(e => e.Latitude).HasMaxLength(10);
            entity.Property(e => e.Longitude).HasMaxLength(10);
            entity.Property(e => e.CreateTime);
            entity.Property(e => e.ModifyTime);
        });
        modelBuilder.Entity<AppGuide>(entity =>
        {
            entity.HasKey(e => e.GuideId).HasName("PK__app_guid__E77EE05EDE1410C6");

            entity.ToTable("app_guide");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<AppPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__app_paym__9B556A388C3A0D10");

            entity.ToTable("app_payment");

            entity.HasIndex(e => e.CheckoutIdId, "app_payment_CheckoutId_id_45f98c3f");

            entity.Property(e => e.CheckoutIdId).HasColumnName("CheckoutId_id");
            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Type).HasMaxLength(40);

            entity.HasOne(d => d.CheckoutId).WithMany(p => p.AppPayments)
                .HasForeignKey(d => d.CheckoutIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_payment_CheckoutId_id_45f98c3f_fk_app_checkout_CheckoutId");
        });

        modelBuilder.Entity<AppProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__app_prod__B40CC6CDE2F47340");

            entity.ToTable("app_product");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.Size).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<AppProductguide>(entity =>
        {
            entity.HasKey(e => e.ProductGuideId).HasName("PK__app_prod__72D53FCEB6A52EDC");

            entity.ToTable("app_productguide");

            entity.HasIndex(e => e.GuideIdId, "app_productguide_GuideId_id_2759f0d8");

            entity.HasIndex(e => e.ProductIdId, "app_productguide_ProductId_id_90b90b10");

            entity.Property(e => e.GuideIdId).HasColumnName("GuideId_id");
            entity.Property(e => e.ImageUrl).HasMaxLength(256);
            entity.Property(e => e.ProductIdId).HasColumnName("ProductId_id");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.GuideId).WithMany(p => p.AppProductguides)
                .HasForeignKey(d => d.GuideIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_productguide_GuideId_id_2759f0d8_fk_app_guide_GuideId");

            entity.HasOne(d => d.ProductId).WithMany(p => p.AppProductguides)
                .HasForeignKey(d => d.ProductIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_productguide_ProductId_id_90b90b10_fk_app_product_ProductId");
        });

        modelBuilder.Entity<AppRecipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__app_reci__FDD988B0BC4C61E0");

            entity.ToTable("app_recipe");

            entity.HasIndex(e => e.ContentIdId, "app_recipe_ContentId_id_1ae44ee9");

            entity.HasIndex(e => e.ProductIdId, "app_recipe_ProductId_id_6222f131");

            entity.Property(e => e.ContentIdId).HasColumnName("ContentId_id");
            entity.Property(e => e.Measurement).HasMaxLength(20);
            entity.Property(e => e.ProductIdId).HasColumnName("ProductId_id");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.ContentId).WithMany(p => p.AppRecipes)
                .HasForeignKey(d => d.ContentIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_recipe_ContentId_id_1ae44ee9_fk_app_content_ContentId");

            entity.HasOne(d => d.ProductId).WithMany(p => p.AppRecipes)
                .HasForeignKey(d => d.ProductIdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("app_recipe_ProductId_id_6222f131_fk_app_product_ProductId");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83F512E92B4");

            entity.ToTable("auth_group");

            entity.HasIndex(e => e.Name, "auth_group_name_a6ea08ec_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AuthGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83FD055A2BF");

            entity.ToTable("auth_group_permissions");

            entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

            entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                .IsUnique()
                .HasFilter("([group_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_per__3213E83FEAB537CE");

            entity.ToTable("auth_permission");

            entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

            entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                .IsUnique()
                .HasFilter("([content_type_id] IS NOT NULL AND [codename] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codename)
                .HasMaxLength(100)
                .HasColumnName("codename");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermissions)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_content_type_id");
        });

        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83FBB0BE679");

            entity.ToTable("auth_user");

            entity.HasIndex(e => e.Username, "auth_user_username_6821ab7c_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateJoined).HasColumnName("date_joined");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsStaff).HasColumnName("is_staff");
            entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AuthUserGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83F530196CE");

            entity.ToTable("auth_user_groups");

            entity.HasIndex(e => e.GroupId, "auth_user_groups_group_id_97559544");

            entity.HasIndex(e => e.UserId, "auth_user_groups_user_id_6a12ed8b");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq")
                .IsUnique()
                .HasFilter("([user_id] IS NOT NULL AND [group_id] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserUserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_use__3213E83FB1CB841C");

            entity.ToTable("auth_user_user_permissions");

            entity.HasIndex(e => e.PermissionId, "auth_user_user_permissions_permission_id_1fbb5f2c");

            entity.HasIndex(e => e.UserId, "auth_user_user_permissions_user_id_a95ead1b");

            entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq")
                .IsUnique()
                .HasFilter("([user_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_permission_id_1fbb5f2c_fk_auth_permission_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_a__3213E83F43F75A71");

            entity.ToTable("django_admin_log");

            entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

            entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionFlag).HasColumnName("action_flag");
            entity.Property(e => e.ActionTime).HasColumnName("action_time");
            entity.Property(e => e.ChangeMessage).HasColumnName("change_message");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectRepr)
                .HasMaxLength(200)
                .HasColumnName("object_repr");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.ContentTypeId)
                .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_c__3213E83F1DCA524A");

            entity.ToTable("django_content_type");

            entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                .IsUnique()
                .HasFilter("([app_label] IS NOT NULL AND [model] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppLabel)
                .HasMaxLength(100)
                .HasColumnName("app_label");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
        });

        modelBuilder.Entity<DjangoMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_m__3213E83F40941730");

            entity.ToTable("django_migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.App)
                .HasMaxLength(255)
                .HasColumnName("app");
            entity.Property(e => e.Applied).HasColumnName("applied");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("PK__django_s__B3BA0F1FB9AF2AD4");

            entity.ToTable("django_session");

            entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

            entity.Property(e => e.SessionKey)
                .HasMaxLength(40)
                .HasColumnName("session_key");
            entity.Property(e => e.ExpireDate).HasColumnName("expire_date");
            entity.Property(e => e.SessionData).HasColumnName("session_data");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
