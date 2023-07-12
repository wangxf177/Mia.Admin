using Localization.Resources.AbpUi;
using Mia.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Mia.Admin;

[DependsOn(
    typeof(MiaApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
    )]
public class MiaHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MiaResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
