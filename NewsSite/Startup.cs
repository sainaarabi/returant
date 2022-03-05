using DataLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ResturantProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public const string Admin_Cors = "ADMIN_CORS_POLICY";
        public const string Other_Cors = "OTHER_CORS_POLICY";
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));


            services.AddCors(option =>
                     {
                         option.AddPolicy(Other_Cors, builder =>
                              {
                                  builder
                                  .AllowAnyHeader()
                                  .AllowAnyOrigin()
                                  .AllowAnyMethod();
                              });
                     });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger Demo",
                    Description = "Swagger Demo - angular-netcore.ir",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "testttt",
                        Email = "gmail@gmail.com"
                    }
                });
            });

            services.AddTransient<DataLayer.IUnitOfWork, DataLayer.UnitOfWork>(sp =>
        {
            DataLayer.Tools.Options options =
                new DataLayer.Tools.Options
                {
                    Provider =
                        (DataLayer.Tools.Enums.Provider)
                        System.Convert.ToInt32(Configuration.GetSection(key: "DatabaseProvider").Value),

                    ConnectionString = Configuration.GetConnectionString("DefaultConnectionString"),

                };

            return new DataLayer.UnitOfWork(options: options);
        });

            //services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddDbContext<DataBaseContext>();



            
            services.AddHttpContextAccessor();



        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();
            app.UseCors(Other_Cors);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
