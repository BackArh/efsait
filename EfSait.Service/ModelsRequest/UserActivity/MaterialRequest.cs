
namespace EfSait.Service.ModelsRequest.UserActivity;

public class MaterialRequest: BaseModelRequest
{
    public string PathToFile { get; set; }
    public string TypeFile { get; set; }
    public Guid PageId { get; set; }
}