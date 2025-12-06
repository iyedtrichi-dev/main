using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectX
{
    public class Camion
    {
        [Key]
        public int Id { get; set; }
        public string Immatriculation { get; set; } = string.Empty;
        public double CapacitéBenne { get; set; }
        public double ChargeActuelle { get; set; }
        public double NiveauCarburant { get; set; }
        public double KilometresParcourus { get; set; }
        public StatutCamion Statut { get; set; }

        public Camion()
        {
            Statut = StatutCamion.Disponible;
        }

        public Camion(int id, string immatriculation, double capaciteBenne)
        {
            Id = id;
            Immatriculation = immatriculation;
            CapacitéBenne = capaciteBenne;
            ChargeActuelle = 0;
            NiveauCarburant = 100; // Assume full tank
            Statut = StatutCamion.Disponible;
        }

        public double ChangerDechetSélectionné()
        {
            // Simulate changing waste type and returning capacity adjustment
            return CapacitéBenne * 0.1; // Example adjustment
        }

        public void ViderCamion()
        {
            ChargeActuelle = 0;
        }

        public void AjouterKilometres(double km)
        {
            // Simulate fuel consumption
            NiveauCarburant -= km * 0.01; // Example consumption rate
            if (NiveauCarburant < 0) NiveauCarburant = 0;
        }

        public override string ToString()
        {
            return $"{Immatriculation} (ID: {Id}, Charge: {ChargeActuelle}/{CapacitéBenne}, Fuel: {NiveauCarburant}%)";
        }
    }
}
