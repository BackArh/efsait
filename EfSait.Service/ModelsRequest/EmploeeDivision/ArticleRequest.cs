
namespace EfSait.Service.ModelsRequest.EmploeeDivision;

public class ArticleRequest: BaseModelRequest
{
    public string Name { get; set; }
    public DateOnly Year { get; set; }
    public List<string>? CoAuthors { get; set; } 
    public bool PrintedOrElectronic { get; set; }
    public bool ScientificOrEducationMethodical { get; set; }
    public int NumberPrintedSheets { get; set; }
    public string LinkOnLibrary { get; set; }
}