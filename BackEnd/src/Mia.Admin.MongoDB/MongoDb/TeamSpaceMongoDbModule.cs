using Microsoft.Extensions.DependencyInjection;
using Mia.Admin.MongoDb;
using Volo.Abp.Auditing;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.Uow;

namespace Mia.Admin.MongoDB;

[DependsOn(typeof(AdminDomainModule), typeof(AbpMongoDbModule))]
public class AdminMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<AdminMongoDbContext>(options =>
        {
            options.AddDefaultRepositories();
            options.Services.AddTransient<IAuditPropertySetter, AdminAuditPropertySetter>();
        });

        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
    }
}
