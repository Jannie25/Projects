using Euromonitor.DataHelper.Interfaces;
using Euromonitor.DataHelper.Models;
using Euromonitor.DataHelper.Services;
using Euromonitor.JWTHelper.Interfaces;
using Euromonitor.JWTHelper.Middleware;
using Euromonitor.JWTHelper.Models;
using Euromonitor.JWTHelper.Services;
using Euromonitor.Repository.Classes;
using Euromonitor.Repository.Interfaces;
using Euromonitor.Services.Classes;
using Euromonitor.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Euromonitor.Authentication
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
            services.AddCors();
            services.AddControllers();
            services.AddTokenAuthentication(Configuration);
            services.Configure<JWTConfig>(Configuration.GetSection("JwtConfig"));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddScoped<IDapperService, DapperService>();
            services.AddScoped<IJWTService, JwtService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Authentication Info Service API",
                    Version = "v2",
                    Description = "Sample service",
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Authentication Services"));
        }
    }
}
