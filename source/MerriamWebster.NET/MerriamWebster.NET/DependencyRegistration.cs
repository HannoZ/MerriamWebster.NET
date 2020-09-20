using MerriamWebster.NET.Parsing;
using Microsoft.Extensions.DependencyInjection;

namespace MerriamWebster.NET
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterMerriamWebster(this IServiceCollection services, MerriamWebsterConfig config)
        {
            services.AddSingleton(config);
            services.AddHttpClient<IMerriamWebsterClient, MerriamWebsterClient>(client =>
            {
                client.BaseAddress = Configuration.ApiBaseAddress;
            });

            services.AddTransient<IEntryParser, EntryParser>();

            return services;
        }
    }
}