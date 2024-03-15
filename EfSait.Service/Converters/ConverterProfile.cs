using EfSait.Entity.EducationDirection;
using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.Enum;
using EfSait.Service.ModelsRequest.EducationDirection;

namespace EfSait.Service.Converters;

public class ConverterProfile
{
    public static Profile ConverterProfileRequest(ProfileRequest profileRequest, Direction direction)
    {
        var listSpecification = new List<Specifications>();
        var listYearRecruitments = new List<YearRecruitment>();
        var profileDb = new Profile(profileRequest.Name,
            profileRequest.Code,
            profileRequest.Description,
            listSpecification,
            listYearRecruitments,
            direction);
        profileDb.SpecificationsList.AddRange(ConverterSpecification(profileRequest.SpecificationsList, profileDb));
        profileDb.YearRecruitments.AddRange(ConverterYearRecruitments(profileRequest.YearRecruitments, profileDb));
        return profileDb;
    }

    private static List<Specifications> ConverterSpecification(List<SpecificationsRequest> list, Profile profile)
    {
        var listSpecificationDb = new List<Specifications>();
        foreach (var specificationsRequest in list)
        {
            var specificationsDb = new Specifications(
                (FormEducationEnum) Enum.Parse(typeof(FormEducationEnum),
                    specificationsRequest.FormEducation, true),
                (LevelEducationEnum) Enum.Parse(typeof(LevelEducationEnum),
                    specificationsRequest.LevelEducation, true),
                specificationsRequest.Price,
                specificationsRequest.PeriodEducation,
                (LanguageEducationEnum) Enum.Parse(typeof(LanguageEducationEnum),
                    specificationsRequest.LanguageEducation, true),
                profile
            );
            listSpecificationDb.Add(specificationsDb);
        }

        return listSpecificationDb;
    }

    private static List<YearRecruitment> ConverterYearRecruitments(List<YearRecruitmentRequest> list, Profile profile)
    {
        var listYearRecruitmentsDb = new List<YearRecruitment>();
        foreach (var yearRecruitmentRequest in list)
        {
            var yearRecruitmentDb = new YearRecruitment(new List<NumberSeats>(),
                yearRecruitmentRequest.Year,
                new List<Profile>(){profile});
            yearRecruitmentDb.NumberSeatsList =
                ConverterNumberSeats(yearRecruitmentRequest.NumberSeatsList, yearRecruitmentDb);
            listYearRecruitmentsDb.Add(yearRecruitmentDb);
        }

        return listYearRecruitmentsDb;
    }
    private static List<NumberSeats> ConverterNumberSeats(List<NumberSeatsRequest> list, YearRecruitment yearRecruitment)
    {
        var listNumberSeatsDb = new List<NumberSeats>();
        foreach (var numberSeatsRequest in list)
        {
            var numberSeatsDb = new NumberSeats(numberSeatsRequest.BudgetPlaces,
                numberSeatsRequest.PaidPlaces,
                yearRecruitment);
            listNumberSeatsDb.Add(numberSeatsDb);
        }

        return listNumberSeatsDb;
    }
}