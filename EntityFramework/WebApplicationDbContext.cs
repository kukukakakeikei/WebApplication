using Microsoft.EntityFrameworkCore;
using Entites;
using System.Reflection;
using EntityFramework.Mappings;


namespace EntityFramework
{
    public class WebApplicationDbContext : DbContext
    {
        public WebApplicationDbContext(DbContextOptions<WebApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //映射实体
            modelBuilder.ApplyConfiguration(new PlayerMap());
            modelBuilder.ApplyConfiguration(new CharacterMap());
            //应用种子数据
            modelBuilder.Entity<Player>()
                .HasData(DataSeed.Players);
            modelBuilder.Entity<Character>()
                .HasData(DataSeed.Characters);
        }
    }
}
