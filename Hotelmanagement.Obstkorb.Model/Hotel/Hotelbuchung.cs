namespace Hotelmanagement.Obstkorb.Model.Hotel;

public class Hotelbuchung : User
{
    public Hotelbuchung(string userName, Preis preis, DateTime von, DateTime bis, bool gebucht, string userBuchung) : base(userName)
    {
        Preis = preis;
        Von = von;
        Bis = bis;
        Gebucht = gebucht;
        UserBuchung = userBuchung;
    }

    public Preis Preis { get; set; }

    public DateTime Von { get; set; }

    public DateTime Bis { get; set; }

    public Boolean Gebucht { get; set; }

    public String UserBuchung { get; set; }
}