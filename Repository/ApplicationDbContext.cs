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
      
    }
}
