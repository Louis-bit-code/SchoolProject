namespace Hotelmanagement.Obstkorb.Model.Hotel;

public class Hotelbuchung : BaseEntity
{

    public Preis Preis { get; set; }

    public DateTime Von { get; set; }

    public DateTime Bis { get; set; }
}