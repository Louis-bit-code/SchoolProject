using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.Obstkorb.DatabaseInterface
{
    public class BuchungStore
    {
        private readonly string _connectionString;

        public BuchungStore(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<dynamic> GetBuchungen()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string query = @"SELECT b.Buchungsnummer, k.Name AS KundeName, z.Zimmernummer, p.Preis_in_Euro, b.Von, b.Bis
                                      FROM Hotel_Buchung b
                                      JOIN Kunde k ON b.Kundennummer = k.ID
                                      JOIN Preis p ON b.Preis_ID = p.ID
                                      JOIN Buchung_Hotelzimmer bh ON b.ID = bh.Buchungsnummer
                                      JOIN Hotelzimmer z ON bh.Zimmernummer = z.Zimmernummer";
                return db.Query(query).ToList();
            }
        }

        public void AddBuchung(Guid kundennummer, Guid preisId, DateTime von, DateTime bis, int zimmernummer)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                using var transaction = db.BeginTransaction();

                try
                {
                    // Insert Buchung
                    const string insertBuchungQuery = @"INSERT INTO Hotel_Buchung (ID, Buchungsnummer, Kundennummer, Preis_ID, Von, Bis) 
                                                        VALUES (NEWID(), (SELECT ISNULL(MAX(Buchungsnummer), 0) + 1 FROM Hotel_Buchung), @Kundennummer, @PreisId, @Von, @Bis);";
                    db.Execute(insertBuchungQuery, new { Kundennummer = kundennummer, PreisId = preisId, Von = von, Bis = bis }, transaction);

                    // Get Last Inserted Buchungsnummer
                    const string lastBuchungQuery = "SELECT TOP 1 ID FROM Hotel_Buchung ORDER BY Buchungsnummer DESC";
                    var buchungId = db.QuerySingle<Guid>(lastBuchungQuery, transaction: transaction);

                    // Insert Zimmerzuweisung
                    const string insertZimmerQuery = @"INSERT INTO Buchung_Hotelzimmer (Buchungsnummer, Zimmernummer) VALUES (@Buchungsnummer, @Zimmernummer);";
                    db.Execute(insertZimmerQuery, new { Buchungsnummer = buchungId, Zimmernummer = zimmernummer }, transaction);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}