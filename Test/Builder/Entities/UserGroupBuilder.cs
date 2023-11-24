namespace Test.Builder.Entities;

public class UserGroupBuilder
{
    private int? _maxUser;
    private int _number;
    private string _description;

    public UserGroupBuilder()
    {
        var faker = new Faker();
        _maxUser = faker.Random.Int(min: 1);
        _description = "First group";
        _number = faker.Random.Int(min: 2);
    }

    public static UserGroupBuilder Init() => new ();
    public static UserGroup DeveCriarUserGroup(int maxUser, string description, int number)
    {
        return new(maxUser, description, number);
    }

    public UserGroupBuilder SemDescription(string description)
    {
        _description = description;
        return this;
    }

    public UserGroupBuilder SemNumero(int number)
    {
        _number = number;
        return this;
    }

    public UserGroupBuilder SemMaxUser(int? maxUser)
    {
        _maxUser = maxUser;
        return this;
    }

    public UserGroup Build() => new(_maxUser, _description, _number);
    
}
