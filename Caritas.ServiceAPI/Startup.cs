using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Repositories;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Caritas.ServiceAPI.Services;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Caritas.ServiceAPI
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
            services.AddDbContext<CaritasContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("CaritasDev"));
            });
            
            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShelteredService, ShelteredService>();
            services.AddScoped<IScheduleSheetService, ScheduleSheetService>();
            services.AddScoped<IMenuService, MenuService>();
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShelteredRepository, ShelteredRepository>();
            services.AddScoped<IScheduleSheetRepository, ScheduleSheetRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddSwaggerGen(c =>
            {
                //Swagger Documentation properties
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Caritas API",
                    Version = "v1",
                    Description = "Web API | Cáritas Gestão de Acolhidos",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Cadu Torres",
                        Email = "cadubt@gmail.com",
                        Url = new Uri("https://google.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Application license",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                

            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API Authentication V1");
            });

            app.UseMvc();
        }
    }
}
