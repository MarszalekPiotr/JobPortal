using JobPortal.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure
{
    public  class Context : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //public DbSet<Person> Persons { get; set; }
        public DbSet<JobTag> JobTags { get; set; }
        public DbSet<Job> Jobs { get; set; }
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Application> Applications { get; set; }




        public Context(DbContextOptions options):base(options)
       {


       }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<User>()
            //    .HasOne(p => p.Person)
            //    .WithOne(u => u.User)
            //    .HasForeignKey<Person>(e => e.UserId);

            //builder.Entity<User>()
            //    .HasOne(c => c.Company)
            //    .WithOne(u => u.User)
            //    .HasForeignKey<Company>(e => e.UserId);


            builder.Entity<JobTag>()
                .HasKey(jt => new { jt.JobId, jt.TagId });

            builder.Entity<JobTag>()
                .HasOne<Job>(jt => jt.Job)
                .WithMany(j => j.JobTags)
                .HasForeignKey(jt => jt.JobId);

            builder.Entity<JobTag>()
                .HasOne<Tag>(jt => jt.Tag)
                .WithMany(t => t.JobTags)
                .HasForeignKey(jt => jt.TagId);


            builder.Entity<Application>()
                .HasKey(ap => new { ap.JobId, ap.UserId });


            builder.Entity<Application>()
                .HasOne<Job>(ap => ap.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(ap => ap.JobId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Application>()
                .HasOne<User>(ap => ap.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(ap => ap.UserId)
                .OnDelete(DeleteBehavior.NoAction);
                




        }

    }
}
