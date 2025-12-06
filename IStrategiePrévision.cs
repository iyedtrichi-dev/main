using System.Collections.Generic;

namespace ProjectX.IA
{
    public interface IStrategiePrévision
    {
        List<double> PredireRemplissage(List<double> historique);
    }
}
