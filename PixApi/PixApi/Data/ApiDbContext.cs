using Microsoft.EntityFrameworkCore;
using PixApi.Data.Map;
using PixApi.Models;

namespace PixApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Transition> Transitions { get; set; }
        public DbSet<KeyModel> Keys { get; set; }
        public DbSet<ClientModel> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new KeyMap());
            modelBuilder.ApplyConfiguration(new TransitionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
