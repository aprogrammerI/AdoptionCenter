using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Domain_Models;
using Domain.Identity_Models;

namespace Repository
{
    public class ApplicationDbContext : IdentityDbContext<AdoptionCenterUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Shelter> Shelters { get; set; }
        public virtual DbSet<Adoption_Application> Adoption_Applications { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Shelter)
                .WithMany(s => s.Pets)
                .HasForeignKey(p => p.ShelterId)
                .OnDelete(DeleteBehavior.Cascade); 
        }*/

    }
}
