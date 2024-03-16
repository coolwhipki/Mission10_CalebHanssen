namespace APIMission10.Bowling
{
    public interface IBowlerRepository
    {
        IEnumerable<Bowler> Bowlers { get; }
        IEnumerable<Team> Teams { get; }
        IEnumerable<object> GetBowlerTeams();
    }
}
