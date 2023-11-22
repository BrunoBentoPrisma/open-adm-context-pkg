namespace pkg_context.Repositories.Repository;

public class PartnerRepository : IPartnerRepository
{
    private readonly OpenAdmContext _openAdmContext;

    public PartnerRepository(OpenAdmContext openAdmContext)
    {
        _openAdmContext = openAdmContext;
    }

    public async Task<Partner?> GetPartnerByClientKeyAsync(Guid clientKey) =>
       await _openAdmContext.Partners.FirstOrDefaultAsync(x => x.ClientKey == clientKey);

    public async Task<Partner?> GetPartnerByUrlAsync(string url) =>
         await _openAdmContext.Partners.FirstOrDefaultAsync(x => x.Url == url);

}
