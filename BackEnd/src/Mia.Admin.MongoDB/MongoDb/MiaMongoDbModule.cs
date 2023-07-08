using Microsoft.Extensions.DependencyInjection;
using Mia.Admin.MongoDb;
using Volo.Abp.Auditing;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.Uow;

namespace Mia.Admin.MongoDB;

[DependsOn(typeof(MiaDomainModule), typeof(AbpMongoDbModule))]
public class MiaMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<MiaMongoDbContext>(options =>
        {
            options.AddDefaultRepositories();
            options.Services.AddTransient<IAuditPropertySetter, MiaAuditPropertySetter>();
        });

        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
    }
}
