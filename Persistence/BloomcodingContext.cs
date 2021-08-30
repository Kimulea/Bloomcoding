using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class BloomcodingContext : DbContext
    {
        public BloomcodingContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(p => p.Email)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity(x => x.ToTable("UsersRoles"));

            builder.Entity<User>()
                .HasMany(x => x.Groups)
                .WithMany(x => x.Users)
                .UsingEntity(x => x.ToTable("UsersGroups"));

            builder.Entity<User>()
                .HasMany(x => x.FreeHours)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Group>()
                .HasMany(x => x.GroupStarts)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.Groupid);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<FreeHour> FreeHours { get; set; }
        public DbSet<GroupStart> GroupStarts { get; set; }
    }
}
