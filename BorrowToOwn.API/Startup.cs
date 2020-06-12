using System;
using AutoMapper;
using BorrowToOwn.Data.Data;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Data.Repository.Contracts;
using BorrowToOwn.Data.Repository.Implementations;
using BorrowToOwn.Services.Contracts;
using BorrowToOwn.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            var migrationAssembly = typeof(Startup).Assembly.GetName().Name;

            services.AddControllers()
                .AddMvcOptions(options =>
                {
                    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });
            services.AddDbContext<BorrowContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(_env.IsDevelopment() ? "BorrowConnection" : "BorrowConnection"),
                                     sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)
                                     ));
            //Configure Application User
            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                //prevents instant sign in upon immediate registration
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<BorrowContext>()
                .AddDefaultTokenProviders();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
