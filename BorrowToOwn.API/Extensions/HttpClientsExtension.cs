using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace BorrowToOwn.API.Extensions
{
    public static class HttpClientsExtension
    {
      
        public static void AddHttpClients(this IServiceCollection services , IConfiguration configuration) {
            services.AddHttpClient("S3BucketClient", client =>
            {
                client.BaseAddress = new Uri(configuration["ApplicationSettings:EniqsBucketUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

        }
    }
}
