using System;
namespace Player.Models
{
    public class TeamSimpleInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Logo { get; set; }
        public string Founded { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string VenueCity { get; set; }
        public string VenueImage { get; set; }
        public int VenueCapacity { get; set; }
    }
}

