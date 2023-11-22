namespace pkg_context.Entities;

public sealed class ChildrensSidebar
{
    public ChildrensSidebar(string route, string title, string? icon, int order)
    {
        Id = Guid.NewGuid();
        Route = route;
        Title = title;
        Icon = icon;
        Order = order;
    }
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string Route { get; set; }
    [MaxLength(255)]
    public string Title { get; set; }
    [MaxLength(255)]
    public string? Icon { get; set; }
    public int Order { get; set; }
}
