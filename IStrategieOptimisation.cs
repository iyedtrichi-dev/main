using System.Collections.Generic;

namespace ProjectX.IA
{
    public interface IStrategieOptimisation
    {
        List<PointCollecte> CalculerItineraire(List<PointCollecte> points);
    }
}
