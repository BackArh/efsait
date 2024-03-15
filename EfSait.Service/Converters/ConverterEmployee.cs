using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.Enum;
using EfSait.Service.ModelsRequest.EmploeeDivision;

namespace EfSait.Service.Converters;

public static class ConverterEmployee
{
    public static Employee ConverterEmployeeRequest(EmployeeRequest employee)
    {
        var employeeDb = new Employee(employee.Name,
            employee.Surname,
            employee.Patronymic,
            (PostEnum) Enum.Parse(typeof(PostEnum),
                employee.Post, true),
            employee.Phone,
            employee.Email,
            (RankEnum) Enum.Parse(typeof(RankEnum),
                employee.Rank, true), null, null
        );
        var articlesDb = ConverterArticles(employee.Articles, employeeDb);
        var achievementsDb = ConverterAchievements(employee.Achievements, employeeDb);
        employeeDb.Articles = articlesDb;
        employeeDb.Achievements = achievementsDb;
        return employeeDb;
    }

    private static List<Article> ConverterArticles(List<ArticleRequest> list, Employee employee)
    {
        var listArticleDb = new List<Article>();
        foreach (var articleRequest in list)
        {
            var articleDb = new Article(articleRequest.Name,
                articleRequest.Year,
                articleRequest.CoAuthors,
                articleRequest.PrintedOrElectronic,
                articleRequest.ScientificOrEducationMethodical,
                articleRequest.NumberPrintedSheets,
                articleRequest.LinkOnLibrary, employee);
            listArticleDb.Add(articleDb);
        }

        return listArticleDb;
    }

    private static List<Achievement> ConverterAchievements(List<AchievementRequest> list, Employee employee)
    {
        var listAchievementDb = new List<Achievement>();
        foreach (var achievementRequest in list)
        {
            var achievementDb = new Achievement(achievementRequest.Name,
                achievementRequest.Year,
                employee);
            listAchievementDb.Add(achievementDb);
        }

        return listAchievementDb;
    }
}