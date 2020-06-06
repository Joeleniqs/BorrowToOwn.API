using BorrowToOwn.API.Data;
using BorrowToOwn.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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

        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _env = environment;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssembly = typeof(Startup).Assembly.GetName().Name;

            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
