namespace EfSait.Service.CustomException;

public class MissingSpecificationException: Exception
{
    public MissingSpecificationException(string? message) : base(message)
    {
    }
}