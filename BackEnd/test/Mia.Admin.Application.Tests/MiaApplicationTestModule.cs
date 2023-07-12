using Volo.Abp.Modularity;

namespace Mia.Admin;

[DependsOn(
    typeof(MiaApplicationModule),
    typeof(MiaDomainTestModule)
    )]
public class MiaApplicationTestModule : AbpModule
{

}
