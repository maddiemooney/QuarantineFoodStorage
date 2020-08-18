using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using QFS.Extensions;

namespace Microsoft.AspNetCore.Authentication
{
    /*
     * Configures Web API to require auth from the front end
     */
    public static class AzureAdServiceCollectionExtensions
    {

        public static AuthenticationBuilder AddAzureAdBearer(this AuthenticationBuilder builder)
                => builder.AddAzureAdBearer(_ => { });
        public static AuthenticationBuilder AddAzureAdBearer(this AuthenticationBuilder builder, Action<AuthBuilderSettings> configureOptions)
        {
            builder.Services.Configure(configureOptions);
            builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureAzureOptions>();
            builder.AddJwtBearer();
            return builder;
        }

        public class ConfigureAzureOptions : IConfigureNamedOptions<JwtBearerOptions>
        {
            private readonly IConfiguration config;
            public ConfigureAzureOptions(IConfiguration config)
            {
                this.config = config;
            }
            public void Configure(string name, JwtBearerOptions options)
            {
                options.Audience = config["Auth:ClientId"];
                options.Authority = $"{config["Auth:Instance"]}{config["Auth:TenantId"]}";
            }
            public void Configure(JwtBearerOptions options)
            {
                Configure(Options.DefaultName, options);
            }
        }

    }
}
