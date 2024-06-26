namespace User.Models;

public class UserEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Account { get; set; }
    public string Password { get; set; }
    public string? Signature { get; set; }
    public int Score { get; set; }
    public int Follow { get; set; }
    public int Fans { get; set; }
    public string? Avatar { get; set; }
    public bool Isbanned { get; set; }
    public string? FavoriteLeague { get; set; }
    public bool IsFollowing { get; set; }

    //public UserEntity(long i, string n)
    //{
    //    this.Id = i;
    //    this.Name = n;
    //}
}

