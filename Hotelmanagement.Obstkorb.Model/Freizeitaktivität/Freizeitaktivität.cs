namespace Hotelmanagement.Obstkorb.Model.Freizeitaktivität;

public class Freizeitaktivität 
{
    public Freizeitaktivität( string name, string beschreibung, string preis)
    {
        Name = name;
        Beschreibung = beschreibung;
        Preis = preis;
    }

    public string Name { get; set; }

    public string Beschreibung { get; set; }

    public string Preis { get; set; }
}