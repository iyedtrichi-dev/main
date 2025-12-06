using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjectX.Services;
using Microsoft.EntityFrameworkCore;

namespace ProjectX
{
    public partial class MainForm : Form
    {
        private ListBox lbPoints;
        private ListBox lbTrucks;
        private ListBox lbTours;
        private Button btnAddPoint;
        private Button btnAddTruck;
        private Button btnPlanTour;
        private Button btnRunTour;
        private Button btnImpact;
        private Button btnEmptyTruck;
        private Button btnEmptyBin;
        private TextBox tbPointName;
        private ComboBox cbPointType;
        private NumericUpDown nudPointCapacity;
        private TextBox tbTruckName;
        private NumericUpDown nudTruckCapacity;
        private ServicePlanification planification;
        private ServiceMaintenance maintenance;
        private ServiceImpactEnvironnemental impactService;
        private AppDbContext _context;
        private List<PointCollecte> points = new List<PointCollecte>();
        private List<Camion> camions = new List<Camion>();
        private List<Tournee> tournees = new List<Tournee>();
        private CentreDeTri centreDeTri = new CentreDeTri { id = 1, nom = "Centre Principal", adresse = "123 Rue de Tri" };

        public MainForm(ServicePlanification planification, ServiceMaintenance maintenance, ServiceImpactEnvironnemental impactService, AppDbContext context)
        {
            this.planification = planification;
            this.maintenance = maintenance;
            this.impactService = impactService;
            _context = context;

            Text = "Waste Collection Simulator";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponents();
            LoadDataFromDatabase();
            SeedSampleData();
            RefreshLists();
        }

        private void LoadDataFromDatabase()
        {
            points = _context.PointsCollecte.ToList();
            camions = _context.Camions.ToList();
            tournees = _context.Tournees.ToList();
        }

        private void InitializeComponents()
        {
            lbPoints = new ListBox() { Location = new Point(10, 70), Size = new Size(300, 270) };
            lbTrucks = new ListBox() { Location = new Point(330, 70), Size = new Size(300, 270) };
            lbTours = new ListBox() { Location = new Point(650, 70), Size = new Size(320, 270) };

            // Add Item button
            btnAddPoint = new Button() { Location = new Point(10, 10), Size = new Size(100, 30), Text = "Add Item" };
            btnAddPoint.Click += (s, e) => AddItem();

            // Action buttons
            btnPlanTour = new Button() { Location = new Point(650, 10), Size = new Size(100, 30), Text = "Plan Tour" };
            btnPlanTour.Click += (s, e) => PlanTour();

            btnRunTour = new Button() { Location = new Point(760, 10), Size = new Size(100, 30), Text = "Run Tour" };
            btnRunTour.Click += (s, e) => RunTour();

            btnImpact = new Button() { Location = new Point(870, 10), Size = new Size(100, 30), Text = "Impact" };
            btnImpact.Click += (s, e) => ShowImpact();

            btnEmptyTruck = new Button() { Location = new Point(330, 10), Size = new Size(100, 30), Text = "Empty Truck" };
            btnEmptyTruck.Click += (s, e) => EmptyTruck();

            btnEmptyBin = new Button() { Location = new Point(440, 10), Size = new Size(100, 30), Text = "Empty Bin" };
            btnEmptyBin.Click += (s, e) => EmptyBin();

            // Labels
            var lbl1 = new Label() { Location = new Point(10, 50), Size = new Size(100, 20), Text = "Points" };
            var lbl2 = new Label() { Location = new Point(330, 50), Size = new Size(100, 20), Text = "Trucks" };
            var lbl3 = new Label() { Location = new Point(650, 50), Size = new Size(100, 20), Text = "Tours" };
            var lbl4 = new Label() { Location = new Point(10, 350), Size = new Size(200, 20), Text = $"Sorting Center: {centreDeTri.nom} - Current Capacity: {centreDeTri.capacitéRemplissage}" };

            Controls.AddRange(new Control[] { lbPoints, lbTrucks, lbTours, btnAddPoint, btnPlanTour, btnRunTour, btnImpact, btnEmptyTruck, btnEmptyBin, lbl1, lbl2, lbl3, lbl4 });
        }

        private void SeedSampleData()
        {
            if (!_context.PointsCollecte.Any())
            {
                _context.PointsCollecte.Add(new PointCollecte { id = 1, adresse = "123 Main St", typeDechet = "Plastic", capaciteSTD = "100", niveauRemplissagePoubelle = 50 });
                _context.PointsCollecte.Add(new PointCollecte { id = 2, adresse = "456 Elm St", typeDechet = "Paper", capaciteSTD = "80", niveauRemplissagePoubelle = 30 });
            }

            if (!_context.Camions.Any())
            {
                _context.Camions.Add(new Camion(1, "Truck1", 200));
                _context.Camions.Add(new Camion(2, "Truck2", 150));
            }

            _context.SaveChanges();
            LoadDataFromDatabase();
        }

