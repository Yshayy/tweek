﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tweek.ApiService.Addons;
using Tweek.Engine.Drivers.Rules;

namespace Tweek.Drivers.Rules.Minio
{
    public class RulesMinioAddon : ITweekAddon
    {
        public void Use(IApplicationBuilder builder, IConfiguration configuration)
        {
        }

        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var minioConfiguration = configuration.GetSection("Rules:Minio");

            var minioSettings = new MinioSettings
            {
                Endpoint = minioConfiguration.GetValue<string>("Endpoint"),
                Bucket = minioConfiguration.GetValue("Bucket", "tweek"),
                AccessKey = minioConfiguration.GetValueFromEnvOrFile("AccessKey", "AccessKeyPath"),
                SecretKey = minioConfiguration.GetValueFromEnvOrFile("SecretKey", "SecretKeyPath"),
                IsSecure = minioConfiguration.GetValue("Secure", false),
            };

            services.AddSingleton<IRulesDriver>(new MinioRulesDriver(minioSettings));
        }
    }
}