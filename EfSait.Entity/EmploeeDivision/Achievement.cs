namespace EfSait.Entity.EmploeeDivision;

public class Achievement : BaseModel
{
    public string Name { get; set; }
    public DateOnly Year { get; set; }
    public Employee Employee { get; set; }

    public Achievement(string name, DateOnly year, Employee employee)
    {
        Name = name;
        Year = year;
        Employee = employee;
    }
    protected Achievement()
    {
    }
}