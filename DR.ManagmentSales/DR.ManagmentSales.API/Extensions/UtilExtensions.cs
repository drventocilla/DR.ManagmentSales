

using DR.ManagmentSales.API.Helpers;

namespace DR.ManagmentSales.API.Extensions
{
    public static  class UtilExtensions
    {
        public static void ConfigureUtils(this IServiceCollection services)
        {
            services.AddTransient<ResponseFactory>();

        }

    }
}
