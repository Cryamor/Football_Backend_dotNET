using System;
namespace Player.Models
{
    public class GameList
    {
        public long Count { get; set; }
        public List<GameSimpleInfo> GameSimpleInfos { get; set; }
    }
}

