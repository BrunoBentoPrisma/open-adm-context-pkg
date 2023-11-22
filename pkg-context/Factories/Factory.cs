using Microsoft.EntityFrameworkCore.Internal;

namespace pkg_context.Factories;

public class Factory : IFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPartnerRepository _partnerRepository;

    public Factory(
        IHttpContextAccessor httpContextAccessor,
        IPartnerRepository partnerRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _partnerRepository = partnerRepository;
    }

    public async Task<ClientContext> CreateDatabaseByPathAsync()
    {
        var url = _httpContextAccessor?.HttpContext?.Request.Headers["Referer"].ToString()
            ?? throw new Exception("Erro ao recuperar path base da requisição, para criar o context do cliente!");

        var partner = await _partnerRepository.GetPartnerByUrlAsync(url)
            ?? throw new Exception($"Erro ao localizar a empresa com a URL : {url}, para criar o context do cliente!");

        return ContextFactory.CreateContextClient(partner.Db);
    }

    public async Task<ClientContext> CreateDatabaseByClientKeyAsync()
    {
        var key = _httpContextAccessor?.HttpContext?.Request.Headers["clientKey"].ToString()
            ?? throw new Exception("Erro ao recuperar clientKey da requisição,para criar o context do cliente!");

        if (!Guid.TryParse(key, out Guid clientKey)) throw new Exception("clientKey inválida para criação do context do cliente!");

        var partner = await _partnerRepository.GetPartnerByClientKeyAsync(clientKey)
            ?? throw new Exception($"Erro ao lozalizar a empresa com clientKey : {clientKey}, para criar context do cliente!");

        return ContextFactory.CreateContextClient(partner.Db);
    }
}
