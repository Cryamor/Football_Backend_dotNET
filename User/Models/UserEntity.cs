using SqlSugar;
using System;

namespace User.Models
{
    [SugarTable("user")]
    public class UserEntity
    {
        [SugarColumn(ColumnName = "_id", IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Signature { get; set; }

        public int Score { get; set; }

        public int Follow { get; set; }

        public int Fans { get; set; }

        public string Avatar { get; set; }

        public bool Isbanned { get; set; }

        [SugarColumn(ColumnName = "favorite_league")]
        public string FavoriteLeague { get; set; }

        [SugarColumn(ColumnName = "createdate")]
        public DateTime CreateDate { get; set; }
    }
}