namespace pkg_context.Entities;

public sealed class Sidebar
{
    public Sidebar(string? route, string title, string? icon, int order)
    {
        Id = Guid.NewGuid();
        Route = route;
        Title = title;
        Icon = icon;
        Order = order;
        Childrens = new();
    }
    public Guid Id { get; set; }
    public string? Route { get; set; }
    public string Title { get; set; }
    public string? Icon { get; set; }
    public int Order { get; set; }
    public List<ChildrensSidebar> Childrens { get; set; }
}
