namespace B_Analysis_BackEnd.Models;

public class Player
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SavesCount { get; set; }
    public int ShootsCount { get; set; }
    public int GoalsCount { get; set; }
    public int ShootMaxSpeed { get; set; }
    public string PhotoUrl { get; set; }
    public DateTime MatchLastDate { get; set; }
}