using EfSait.Entity.EducationDirection;
using EfSait.Service.Services.Interface;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class ProfileProvider : IProfileProvider
{
    private readonly ApplicationContext _applicationContext;

    public ProfileProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Profile?> FindAsync(string code, CancellationToken cancellationToken)
    {
        var direction = await _applicationContext.Profiles
            .Include(d => d.Direction)
            .Include(d => d.YearRecruitments)
            .Include(p => p.SpecificationsList)
            .FirstOrDefaultAsync(d => d.Code == code, cancellationToken: cancellationToken).ConfigureAwait(false);
        return direction;
    }

    public async Task<Profile?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var direction = await _applicationContext.Profiles
            .Include(d => d.Direction)
            .Include(d => d.YearRecruitments)
                .ThenInclude(y => y.NumberSeatsList)
            .Include(d=> d.YearRecruitments)
                .ThenInclude(y => y.YearRecruitment_Disciplines)
                    .ThenInclude(ye => ye.Discipline)
            .Include(p => p.SpecificationsList)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
        return direction;
    }

    public async Task<List<Profile>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Profiles
            .Include(d => d.Direction)
            .Include(d => d.YearRecruitments)
            .Include(d => d.SpecificationsList)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Profile?> GetByDirectionAsync(Guid id, CancellationToken cancellationToken)
    {
        var profile = await _applicationContext.Profiles
            .Include(d => d.Direction)
            .Include(d => d.YearRecruitments)
            .Include(p => p.SpecificationsList)
            .FirstOrDefaultAsync(d => d.Direction.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
        return profile;
    }

    public async Task<Guid> AddAsync(Profile profile, CancellationToken cancellationToken)
    {
        _applicationContext.Add(profile);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return profile.Id;
    }

    public async Task DeleteAsync(string name, CancellationToken cancellationToken)
    {
        var direction = await FindAsync(name, cancellationToken);
        ArgumentNullException.ThrowIfNull(direction);
        _applicationContext.Remove(direction);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Profile> UpdateAsync(Profile profile, CancellationToken cancellationToken)
    {
        _applicationContext.Update(profile);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return profile;
    }
}