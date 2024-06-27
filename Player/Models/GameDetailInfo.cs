namespace Player.Models
{
    public class GameDetailInfo
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string VenueName { get; set; }
        public string VenueCity { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLogo { get; set; }
        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamLogo { get; set; }
        public int HomeGoal { get; set; }
        public int AwayGoal { get; set; }
        public string LeagueName { get; set; }
        public string LeagueLogo { get; set; }
        public string Round { get; set; }
    }
}