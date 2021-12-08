using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("SEEDING DATA...");
                context.Platforms.AddRange(
                    new Platform() { Name="Dotnet", Publisher="Microsoft", Cost="Free" },
                    new Platform() { Name="SqlServer", Publisher="Microsoft", Cost="Free" },
                    new Platform() { Name="Kuberenetes", Publisher="CloudNative", Cost="Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ALREADY HAVE DATA");
            }
        }
    }
}
