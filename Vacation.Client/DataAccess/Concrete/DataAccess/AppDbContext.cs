using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;    

namespace DataAccess.Concrete.DataAccess
{
    public class AppDbContext:IdentityDbContext<Employee>
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        //{

        //}
        //public AppDbContext():base()
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-G2C8GG2\\SQLEXPRESS;Database=VacationDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacations> Vacations { get; set; }
        public DbSet<VacationApply> VacationsApply { get; set; }
    }
}
