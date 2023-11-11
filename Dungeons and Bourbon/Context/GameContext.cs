using ClassLibrary;
using Microsoft.EntityFrameworkCore;

public class GameContext : DbContext
{
    public string DbPath { get; }
    public GameContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "game.db");

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<Armor> Armors { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<ConsumableStatUpItem> ConsumableStatUpItems { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Monster> Monsters { get; set; }
    public DbSet<Stage> Stages { get; set; }
    public DbSet<Player> Players { get; set; }    
}