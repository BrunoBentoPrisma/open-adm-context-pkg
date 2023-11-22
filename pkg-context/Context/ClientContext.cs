namespace pkg_context.Context;

public class ClientContext : DbContext
{
    public ClientContext(DbContextOptions<ClientContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<PermissionsGroup> PermissionsGroups { get; set; }
}
