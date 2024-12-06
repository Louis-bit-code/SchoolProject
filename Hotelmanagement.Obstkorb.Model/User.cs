namespace Hotelmanagement.Obstkorb.Model
{
    public class User : BaseEntity
    {
        public User(string userName)
        {
            Username = userName;
        }

        public string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string FullName { get; set; }
    }
}