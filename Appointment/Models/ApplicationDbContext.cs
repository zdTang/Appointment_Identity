using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Models
{
    // if we don't use Identity framework, we can just use "DbContext"
    // if we use customized IdentityUser, we should tell the DbContext
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        
        // https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/dbsets
        // It seems that no Virtual is need
        public DbSet<Appoint> Appointments { get; set; }

    }
}
