namespace Test.Test.Entities;

public class UserGroupTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarUserGroupSemDescricao(string description)
    {
        Assert.Throws<ArgumentException>(() => UserGroupBuilder.Init().SemDescription(description).Build());
    }
}
