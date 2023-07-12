using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Mia.Admin.MongoDB;

[DependsOn(
    typeof(MiaTestBaseModule),
    typeof(MiaMongoDbModule)
    )]
public class MiaMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = MiaMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
