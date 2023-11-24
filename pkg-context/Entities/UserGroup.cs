namespace pkg_context.Entities;

public sealed class UserGroup : BaseEntity
{
    public UserGroup(int? quantityMaxUser, string description, int number) : base(number)
    {
        ValidadeNumberNull.Validate(quantityMaxUser, "Quantidade de usuários deve ser maior que zero!");
        ValidateStringAndLength.Validate(description, 255, "Informe a descrição!");
        QuantityMaxUser = quantityMaxUser;
        Description = description;
    }

    public int? QuantityMaxUser { get; private set; }
    public string Description { get; private set; }
    public List<PermissionsGroup> PermissionsGroups { get; set; } = new();
}
