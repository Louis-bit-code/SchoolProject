namespace Hotelmanagement.Obstkorb.Model.Hotel;

public class Preis : BaseEntity
{

    public Hotelzimmer Zimmernummer { get; set; }

    public DateTime Von { get; set; }

    public DateTime Bis { get; set; }

    public string Price { get; set; }
}