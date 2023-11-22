namespace pkg_context.Context;

public class OpenAdmContext : DbContext
{
    public OpenAdmContext(DbContextOptions<OpenAdmContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Partner> Partners { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Sidebar> Sidebars { get; set; }
    public DbSet<ChildrensSidebar> ChildrensSidebars { get; set; }
    public DbSet<Permissions> Permissions { get; set; }
}
