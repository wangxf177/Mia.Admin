using Mia.Admin.MongoDB;
using Volo.Abp.Modularity;

namespace Mia.Admin;

[DependsOn(
    typeof(MiaMongoDbTestModule)
    )]
public class MiaDomainTestModule : AbpModule
{

}
