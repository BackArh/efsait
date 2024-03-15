namespace EfSait.Service.Services.Interface.Providers;

public interface IRelationProvider
{
    Task AttachAsync(Guid idFirstEntity, Guid idSecondEntity, CancellationToken cancellationToken);
}