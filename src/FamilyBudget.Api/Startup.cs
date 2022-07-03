using System;
using FamilyBudget.Domain.Interfaces.DataAccess;
using FamilyBudget.Domain.Interfaces.Services;
using FamilyBudget.Domain.Services;
using FamilyBudget.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FamilyBudget.Api
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
            services.AddDbContext<AppDbContext>();
            
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(Repository<>));
            services.AddScoped(typeof(IFinancialPeriodService), typeof(FinancialPeriodService));
            
            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<CorsMiddleware>();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}