        private void AddItem()
        {
            var addForm = new AddItemForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (addForm.IsPoint)
                {
                    var point = new PointCollecte
                    {
                        id = _context.PointsCollecte.Any() ? _context.PointsCollecte.Max(p => p.id) + 1 : 1,
                        adresse = addForm.Name,
                        typeDechet = addForm.Type,
                        capaciteSTD = addForm.Capacity.ToString(),
                        niveauRemplissagePoubelle = (double)addForm.InitialLoad
                    };
                    _context.PointsCollecte.Add(point);
                }
                else
                {
                    var truck = new Camion(_context.Camions.Any() ? _context.Camions.Max(c => c.Id) + 1 : 1, addForm.Name, (double)addForm.Capacity);
                    truck.ChargeActuelle = (double)addForm.InitialLoad;
                    _context.Camions.Add(truck);
                }
                _context.SaveChanges();
                LoadDataFromDatabase();
                RefreshLists();
            }
        }

        private void PlanTour()
        {
            if (lbPoints.SelectedIndex == -1 || lbTrucks.SelectedIndex == -1) { MessageBox.Show("Select a point and a truck to plan a tour."); return; }
            var point = points[lbPoints.SelectedIndex];
            var truck = camions[lbTrucks.SelectedIndex];
            var tour = planification.PlanifierTournee(new List<PointCollecte> { point }, truck);
            tournees.Add(tour);
            RefreshLists();
            MessageBox.Show("Tour planned successfully!");
        }

        private void RunTour()
        {
            if (lbTours.SelectedIndex == -1) { MessageBox.Show("Select a tour to run."); return; }
            var tour = tournees[lbTours.SelectedIndex];
            var message = maintenance.ExecuterTournee(tour);
            RefreshLists();
            MessageBox.Show(message, "Tour Execution Report");
        }

        private void ShowImpact()
        {
            if (lbTours.SelectedIndex == -1) { MessageBox.Show("Select a tour to calculate impact."); return; }
            var tour = tournees[lbTours.SelectedIndex];
            var report = impactService.GenererRapport(tour);
            MessageBox.Show(report, "Environmental Impact");
        }

        private void EmptyTruck()
        {
            if (lbTrucks.SelectedIndex == -1) { MessageBox.Show("Select a truck to empty."); return; }
            var truck = camions[lbTrucks.SelectedIndex];
            var emptiedAmount = truck.ChargeActuelle;
            truck.ViderCamion();
            centreDeTri.viderCamion(); // Simulate emptying at sorting center
            _context.SaveChanges();
            RefreshLists();
            MessageBox.Show($"Truck '{truck.Immatriculation}' emptied successfully!\nEmptied {emptiedAmount} units of waste.", "Truck Unloaded");
        }

        private void EmptyBin()
        {
            var before = centreDeTri.capacitéRemplissage;
            var remaining = centreDeTri.vidangeRemplissagePoubelle();
            var emptied = before - remaining;
            RefreshLists();
            MessageBox.Show($"Sorting center bin emptied successfully!\nEmptied {emptied} units of waste.\nRemaining capacity: {remaining}", "Sorting Center");
        }

        private void RefreshLists()
        {
            lbPoints.Items.Clear();
            foreach (var p in points)
                lbPoints.Items.Add($"{p.adresse} (ID: {p.id}, Type: {p.typeDechet ?? "N/A"}, Capacity: {p.capaciteSTD ?? "N/A"}, Fill: {p.niveauRemplissagePoubelle}%)");

            lbTrucks.Items.Clear();
            foreach (var t in camions)
                lbTrucks.Items.Add($"{t.Immatriculation} (ID: {t.Id}, Capacity: {t.CapacitéBenne}, Current Load: {t.ChargeActuelle}, Km: {t.KilometresParcourus})");

            lbTours.Items.Clear();
            foreach (var tt in tournees)
                lbTours.Items.Add($"{tt.Camion.Immatriculation} - {tt.Points.Count} points (Status: {tt.Statut})");

            // Update sorting center label
            var lbl4 = Controls.OfType<Label>().FirstOrDefault(l => l.Text.Contains("Sorting Center"));
            if (lbl4 != null)
                lbl4.Text = $"Sorting Center: {centreDeTri.nom} - Current Capacity: {centreDeTri.capacitéRemplissage}";
        }
    }
}
