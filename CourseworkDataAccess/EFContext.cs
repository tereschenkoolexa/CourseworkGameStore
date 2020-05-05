using CourseworkDataAccess.Entity;
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

    }
}
