using System.Data.Entity;
using Data.Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
