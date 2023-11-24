namespace pkg_context.Factories.Interfaces;

public interface IFactoryContext
{
    Task<ClientContext> GetContextAsync(string key);
}
