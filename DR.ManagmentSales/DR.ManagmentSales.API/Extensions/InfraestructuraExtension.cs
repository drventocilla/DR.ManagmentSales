using Core.InfraestructuraEF;
using DR.ManagmentSales.Infrastructure;
using DR.ManagmentSales.Infrastructure.Interface;
using DR.ManagmentSales.Infrastructure.Repositories;
using DR.ManagmentSales.Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;

namespace DR.ManagmentSales.API.Extensions;
    public  static class InfraestructureExtension
    {

        public static void RegisterInfraestructure(this IServiceCollection services) {


            services.AddDbContext<DbContext, ManagmentSalesContext>(options =>
            options
               
                .UseInMemoryDatabase(databaseName: "Exchange")
                .EnableSensitiveDataLogging(false)

            );

            services.AddScoped<IManagmentSalesUOW, ManagmentSalesUOW>();

            services.AddTransient(typeof(IRepositoryGeneric<>), typeof(BaseRepository<>));

            //services.AddTransient<ICurrencyRepository, CurrencyRepository>();

        }

    }
}
