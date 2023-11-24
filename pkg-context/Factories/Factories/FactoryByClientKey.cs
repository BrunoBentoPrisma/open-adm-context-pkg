using pkg_context.Factories.Interfaces;

namespace pkg_context.Factories.Factories;

public class FactoryByClientKey : IFactoryBy
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPartnerRepository _partnerRepository;

    public FactoryByClientKey(
        IHttpContextAccessor httpContextAccessor,
        IPartnerRepository partnerRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _partnerRepository = partnerRepository;
    }
    public async Task<ClientContext> CreateDatabase()
    {
        var key = _httpContextAccessor?.HttpContext?.Request.Headers["clientKey"].ToString()
            ?? throw new Exception("Erro ao recuperar clientKey da requisição,para criar o context do cliente!");

        if (!Guid.TryParse(key, out Guid clientKey)) throw new Exception("clientKey inválida para criação do context do cliente!");

        var partner = await _partnerRepository.GetPartnerByClientKeyAsync(clientKey)
            ?? throw new Exception($"Erro ao lozalizar a empresa com clientKey : {clientKey}, para criar context do cliente!");

        return ContextClientFactory.CreateContextClient(partner.Db);
    }
}
