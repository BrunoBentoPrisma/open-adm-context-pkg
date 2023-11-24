namespace pkg_context.Factories.Interfaces;

public interface IFactoryBy
{
    Task<ClientContext> CreateDatabase();
}
