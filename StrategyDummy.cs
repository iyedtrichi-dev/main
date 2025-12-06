using System.Collections.Generic;

namespace ProjectX.IA
{
    public class StrategyDummy : IStrategieOptimisation
    {
        public List<PointCollecte> CalculerItineraire(List<PointCollecte> points)
        {
            // Simple dummy implementation - just return points as is
            return points ?? new List<PointCollecte>();
        }
    }
}
