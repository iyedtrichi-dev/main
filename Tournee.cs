using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectX
{
    public class Tournee
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatePrevue { get; set; }
        public StatutTournee Statut { get; set; }
        public List<PointCollecte> Points { get; set; }
        public Camion Camion { get; set; }
        public List<PointCollecte> ItinérairePrev { get; set; }

        public Tournee()
        {
            Points = new List<PointCollecte>();
            ItinérairePrev = new List<PointCollecte>();
            Statut = StatutTournee.Planifiée;
            DatePrevue = DateTime.Now;
        }

        public Tournee(int id, Camion camion, List<PointCollecte> points)
        {
            Id = id;
            Camion = camion;
            Points = points ?? new List<PointCollecte>();
            ItinérairePrev = new List<PointCollecte>(Points);
            Statut = StatutTournee.Planifiée;
            DatePrevue = DateTime.Now;
        }

        public TimeSpan CalculerTournee()
        {
            // Simulate calculating duration based on number of points
            return TimeSpan.FromHours(Points.Count * 0.5); // Example: 30 min per point
        }

        public void Run()
        {
            Statut = StatutTournee.EnCours;
            foreach (var point in Points)
            {
                // Simulate collecting from point
                Camion.ChargeActuelle += 100; // Example load increase
            }
            Statut = StatutTournee.Terminée;
        }

        public override string ToString()
        {
            return $"Tour {Id} - {DatePrevue.ToShortDateString()} - {Statut} - Points: {Points.Count}";
        }
    }
}
