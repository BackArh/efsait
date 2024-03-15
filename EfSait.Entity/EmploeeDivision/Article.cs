namespace EfSait.Entity.EmploeeDivision;

public class Article : BaseModel
{
    protected Article()
    {
    }

    public string Name { get; set; }
    public DateOnly Year { get; set; }
    public List<string>? CoAuthors { get; set; } 
    public bool PrintedOrElectronic { get; set; }
    public bool ScientificOrEducationMethodical { get; set; }
    public int NumberPrintedSheets { get; set; }
    public string LinkOnLibrary { get; set; }
    public Employee Employee { get; set; }

    public Article(string name, DateOnly year,
        List<string>? coAuthors, bool printedOrElectronic, bool scientificOrEducationMethodical,
        int numberPrintedSheets, string linkOnLibrary, Employee employee)

    {
        Name = name;
        Year = year;
        CoAuthors = new List<string>();
        if (coAuthors != null) CoAuthors.AddRange(coAuthors);
        PrintedOrElectronic = printedOrElectronic;
        ScientificOrEducationMethodical = scientificOrEducationMethodical;
        NumberPrintedSheets = numberPrintedSheets;
        LinkOnLibrary = linkOnLibrary;
        Employee = employee;
    }
}