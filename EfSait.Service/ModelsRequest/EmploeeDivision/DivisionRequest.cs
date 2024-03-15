namespace EfSait.Service.ModelsRequest.EmploeeDivision;

public class DivisionRequest: BaseModelRequest
{
    public int Code { get; set; }
    public string Abbreviation { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public Guid? BossId { get; set; }
}