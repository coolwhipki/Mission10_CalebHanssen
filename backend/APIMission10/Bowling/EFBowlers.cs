using System.Linq;

namespace APIMission10.Bowling
{
    public class EFBowlers : IBowlerRepository
    {
        private BowlerContext _bowlercontext;

        public EFBowlers(BowlerContext temp)
        {
            _bowlercontext = temp;
        }

        public IEnumerable<Bowler> Bowlers => _bowlercontext.Bowlers;
        public IEnumerable<Team> Teams => _bowlercontext.Teams;

        // Adjusted to return IEnumerable<object>
        public IEnumerable<object> GetBowlerTeams()
        {
            var joinedData = from bowler in _bowlercontext.Bowlers
                             join team in _bowlercontext.Teams on bowler.TeamID equals team.TeamID
                             where team.TeamName == "Marlins" || team.TeamName == "Sharks"
                             select new // Anonymous object
                             {
                                 BowlerID = bowler.BowlerID,
                                 BowlerName = $"{bowler.BowlerFirstName} {(bowler.BowlerMiddleInit ?? "")} {bowler.BowlerLastName}",
                                 TeamName = team.TeamName,
                                 Address = bowler.BowlerAddress ?? "No address provided",
                                 City = bowler.BowlerCity ?? "No city provided",
                                 State = bowler.BowlerState ?? "No state provided",
                                 Zip = bowler.BowlerZip ?? "No ZIP provided",
                                 PhoneNumber = bowler.BowlerPhoneNumber ?? "No phone number provided"
                             };
            return joinedData.ToList();
        }




    }
}

