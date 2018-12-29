using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApiDBContent : DbContext
    {
        public ApiDBContent(DbContextOptions<ApiDBContent> options) : base(options)
        {

        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<RoleAuthorize> RoleAuthorize { get; set; }
        public DbSet<ModuleButton> ModuleButton { get; set; }
        public DbSet<Organize> Organize { get; set; }
        public DbSet<UserLogOn> UserLogOn { get; set; }
        public DbSet<ItemsDetail> ItemsDetail { get; set; }
        public DbSet<Items> Items { get; set; }
    }

    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<ApiDBContent>
    {
        ApiDBContent IDesignTimeDbContextFactory<ApiDBContent>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDBContent>();
            optionsBuilder.UseSqlServer<ApiDBContent>("Server=.;Database=dbCore;User ID=sa;Password=123456;");

            return new ApiDBContent(optionsBuilder.Options);
        }
    }
}
