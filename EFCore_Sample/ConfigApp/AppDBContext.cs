using EFCore_Sample.EntityModels.Employee;
using EFCore_Sample.EntityModels.Phrase;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Sample.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
     
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Phrase> Phrases { get; set; }

    }
}
