using pkg_context.Factories.Interfaces;

namespace pkg_context.Factories.Factories;

public class FactoryByPath : IFactoryBy
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPartnerRepository _partnerRepository;

    public FactoryByPath(
        IHttpContextAccessor httpContextAccessor,
        IPartnerRepository partnerRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _partnerRepository = partnerRepository;
    }
    public async Task<ClientContext> CreateDatabase()
    {
        var url = _httpContextAccessor?.HttpContext?.Request.Headers["Referer"].ToString()
            ?? throw new Exception("Erro ao recuperar path base da requisição, para criar o context do cliente!");

        var partner = await _partnerRepository.GetPartnerByUrlAsync(url)
            ?? throw new Exception($"Erro ao localizar a empresa com a URL : {url}, para criar o context do cliente!");

        return ContextClientFactory.CreateContextClient(partner.Db);
    }
}
