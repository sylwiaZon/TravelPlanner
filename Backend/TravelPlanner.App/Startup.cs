using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TravelPlanner.App.Helpers;
using TravelPlanner.App.Middleware;
using TravelPlanner.Core;
using TravelPlanner.Services;

namespace TravelPlanner.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DbSettings>(
                Configuration.GetSection(nameof(DbSettings)));

            services.AddSingleton<DbSettings>(sp =>
                sp.GetRequiredService<IOptions<DbSettings>>().Value);

            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TravelPlanner API",
                    Description = "A TravelPlanner ASP.NET Core Web API"
                });

                c.CustomSchemaIds(x => x.FullName);
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFlightsService, FlightsService>();
            services.AddScoped<IHotelsService, HotelsService>();
            services.AddScoped<ITravelInfoService, TravelInfoService>();
            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelPlanner V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
