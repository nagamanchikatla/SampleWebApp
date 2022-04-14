using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SampleWebApp.Models;
using Newtonsoft.Json;

namespace SampleWebApp.Data
{
    public class RetroDBContext: DbContext
    {
        public RetroDBContext(DbContextOptions<RetroDBContext> options): base(options)
        {

        }

        public DbSet<Models.Retro> Retros { get; set; }
        public DbSet<Models.Feedback> Feedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Retro>(entity => {
                entity.HasIndex(e => e.RName).IsUnique();
            });
            modelBuilder.Entity<Feedback>(entity => {
                entity.HasIndex(e => e.RName).IsUnique();
            });
            modelBuilder.Entity<Retro>().Property(e => e.PName)
                .HasConversion(
                n => JsonConvert.SerializeObject(n),
                n => JsonConvert.DeserializeObject<List<string>>(n)
                );
            modelBuilder.Entity<Retro>().Property(e => e.Fdback)
                .HasConversion(
                n => JsonConvert.SerializeObject(n),
                n => JsonConvert.DeserializeObject<List<Feedback>>(n)
                );
        }
    }
}
