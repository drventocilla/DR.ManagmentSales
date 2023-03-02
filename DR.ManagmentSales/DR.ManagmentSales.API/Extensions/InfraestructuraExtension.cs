using Core.InfraestructuraEF;
using DR.ManagmentSales.Infrastructure;
using DR.ManagmentSales.Infrastructure.Interface;
using DR.ManagmentSales.Infrastructure.Repositories;
using DR.ManagmentSales.Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;

namespace DR.ManagmentSales.API.Extensions
{ 
    public  static class InfraestructureExtension
    {

        public static void RegisterInfraestructure(this IServiceCollection services) {


            services.AddDbContext<DbContext, ManagmentSalesContext>(options =>
            options
                //.UseSqlServer(Configuration.GetConnectionString(nameof(ExchangeDbContext))
                // //, options => options.EnableRetryOnFailure()
                // )
                .UseInMemoryDatabase(databaseName: "ManagmentSalesDB")
                //.UseLoggerFactory(loggerFactory)
                //.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                .EnableSensitiveDataLogging(true)

            );

            services.AddDbContext<ManagmentSalesContext>();
            services.AddTransient(typeof(IRepositoryGeneric<>), typeof(BaseRepository<>));
            services.AddTransient<IVentaRepository, VentaRepository>();
            services.AddScoped<IManagmentSalesUOW, ManagmentSalesUOW>();

            
        }

    }
}
