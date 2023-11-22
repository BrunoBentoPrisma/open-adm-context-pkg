namespace pkg_context.Entities;

public sealed class Permissions : BaseEntity
{
    public Permissions(string description, int number) : base(number)
    {
        Description = description;
    }

    public string Description { get; private set; }
}
