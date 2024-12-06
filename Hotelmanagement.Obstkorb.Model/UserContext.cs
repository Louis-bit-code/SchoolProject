namespace Hotelmanagement.Obstkorb.Model;

public class UserContext : BaseEntity
{
    public UserContext(String username)
    {
        Username = username;
    }
    public String Username { get; set; }

}