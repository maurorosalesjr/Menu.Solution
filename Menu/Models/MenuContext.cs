using Microsoft.EntityFrameworkCore;

namespace Menu.Models
{
  public class MenuContext : DbContext
  {
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<MenuItemSize> MenuItemSize { get; set; }

    public MenuContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}