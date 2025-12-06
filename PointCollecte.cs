using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectX
{
    public class PointCollecte
    {
        [Key]
        public int id { get; set; }
        public string adresse { get; set; } = string.Empty;
        public string? typeDechet { get; set; }
        public double niveauRemplissagePoubelle { get; set; }
        public DateTime dateDerniereCollecte { get; set; }
        public string? capaciteSTD { get; set; }

        public PointCollecte() { }

        public PointCollecte(int id, string adresse)
        {
            this.id = id;
            this.adresse = adresse;
            this.typeDechet = "General";
            this.niveauRemplissagePoubelle = 0;
            this.dateDerniereCollecte = DateTime.Now;
            this.capaciteSTD = "Standard";
        }
    }
}
