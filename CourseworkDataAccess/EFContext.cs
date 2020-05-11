using CourseworkDataAccess.Entity;
using CourseworkDataAccess.Entity.Store.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseworkDataAccess
{
    public class EFContext : IdentityDbContext<User>
    {

        public EFContext(DbContextOptions<EFContext> options): base(options) { }

        public DbSet<UserMoreInfo> UserMoreInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasOne(u => u.UserMoreInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserMoreInfo>(uid => uid.id);

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Languages> LanguagesProduct { get; set; }
        public DbSet<Categories> CategoriesProduct { get; set; }
        public DbSet<SystemRequirements> SystemRequirementsProduct { get; set; }

    }
}
