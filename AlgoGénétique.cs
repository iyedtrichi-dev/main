using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.IA
{
    public class AlgoGénétique : IStrategieOptimisation
    {
        public List<PointCollecte> CalculerItineraire(List<PointCollecte> points)
        {
            // Simulate genetic algorithm for route optimization
            if (points.Count <= 1) return points;
            
            // Simple shuffle as genetic algorithm simulation
            var optimized = new List<PointCollecte>(points);
            optimized.Sort((a, b) => a.id.CompareTo(b.id)); // Sort by ID for simplicity
            return optimized;
        }
    }
}
