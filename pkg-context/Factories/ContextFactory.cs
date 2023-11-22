namespace pkg_context.Factories;

public static class ContextFactory
{
    public static ClientContext CreateContextClient(byte[] stringConnectionByte)
    {
        var stringConnection = CryptographyDb.DecryptString(stringConnectionByte);

        if (string.IsNullOrWhiteSpace(stringConnection))
            throw new Exception("String de conexão inválida para criação do contexto do cliente!");

        var optionsBuilderClient = new DbContextOptionsBuilder<ClientContext>();

        optionsBuilderClient.UseNpgsql(stringConnection,
            b => b.MigrationsAssembly(typeof(ClientContext).Assembly.FullName));

        return new ClientContext(optionsBuilderClient.Options);
    }
}
