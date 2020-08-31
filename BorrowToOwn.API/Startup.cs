using System;
using AutoMapper;
using BorrowToOwn.API.Extensions;
using BorrowToOwn.Data.Data;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Data.Repository.Contracts;
using BorrowToOwn.Data.Repository.Implementations;
using BorrowToOwn.Services.Contracts;
using BorrowToOwn.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace BorrowToOwn.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _env = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IConfiguration>();
            var migrationAssembly = typeof(Startup).Assembly.GetName().Name;
            var webOrigin = Configuration["ApplicationSettings:WebClientOrigin"];
            services.AddCors(options =>
            {
                options.AddPolicy("defaultCorsPolicy", policy =>
                {
                    policy.WithOrigins(webOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddControllers()
                .AddMvcOptions(options =>
                {
                    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });

            var connection = Configuration.GetConnectionString("BorrowPgConnection");

            services.AddDbContext<BorrowContext>(options =>
                options.UseNpgsql(connection,
                                     sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)
                )
                );

            services.AddHttpClients(Configuration);

            //Configure Application User
            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                //prevents instant sign in upon immediate registration
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<BorrowContext>()
                .AddDefaultTokenProviders();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(assemblies);
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPaymentPlan, PaymentPlanRepository>();
            services.AddScoped<IPaymentPlanService, PaymentPlanService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository,BrandRepository>();


            DbMigrations.EnsureSeedData(connection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async (context) =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    var result = JsonConvert.SerializeObject(new { ErrorMessage = exception.Message });
                    context.Response.ContentType = "Application/Json";
                    await context.Response.WriteAsync(result);
                });
            });
            app.UseCors("defaultCorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseStatusCodePages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
