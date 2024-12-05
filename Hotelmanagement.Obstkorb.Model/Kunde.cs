namespace Hotelmanagement.Obstkorb.Model;

public class Kunde : BaseEntity
{
    public Int32 KundenNummer { get; set; }

    public String Name { get; set; }

    public String Vorname { get; set; }

    public DateOnly Geburtsdatum { get; set; }

    public String Adresse { get; set; }

    public String Bankverbindung { get; set; }

    public String Kreditkartennummer { get; set; }
}