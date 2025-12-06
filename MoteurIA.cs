using System.Collections.Generic;

namespace ProjectX.IA
{
    public class MoteurIA
    {
        private IStrategieOptimisation strategieOptimisation;

        public MoteurIA(IStrategieOptimisation strategie)
        {
            strategieOptimisation = strategie;
        }

        public List<PointCollecte> CalculerItineraire(List<PointCollecte> points)
        {
            return strategieOptimisation.CalculerItineraire(points);
        }
    }
}
