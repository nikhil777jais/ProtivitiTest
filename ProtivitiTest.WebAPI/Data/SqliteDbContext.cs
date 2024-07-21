using Microsoft.EntityFrameworkCore;
using ProtivitiTest.WebAPI.Models;

namespace ProtivitiTest.WebAPI.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; } 

    }
}
