using System.Collections.Generic;

namespace ProjectX.Services
{
    public class ServiceMaintenance
    {
        private List<string> rappelsMaintenance = new List<string>();

        public void PlanifierMaintenance(Camion camion)
        {
            rappelsMaintenance.Add($"Maintenance planned for truck {camion.Immatriculation}");
        }

        public void SignalerPanne(Camion camion, string description)
        {
            rappelsMaintenance.Add($"Breakdown signaled for truck {camion.Immatriculation}: {description}");
        }

        public bool PredirePanne(Camion camion)
        {
            // Simple prediction based on kilometers
            return camion.KilometresParcourus > 10000;
        }

        public void DeplanifierMaintenance(Camion camion)
        {
            rappelsMaintenance.RemoveAll(r => r.Contains(camion.Immatriculation));
        }

        public string ExecuterTournee(Tournee tournee)
        {
            // Execute the tour
            tournee.Run();
            return "Tour executed successfully.";
        }

        public List<string> GetRappelsMaintenance()
        {
            return rappelsMaintenance;
        }
    }
}
