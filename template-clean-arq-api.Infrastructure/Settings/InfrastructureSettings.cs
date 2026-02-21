using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using template_clean_arq_api.Application.Abstraction;
using template_clean_arq_api.Infrastructure.Services;

namespace template_clean_arq_api.Infrastructure.Settings
{
    public static class InfrastructureSettings
    {
        public static IServiceCollection Infrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddScoped<IHeaderValidator, HeaderValidator>();
            return serviceCollection;
        }
    }
}
