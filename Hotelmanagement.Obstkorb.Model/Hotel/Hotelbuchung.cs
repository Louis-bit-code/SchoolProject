namespace Hotelmanagement.Obstkorb.Model.Hotel;

public class Hotelbuchung : User
{

    public Preis Preis { get; set; }

    public DateTime Von { get; set; }

    public DateTime Bis { get; set; }

    public Boolean Gebucht { get; set; }

    public String UserBuchung { get; set; }
}