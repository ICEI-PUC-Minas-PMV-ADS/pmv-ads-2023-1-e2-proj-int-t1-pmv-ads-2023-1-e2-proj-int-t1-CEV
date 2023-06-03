using cev.api.Application;
using cev.api.Domain.Interfaces;

namespace cev.api.Uteis
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterApplications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IVendedorApplication, VendedorApplication>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<IVendaApplication, VendaApplication>();

            return services;
        }
    }
}
