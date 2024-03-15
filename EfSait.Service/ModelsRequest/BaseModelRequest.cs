namespace EfSait.Service.ModelsRequest;

public abstract class BaseModelRequest
{
    public BaseModelRequest()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}