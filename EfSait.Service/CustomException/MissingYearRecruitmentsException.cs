namespace EfSait.Service.CustomException;

public class MissingYearRecruitmentsException: Exception
{
    public MissingYearRecruitmentsException(string? message) : base(message)
    {
    }
}