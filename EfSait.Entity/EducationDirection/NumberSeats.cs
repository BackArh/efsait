namespace EfSait.Entity.EducationDirection;

public class NumberSeats : BaseModel
{
    public NumberSeats(int budgetPlaces, int paidPlaces, YearRecruitment yearRecruitment)
    {
        BudgetPlaces = budgetPlaces;
        PaidPlaces = paidPlaces;
        YearRecruitment = yearRecruitment;
    }

    protected NumberSeats()
    {
    }

    public int BudgetPlaces { get; set; }
    public int PaidPlaces { get; set; }
    public YearRecruitment YearRecruitment { get; set; }
}