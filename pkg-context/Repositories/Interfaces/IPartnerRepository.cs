namespace pkg_context.Repositories.Interfaces;


public interface IPartnerRepository
{
    Task<Partner?> GetPartnerByUrlAsync(string url);
    Task<Partner?> GetPartnerByClientKeyAsync(Guid clientKey);
}

