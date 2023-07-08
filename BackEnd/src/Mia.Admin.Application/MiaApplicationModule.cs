using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Mia.Admin;

[DependsOn(
    typeof(MiaDomainModule),
    typeof(MiaApplicationContractsModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpDddApplicationModule)
    )]
public class MiaApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<MiaApplicationModule>();
        });
    }
}
