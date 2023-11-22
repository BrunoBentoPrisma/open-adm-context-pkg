namespace pkg_context.Entities;

public sealed class User : BaseEntity
{
    [JsonConstructor]
    public User(string email, string password, string name, bool isAdmin, bool verifiedEmail, byte[]? avatar, Guid? userGroupId, int number) : base(number)
    {
        ValidateStringAndLength.Validate(name, 255, "Nome inválido!");
        ValidateEmailAndLength.Validate(email, 255, "Email inválido!");
        ValidateStringAndLength.Validate(password, 255, "Senha inválida!");
        ValidateBool.Validate(isAdmin, "É obrigatório informar se o usuário é admin!");
        ValidateNumberZero.Validate(number, "Número inválido!");

        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Name = name;
        IsAdmin = isAdmin;
        VerifiedEmail = verifiedEmail;
        Avatar = avatar;
        UserGroupId = userGroupId;
    }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public bool IsAdmin { get; private set; }
    public bool VerifiedEmail { get; private set; }
    public byte[]? Avatar { get; private set; }
    public Guid? UserGroupId { get; private set; }
    public UserGroup? UserGroup { get; set; }

    public void SetPasswordHash(string? newPassword = "")
    {
        Password = CryptographyPassword.Hash(string.IsNullOrWhiteSpace(newPassword) ? Password : newPassword);
    }

    public void ConfirmedEmail()
    {
        VerifiedEmail = true;
    }
}
