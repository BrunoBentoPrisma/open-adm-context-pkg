namespace pkg_context.Entities;

public sealed class Menu
{
    public Menu(bool isPremium)
    {
        Id = Guid.NewGuid();
        IsPremium = isPremium;
        Sidebar = new();
    }
    public Guid Id { get; set; }
    public bool IsPremium { get; set; }
    public List<Sidebar> Sidebar { get; set; }
}
