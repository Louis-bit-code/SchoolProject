namespace Hotelmanagement.Obstkorb.Model.Freizeitaktivität;

public class Freizeitaktivität : User
{
    public Freizeitaktivität(string username, string name, string beschreibung, string preis) : base(username)
    {
        Name = name;
        Beschreibung = beschreibung;
        Preis = preis;
    }

    public string Name { get; set; }

    public string Beschreibung { get; set; }

    public string Preis { get; set; }
}