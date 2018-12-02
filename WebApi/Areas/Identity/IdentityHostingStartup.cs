using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverdaleMainApp2_0.Areas.Identity.Data;
using RiverdaleMainApp2_0.Models;

//[assembly: HostingStartup(typeof(RiverdaleMainApp2_0.Areas.Identity.IdentityHostingStartup))]
//namespace RiverdaleMainApp2_0.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<RiverdaleMainApp2_0Context>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("RiverdaleMainApp2_0ContextConnection")));

//                services.AddDefaultIdentity<RiverdaleMainApp2_0User>()
//                    .AddEntityFrameworkStores<RiverdaleMainApp2_0Context>();
//            });
//        }
//    }
//}