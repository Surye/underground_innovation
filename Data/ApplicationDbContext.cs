using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UndergroundInnovation.Models;

namespace UndergroundInnovation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Interest> Interests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<PollAnswer> PollAnswers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() : base ()
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

            // Many to many for User Interests
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


            // Many to many for Project Membership
            builder.Entity<ProjectMembers>()
                .HasKey(t => new { t.UserId, t.ProjectId });

            builder.Entity<ProjectMembers>()
                .HasOne(aui => aui.User)
                .WithMany(au => au.ProjectMembers)
                .HasForeignKey(aui => aui.UserId);

            builder.Entity<ProjectMembers>()
                .HasOne(aui => aui.Project)
                .WithMany(i => i.ProjectMembers)
                .HasForeignKey(aui => aui.ProjectId);


            // Many to many for User Poll Answers
            builder.Entity<UserPollAnswers>()
                .HasKey(t => new { t.UserId, t.PollAnswerId });

            builder.Entity<UserPollAnswers>()
                .HasOne(aui => aui.User)
                .WithMany(au => au.UserPollAnswers)
                .HasForeignKey(aui => aui.UserId);

            builder.Entity<UserPollAnswers>()
                .HasOne(aui => aui.PollAnswer)
                .WithMany(i => i.UserPollAnswers)
                .HasForeignKey(aui => aui.PollAnswerId);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            var now = DateTime.Now;

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IDatedEntity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                }

                entity.UpdatedDate = now;
            }

            return base.SaveChanges();
        }

    }
}
