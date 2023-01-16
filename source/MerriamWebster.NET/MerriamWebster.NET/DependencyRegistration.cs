using System;
using MerriamWebster.NET.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace MerriamWebster.NET
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class DependencyRegistration
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Registers the classes that are required to make calls to the Merriam-Webster API.
        /// </summary>
        /// <param name="services">The IServiceCollection.</param>
        /// <param name="config">The configuration. A valid API key should be present.</param>
        /// <returns>The IServiceCollection</returns>
        public static IServiceCollection RegisterMerriamWebster(this IServiceCollection services, MerriamWebsterConfig config)
        {
            services.AddSingleton(config);
            services.AddHttpClient<IMerriamWebsterClient, MerriamWebsterClient>(client =>
                {
                    client.BaseAddress = Configuration.ApiBaseAddress;
                })
                .AddTransientHttpErrorPolicy(builder => builder.RetryAsync(2));


           // services.AddTransient<IEntryParser, EntryParser>();

            return services;
        }
    }
}