namespace pkg_context.Entities;

public sealed class Company : BaseEntity
{
    public void UpdateAddress(Guid addressId)
    {
        AddressId = addressId;
    }
    public Company(string razaoSocial, string nameFantasy, string cnpj, string email, string? phone, int number) : base(number)
    {
        RazaoSocial = razaoSocial;
        NameFantasy = nameFantasy;
        Cnpj = cnpj;
        Email = email;
        Phone = phone;
        IsPremium = false;
    }
    public string RazaoSocial { get; private set; }
    public string NameFantasy { get; private set; }
    public string Cnpj { get; private set; }
    public string Email { get; private set; }
    public string? Phone { get; private set; }
    public Guid? AddressId { get; private set; }
    public Address? Address { get; private set; }
    public bool IsPremium { get; private set; }
}
