﻿using Localization.Resources.AbpUi;
using BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;

namespace BookStore;

[DependsOn(
    typeof(BookStoreApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class BookStoreHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BookStoreHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BookStoreResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });

        Configure<AbpAntiForgeryOptions>(options =>
        {
            options.AutoValidate = false;
        });
    }
}
