using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UndergroundInnovation.Models;

namespace UndergroundInnovation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<Interest> Interests { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=underground_innovation;Password=Changeme1;Database=underground_innovation");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUserInterest>()
                .HasKey(t => new { t.ApplicationUserId, t.InterestId });

            builder.Entity<ApplicationUserInterest>()
                .HasOne(aui => aui.ApplicationUser)
                .WithMany(au => au.ApplicationUserInterests)
                .HasForeignKey(aui => aui.ApplicationUserId);

            builder.Entity<ApplicationUserInterest>()
                .HasOne(aui => aui.Interest)
                .WithMany(i => i.ApplicationUserInterests)
                .HasForeignKey(aui => aui.InterestId);
        }
    }
}
