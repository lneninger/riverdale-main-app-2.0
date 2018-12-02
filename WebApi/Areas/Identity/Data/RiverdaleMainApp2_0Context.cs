using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RiverdaleMainApp2_0.Areas.Identity.Data;

namespace RiverdaleMainApp2_0.Models
{
    public class RiverdaleMainApp2_0Context : IdentityDbContext<RiverdaleMainApp2_0User>
    {
        public RiverdaleMainApp2_0Context(DbContextOptions<RiverdaleMainApp2_0Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
