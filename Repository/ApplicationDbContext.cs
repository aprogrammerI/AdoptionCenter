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
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
    }
}
