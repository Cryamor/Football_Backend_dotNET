using System.Collections.Generic;

namespace Player.Models
{
    public class PlayerDetailInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }
        public string Birth { get; set; }
        public List<SeasonInfo> SeasonInfos { get; set; }

        public class SeasonInfo
        {
            public string SeasonNum { get; set; }
            public string TeamName { get; set; }
            public string TeamLogo { get; set; }
            public string LeagueName { get; set; }
            public string LeagueLogo { get; set; }
            public string Position { get; set; }
            public int Goals { get; set; }
            public int Assists { get; set; }
            public int Passes { get; set; }
            public int Tackles { get; set; }
            public int Yellow { get; set; }
            public int Red { get; set; }
        }
    }
}