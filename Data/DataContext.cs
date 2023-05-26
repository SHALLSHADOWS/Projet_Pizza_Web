using Microsoft.EntityFrameworkCore;
using Projet_Web_Pizza.Models;

namespace Projet_Web_Pizza.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
