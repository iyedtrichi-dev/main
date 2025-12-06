using System;

namespace ProjectX
{
    public class LstRecyclage
    {
        public int id { get; set; }
        public string typeMateriau { get; set; }
        public double poids { get; set; }
        public DateTime dateTraitement { get; set; }
        public double tauxRévalorisation { get; set; }

        public LstRecyclage()
        {
            dateTraitement = DateTime.Now;
        }

        public LstRecyclage(int id, string typeMateriau, double poids, double tauxRévalorisation)
        {
            this.id = id;
            this.typeMateriau = typeMateriau;
            this.poids = poids;
            this.tauxRévalorisation = tauxRévalorisation;
            this.dateTraitement = DateTime.Now;
        }
    }
}
