using ExpectedObjects;

namespace Test.Test.Entities;

public class UserGroupTest
{
    [Fact]
    public void DeveCriarUserGroup()
    {
        var dto = new
        {
            QuantityMaxUser = 1,
            Description = "Criação de user group Ok",
            Number = 1
        };

        var userGroup = new UserGroup(dto.QuantityMaxUser, dto.Description, dto.Number);

        dto.ToExpectedObject().ShouldMatch(userGroup);

    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarUserGroupSemDescricao(string description)
    {
        Assert.Throws<ArgumentException>(() => UserGroupBuilder.Init().SemDescription(description).Build());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    public void NaoDeveCriarUserGroupSemNumero(int number)
    {
        Assert.Throws<ArgumentException>(() => UserGroupBuilder.Init().SemNumero(number).Build());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-6)]
    public void NaoDeveCriarUserGroupComMaxUserInvalido(int? maxUser)
    {
        Assert.Throws<ArgumentException>(() => UserGroupBuilder.Init().SemMaxUser(maxUser).Build());
    }
}
