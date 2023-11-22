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
        _number = faker.Random.Int(min: 1);
    }

    public static UserGroupBuilder Init() => new ();

    public UserGroupBuilder SemDescription(string description)
    {
        _description = description;
        return this;
    }

    public UserGroup Build() => new(_maxUser, _description, _number);
    
}
