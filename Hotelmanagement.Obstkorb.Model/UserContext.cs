namespace Hotelmanagement.Obstkorb.Model
{
    public class UserContext
    {
        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public void SetCurrentUser(User? user)
        {
            CurrentUser = user;
        }

        public void ClearUser()
        {
            CurrentUser = null;
        }
    }

}