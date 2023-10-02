using HotelListing;
using HotelListing.Configurations;
using HotelListing.Data;
using HotelListing.IRepository;
using HotelListing.Repository;
using HotelListing.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Serilog;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration; 

// Add services to the container.

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager,  AuthManager>();   
builder.Services.AddCors(o => { o.AddPolicy("AllowAll", builder =>
                   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                    });
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();
builder.Services.ConfigureJWT(config);
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureVersioning();
builder.Services.AddHttpCacheHeaders();



builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("120SecondsDuration", new Microsoft.AspNetCore.Mvc.CacheProfile
    {
        Duration = 120
    });
}).AddNewtonsoftJson(o
    => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 

}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Hotel Listing API");
});

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseResponseCaching();
app.UseHttpCacheHeaders();  
app.UseAuthorization();
app.UseIpRateLimiting();


app.MapControllers();

app.Run();
