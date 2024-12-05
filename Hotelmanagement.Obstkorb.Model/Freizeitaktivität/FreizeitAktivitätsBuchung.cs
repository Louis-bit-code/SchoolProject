namespace Hotelmanagement.Obstkorb.Model.Freizeitaktivität;

public class FreizeitAktivitätsBuchung
{
    public int Buchungsnummer { get; set; }

    public Kunde Kundennummer { get; set; }

    public DateTime Von { get; set; }

    public DateTime Bis { get; set; }

    public Freizeitaktivität Aktivität { get; set; }
}