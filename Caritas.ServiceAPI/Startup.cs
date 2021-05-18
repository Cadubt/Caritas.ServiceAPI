using System;
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
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Caritas.ServiceAPI.Models;

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
            services.AddCors();
            services.AddDbContext<CaritasContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("CaritasDev"));
            });

            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //TOKEN
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShelteredService, ShelteredService>();
            services.AddScoped<IScheduleSheetService, ScheduleSheetService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IVisitorService, VisitorService>();
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShelteredRepository, ShelteredRepository>();
            services.AddScoped<IScheduleSheetRepository, ScheduleSheetRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();

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
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
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


            app.UseCors(builder => builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API Authentication V1");
            });

            //app.UseCors(
            //    options => options.WithOrigins("http://localhost:4200", "http://caritas.cadubt.com.br").AllowAnyMethod()
            //);
            app.UseMvc();

        }
    }
}
