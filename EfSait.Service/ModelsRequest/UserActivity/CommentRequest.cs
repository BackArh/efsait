
namespace EfSait.Service.ModelsRequest.UserActivity;

public class CommentRequest: BaseModelRequest
{
    public Guid? ParentId { get; set; }
    public string Text { get; set; }
    public DateTime DateTime { get; set; }
    public Guid UserId { get; set; }
    public Guid PageId { get; set; }
}