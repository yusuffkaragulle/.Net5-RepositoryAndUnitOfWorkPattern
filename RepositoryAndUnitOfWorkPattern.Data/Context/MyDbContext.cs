using Microsoft.EntityFrameworkCore;
using RepositoryAndUnitOfWorkPattern.Data.Models;

namespace RepositoryAndUnitOfWorkPattern.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
