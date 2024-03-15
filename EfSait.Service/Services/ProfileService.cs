using EfSait.Entity.EducationDirection;
using EfSait.Service.Converters;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileProvider _profileProvider;
    private readonly IDirectionProvider _directionProvider;
    private readonly IDivisionProvider _divisionProvider;

    public ProfileService(IProfileProvider profileProvider, IDirectionProvider directionProvider,
        IDivisionProvider divisionProvider)
    {
        _profileProvider = profileProvider;
        _directionProvider = directionProvider;
        _divisionProvider = divisionProvider;
    }

    public async Task<Guid> CreateAsync(ProfileRequest profile, CancellationToken cancellationToken)
    {
        if (await _profileProvider.FindAsync(profile.Code, cancellationToken) != null)
            throw new ExistIsEntityException("Такой профиль существует");
        if (profile.DirectionId == null)
            throw new MissingDirectionException("Не указанно направление");
        if (profile.SpecificationsList.Count < 1)
            throw new MissingSpecificationException("Полностью отсутствуют спецификации");
        if (profile.YearRecruitments.Count < 1)
            throw new MissingYearRecruitmentsException("Не указанны года набора");
        var direction = await _directionProvider.FindAsync(profile.DirectionId, cancellationToken);
        if (direction == null)
            throw new MissingDirectionException("Такого направления не существует");

        var profileDb = ConverterProfile.ConverterProfileRequest(profile, direction);
        await _profileProvider.AddAsync(profileDb, cancellationToken);
        return profile.Id;
    }

    public async Task<Profile?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var profile = await _profileProvider.FindAsync(id, cancellationToken);
        if (profile == null)
            throw new NotExistException("Такого профиля не существует");
        return profile;
    }

    public async Task<Profile> GetAsync(string code, CancellationToken cancellationToken)
    {
        var profile = await _profileProvider.FindAsync(code, cancellationToken);
        if (profile == null)
            throw new NotExistException("Такого профиля не существует");
        return profile;
    }

    public async Task<Profile?> GetByDirectionAsync(Guid id, CancellationToken cancellationToken)
    {
        var profile = await _profileProvider.FindAsync(id, cancellationToken);
        if (profile == null)
            throw new NotExistException("Такого подразделения не существует");
        return profile;
    }

    public async Task<List<Profile>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _profileProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<Profile> UpdateAsync(ProfileRequest profile, CancellationToken cancellationToken)
    {
        var profileDb = await GetAsync(profile.Code, cancellationToken);


        var direction = await _directionProvider.FindAsync(profile.DirectionId, cancellationToken);
        if (direction == null)
            throw new MissingDirectionException("Такого направления не существует");


        var profileCurrent = ConverterProfile.ConverterProfileRequest(profile, direction);
        profileDb.Code = profileCurrent.Code;
        profileDb.Description = profileCurrent.Description;
        profileDb.Direction = profileCurrent.Direction;
        profileDb.Name = profileCurrent.Name;
        profileDb.SpecificationsList.AddRange(profileCurrent.SpecificationsList);
        profileDb.YearRecruitments.AddRange(profileCurrent.YearRecruitments);
        profileDb.UpdateChange = DateTime.Now;
        await _profileProvider.UpdateAsync(profileDb, cancellationToken);
        return profileDb;
    }
}