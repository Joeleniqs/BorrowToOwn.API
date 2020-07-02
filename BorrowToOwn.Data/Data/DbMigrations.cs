using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BorrowToOwn.Data.Data
{
    public class DbMigrations
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddDbContext<BorrowContext>(options =>
               options.UseNpgsql(connectionString));

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<BorrowContext>();
                    context.Database.Migrate();

                    if (!context.Products.Any())
                    {
                        //Add support for full -text search on products entity
                        string script = File.ReadAllText(@"BorrowToOwn.Migrations/Scripts/full-text-script.sql");
                        if (!string.IsNullOrEmpty(script))
                        {
                            context.Database.ExecuteSqlRaw(script);
                        }
                }


            }
            }

        }

    }
}
