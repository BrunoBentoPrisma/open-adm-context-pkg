namespace pkg_context.Entities;

public sealed class Partner : BaseEntity
{
    public void UpdateAddress(Guid addressId)
    {
        AddressId = addressId;
    }

    public void UpdateUrl(string url)
    {
        Url = url;
    }
    [JsonConstructor]
    public Partner(string razaoSocial, string nameFantasy, string cnpj, string email, string? phone, string url, byte[] db, Guid? addressId, Guid clientKey, bool isPremium, int number) : base(number)
    {
        RazaoSocial = razaoSocial;
        NameFantasy = nameFantasy;
        Cnpj = cnpj;
        Email = email;
        Phone = phone;
        Db = db ?? throw new ArgumentNullException(nameof(db));
        AddressId = addressId;
        ClientKey = clientKey;
        IsPremium = isPremium;
        Url = url;
    }

    public Partner(string razaoSocial, string nameFantasy, string cnpj, string email, string db, string? phone, int number) : base(number)
    {
        RazaoSocial = razaoSocial;
        NameFantasy = nameFantasy;
        Cnpj = cnpj;
        Email = email;
        Phone = phone;
        Db = CryptographyDb.EncryptByte(db);
        Url = string.Empty;
        ClientKey = Guid.NewGuid();
        IsPremium = false;
    }
    public string RazaoSocial { get; private set; }
    public string NameFantasy { get; private set; }
    public string Cnpj { get; private set; }
    public string Email { get; private set; }
    public string? Phone { get; private set; }
    public string Url { get; private set; }
    public byte[] Db { get; private set; }
    public Guid? AddressId { get; private set; }
    public Address? Address { get; private set; }
    public Guid ClientKey { get; private set; }
    public bool IsPremium { get; private set; }
}
