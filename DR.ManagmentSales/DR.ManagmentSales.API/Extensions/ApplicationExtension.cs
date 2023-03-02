using DR.ManagmentSales.API.Helpers;
using DR.ManagmentSales.Application;

namespace DR.ManagmentSales.API.Extensions
{
    public static class ApplicationExtension
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<UsuarioService>();
            services.AddScoped<StatusCodeBuilder>();
            services.AddScoped<TokenService>();
            services.AddScoped<CryptoService>();
            services.AddScoped<AsesorService>();
            services.AddScoped<ProductoService>();            
            services.AddScoped<VentaService>();
        }
    }
}
