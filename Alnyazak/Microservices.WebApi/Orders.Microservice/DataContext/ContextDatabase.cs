using Microsoft.EntityFrameworkCore;
using Orders.Microservice.Entity.Models;

namespace Orders.Microservice.DataContext
{
    public class ContextDatabase : DbContext    
    {
        public ContextDatabase(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Order> ORDER_ENTITYE { get; set; }
    }
}
