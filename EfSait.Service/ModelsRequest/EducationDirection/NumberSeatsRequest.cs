using EfSait.Service.ModelsRequest;

namespace EfSait.Entity.EducationDirection;

public class NumberSeatsRequest: BaseModelRequest
{
    public int BudgetPlaces { get; set; }
    public int PaidPlaces { get; set; }
}