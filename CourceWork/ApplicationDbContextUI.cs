using CourceWork.Areas.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CourceWork
{
    public class ApplicationDbContextUI : IdentityDbContext<ApplicationUser>
    {   
        public ApplicationDbContextUI(DbContextOptions<ApplicationDbContextUI> options): base(options)
        {
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
