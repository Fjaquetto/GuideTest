using GuideAPI.Application.Interfaces;
using GuideAPI.Application.Services;
using GuideAPI.Domain.Interface;
using GuideAPI.Infra.Data.Context;
using GuideAPI.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideAPI.CC.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IAutoresAppService, AutoresAppService>();

            // Infra - Data
            services.AddScoped<IAutoresRepository, AutoresRepository>();
            services.AddScoped<GuideContext>();
        }
    }
}
