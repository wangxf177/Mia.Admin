using Mia.Admin.Account;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Mia.Admin.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class MiaDbContext : AbpDbContext<MiaDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules


    public DbSet<MiaUser> MiaUsers { get; set; }

    #endregion

    public MiaDbContext(DbContextOptions<MiaDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        //builder.ConfigurePermissionManagement();
        //builder.ConfigureSettingManagement();
        //builder.ConfigureBackgroundJobs();
        //builder.ConfigureAuditLogging();
        //builder.ConfigureIdentity();
        //builder.ConfigureOpenIddict();
        //builder.ConfigureFeatureManagement();
        //builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AdminConsts.DbTablePrefix + "YourEntities", AdminConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
