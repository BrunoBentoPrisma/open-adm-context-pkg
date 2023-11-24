using pkg_context.Factories.Interfaces;

namespace pkg_context.Factories.Factories;

public class Factory : IFactoryContext
{
    private readonly IDictionary<string, IFactoryBy> _factoryBy;

    public Factory(FactoryByClientKey factoryByClientKey, FactoryByPath factoryByPath)
    {
        _factoryBy = new Dictionary<string, IFactoryBy>()
        {
            { "clientKey", factoryByClientKey },
            { "path", factoryByPath }
        };
    }

    public async Task<ClientContext> GetContextAsync(string key)
    {
        _factoryBy.TryGetValue(key, out var context);
        if(context == null) throw new ArgumentNullException(nameof(key));
        return await context.CreateDatabase();
    }
}
