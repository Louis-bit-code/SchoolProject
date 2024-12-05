namespace Hotelmanagement.Obstkorb.Model.Hotel;

public class Hotelzimmer : BaseEntity
{
    public int Betten { get; set; }

    public double Größe { get; set; }

    public int Zimmernummer { get; set; }
}