namespace pkg_context.Repositories.Cached;

public class CachedPartner : IPartnerRepository
{
    private readonly PartnerRepository _partnerRepository;
    private readonly ICachedService<Partner> _cachedService;

    public CachedPartner(PartnerRepository partnerRepository, ICachedService<Partner> cachedService)
    {
        _partnerRepository = partnerRepository;
        _cachedService = cachedService;
    }

    public async Task<Partner?> GetPartnerByClientKeyAsync(Guid clientKey)
    {
        var key = clientKey.ToString();
        var partner = await _cachedService.GetItemAsync(key);

        if (partner is null)
        {
            partner = await _partnerRepository.GetPartnerByClientKeyAsync(clientKey);
            if (partner is not null)
            {
                await _cachedService.SetItemAsync(key, partner);
                return partner;
            }
        }

        return partner;
    }

    public async Task<Partner?> GetPartnerByUrlAsync(string url)
    {
        var partner = await _cachedService.GetItemAsync(url);

        if (partner is null)
        {
            partner = await _partnerRepository.GetPartnerByUrlAsync(url);
            if (partner is not null)
            {
                await _cachedService.SetItemAsync(url, partner);
                return partner;
            }
        }

        return partner;
    }
}
