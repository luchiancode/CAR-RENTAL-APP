using System;
using CAR_RENTAL_APPLICATION.Areas.Identity.Data;
using CAR_RENTAL_APPLICATION.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CAR_RENTAL_APPLICATION.Areas.Identity.IdentityHostingStartup))]
namespace CAR_RENTAL_APPLICATION.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<APPLICATIONUser>(options => { 
                    
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                   
                })
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}