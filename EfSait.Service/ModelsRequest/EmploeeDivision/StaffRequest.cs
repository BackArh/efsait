namespace EfSait.Service.ModelsRequest.EmploeeDivision;

public class StaffRequest: BaseModelRequest
{
    public Guid DivisionId { get; set; }
    public Guid EmployeeId { get; set; }
}