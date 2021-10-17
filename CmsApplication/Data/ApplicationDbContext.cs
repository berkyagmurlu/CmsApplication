using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CmsApplication.Areas.Panel.Models;

namespace CmsApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Config> Config { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}
