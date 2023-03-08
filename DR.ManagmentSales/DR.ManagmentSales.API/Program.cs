using DR.ManagmentSales.API.Extensions;
using DR.ManagmentSales.API.Helpers;
using TarjetaPresentacion.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureDefaults();
builder.Services.ConfigureCors();

builder.Services.ConfigureUtils();

builder.Services.RegisterInfraestructure();
builder.Services.RegisterApplication();

builder.Services.AddSingleton<ResponseFactory>();
builder.Services.AddSingleton<ErrorResponseFactory>();
builder.Services.AddSingleton<SuccesResponseFactory>();

builder.Services.AddMvc(
            options => {
                options.EnableEndpointRouting = false;
                options.Filters.Add(typeof(ExceptionFilter));
            });


builder.Services.ConfigureJWToken();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
