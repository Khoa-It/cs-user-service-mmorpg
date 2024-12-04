using _3D_WebGame.Models;
using Microsoft.EntityFrameworkCore;

namespace _3D_WebGame.Configurations {
    public class GameDbContext : DbContext {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Friendship> friendship { get; set; }
    }
}
