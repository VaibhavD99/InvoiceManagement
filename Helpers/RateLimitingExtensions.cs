using AspNetCoreRateLimit;

namespace InvoiceManagement.Helpers
{
    public static class RateLimitingExtensions
    {
        public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddMemoryCache();

            // Load general settings from appsettings.json
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
            services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

            // rate limiting dependencies
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            // dependency for processing strategy
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            return services;
        }
    }
}
