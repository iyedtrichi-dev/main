using System;
using System.Collections.Generic;

namespace ProjectX.IA
{
    public class ModèleARIMA : IStrategiePrévision
    {
        public List<double> PredireRemplissage(List<double> historique)
        {
            // Simulate ARIMA prediction
            var predictions = new List<double>();
            for (int i = 0; i < 7; i++) // Predict next 7 days
            {
                double prediction = historique.Count > 0 ? historique[historique.Count - 1] + 5 : 50; // Simple trend
                predictions.Add(prediction);
            }
            return predictions;
        }
    }
}
