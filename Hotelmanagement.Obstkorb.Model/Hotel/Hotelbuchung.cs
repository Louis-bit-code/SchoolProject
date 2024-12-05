﻿namespace Hotelmanagement.Obstkorb.Model.Hotel;

public class Hotelbuchung : BaseEntity
{
    public int Buchungsnummer { get; set; }

    public Preis Preis { get; set; }

    public DateTime Von { get; set; }

    public DateTime Bis { get; set; }
}