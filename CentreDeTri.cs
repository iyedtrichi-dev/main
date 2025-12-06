using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectX
{
    public class CentreDeTri
    {
        [Key]
        public int id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public double capacitéRemplissage { get; set; }
        public DateTime dateDerniereCollecte { get; set; }
        public string capaciteSTD { get; set; }
        public List<Camion> receptionDechetsDomaines { get; set; }
        public List<LstRecyclage> LstRecyclage { get; set; }

        public CentreDeTri()
        {
            receptionDechetsDomaines = new List<Camion>();
            LstRecyclage = new List<LstRecyclage>();
        }

        public List<DateTime> getHistoriqueRemplissage()
        {
            // Simulate returning history of filling dates
            return new List<DateTime> { DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-2) };
        }

        public double vidangeRemplissagePoubelle()
        {
            // Simulate emptying the bin and returning remaining capacity
            capacitéRemplissage -= 10.0; // Example reduction
            return capacitéRemplissage;
        }

        public bool viderCamion()
        {
            // Simulate emptying the truck
            return true; // Indicate success
        }
    }
}
