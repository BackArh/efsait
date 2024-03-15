
namespace EfSait.Service.ModelsRequest.UserActivity;

public class PageRequest: BaseModelRequest
{
    public string Text { get; set; }
    public string Header { get; set; }
    public string PathImage { get; set; }
    public List<MaterialRequest> Materials { get; set; }
}