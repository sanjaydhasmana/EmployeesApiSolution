using AutoMapper;
using EmployeesApi.Data;
using EmployeesApi.Profiles;
using EmployeesApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi
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
            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfile<EmployeeAutomapperProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton<MapperConfiguration>(mapperConfig);
            services.AddSingleton<IMapper>(mapper);

            // added this for the employee controller
            services.AddScoped<IManageEmployeeData, EfSqlServerEmployeeData>();
            services.AddDbContext<EmployeesDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("employees"));
            });

            services.AddFeatureManagement(Configuration.GetSection("flags"));
            services.AddHttpClient<ApiOnCallService>(options =>
            {
                options.BaseAddress = new Uri(Configuration["nodeApi"]);
            });
            // services.AddTransient
            services.AddTransient<IProvideStatus, NodeJsDeveloperOnCallStatusProvider>();
            // services.AddScoped
            // services.AddSingleton
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeesApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeesApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
