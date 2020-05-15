using CourseworkDataAccess.Entity;
using CourseworkDataAccess.Entity.Store.Product;
using CourseworkDataAccess.Entity.Store.Product.Communication;
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


        public DbSet<Product> Products { get; set; }
        public DbSet<SystemRequirements> SystemRequirements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductLanguages> ProductLanguages { get; set; }

        public DbSet<Library> Library { get; set; }

        public DbSet<SystemRequirements> SystemRequirementsProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasOne(u => u.UserMoreInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserMoreInfo>(uid => uid.id);

            builder.Entity<ProductCategories>()
            .HasKey(c => new { c.CategoryId, c.ProdctId });

            builder.Entity<ProductLanguages>()
            .HasKey(c => new { c.LanguageId, c.ProdctId });
            builder.Entity<Library>()
            .HasKey(c => new { c.UserId, c.ProdctId });

            base.OnModelCreating(builder);
        }

    }
}
