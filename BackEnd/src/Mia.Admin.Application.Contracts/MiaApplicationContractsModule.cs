﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace Mia.Admin;

[DependsOn(
    typeof(AdminDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
public class MiaApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        MiaDtoExtensions.Configure();
    }
}
