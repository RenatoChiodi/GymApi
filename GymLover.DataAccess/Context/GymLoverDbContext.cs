using GymLover.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymLover.DataAccess.Context
{
    public class GymLoverDbContext : DbContext
    {
        public GymLoverDbContext(DbContextOptions<GymLoverDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Gym> Gym { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();//.ToTable("Course");
            modelBuilder.Entity<Gym>();
        }
    }
}
