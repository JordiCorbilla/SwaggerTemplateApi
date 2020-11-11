using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;
using webapitemplate.Filters;

namespace webapitemplate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "WebApi", Version = "v1" });
                })
                .AddMvc(options => {
                    options.Filters.Add(new ExceptionFilter());
                    options.Filters.Add(new ProducesAttribute("application/json"));
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((_) => "The field is required.");
                });			
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var logEventLevel = LogEventLevel.Debug;
            var applicationName = "WebApi";
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Is(logEventLevel)
                            .WriteTo.Console()
                            .CreateLogger();

            Log.Information("Starting...");

            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "swagger/api/{documentname}/swagger.json";
            })
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/api/v1/swagger.json", $"{applicationName} v1.0");
                options.RoutePrefix = "swagger/api";
            })
            .UseMvc();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
