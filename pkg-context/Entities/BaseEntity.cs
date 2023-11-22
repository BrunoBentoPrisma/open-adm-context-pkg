namespace pkg_context.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(int number)
    {
        Number = number;
        Created_at = DateTime.Now;
        Update_at = DateTime.Now;
        Active = true;
    }

    public Guid Id { get; protected set; }
    public DateTime Created_at { get; protected set; }
    public DateTime Update_at { get; protected set; }
    public bool Active { get; protected set; }
    public int Number { get; protected set; }
}