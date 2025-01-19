using Api_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_1.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
