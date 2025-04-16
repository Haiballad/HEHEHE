using ASM.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM.AppDataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Mount> Mounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }
        public DbSet<PlayerMount> PlayerMounts { get; set; }
        public DbSet<PlayerQuest> PlayerQuests { get; set; }
        public DbSet<Quest> Quests { get; set; }

    }
}