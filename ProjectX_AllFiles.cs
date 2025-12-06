 
// ===== ProjectX/ProjectX.csproj ===== 
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net9.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.0" />
  </ItemGroup>

</Project>
 
// ===== SimpleGuiApp/SimpleGuiApp.csproj ===== 
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net9.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

</Project> 
// ===== TODO.md ===== 
- [ ] Create Enums/StatutCamion.cs
- [ ] Create Enums/StatutTournee.cs
- [ ] Create Camion.cs
- [ ] Create LstRecyclage.cs
- [ ] Create Tournee.cs
- [ ] Create Services/ServiceImpactEnvironnemental.cs
- [ ] Create Services/ServicePlanification.cs
- [ ] Create Services/ServiceMaintenance.cs
- [ ] Create IA/IStrategiePrévision.cs
- [ ] Create IA/IStrategieOptimisation.cs
- [ ] Create IA/ModèleARIMA.cs
- [ ] Create IA/RéseauNeurones.cs
- [ ] Create IA/AlgoGénétique.cs
- [ ] Create IA/AlgorithmeFourmis.cs
=======
# TODO: Develop Remaining Classes from UML Diagram

- [x] Create Enums/StatutCamion.cs
- [x] Create Enums/StatutTournee.cs
- [x] Create Camion.cs
- [x] Create LstRecyclage.cs
- [x] Create Tournee.cs
- [x] Create Services/ServiceImpactEnvironnemental.cs
- [x] Create Services/ServicePlanification.cs
- [x] Create Services/ServiceMaintenance.cs
- [x] Create IA/IStrategiePrévision.cs
- [x] Create IA/IStrategieOptimisation.cs
- [x] Create IA/ModèleARIMA.cs
- [x] Create IA/RéseauNeurones.cs
- [x] Create IA/AlgoGénétique.cs
- [x] Create IA/AlgorithmeFourmis.cs
- [x] Create IA/MoteurIA.cs
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\AddItemForm.cs ===== 
using System;
using System.Windows.Forms;

namespace ProjectX
{
    public class AddItemForm : Form
    {
        private PointCollecte? newPoint;
        private Camion? newTruck;
        private bool isPoint;

        public PointCollecte? GetNewPoint() => newPoint;
        public Camion? GetNewTruck() => newTruck;
        public bool GetIsPoint() => isPoint;

        public string Name => tbName.Text.Trim();
        public bool IsPoint => isPoint;
        public string Type => cbType.SelectedItem?.ToString() ?? "General";
        public decimal Capacity => nudCapacity.Value;
        public decimal InitialLoad => nudInitialLoad.Value;

        private TextBox tbName;
        private ComboBox cbType;
        private NumericUpDown nudCapacity;
        private NumericUpDown nudInitialLoad;
        private Button btnAdd;
        private Button btnCancel;
        private RadioButton rbPoint;
        private RadioButton rbTruck;
        private Label lblName;
        private Label lblType;
        private Label lblCapacity;
        private Label lblInitialLoad;

    public AddItemForm()
    {
        SetupComponents();
    }

        private void SetupComponents()
        {
            this.Text = "Add Item";
            this.Size = new System.Drawing.Size(350, 280);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Radio buttons to choose type
            rbPoint = new RadioButton() { Text = "Collection Point", Location = new System.Drawing.Point(20, 20), Checked = true };
            rbTruck = new RadioButton() { Text = "Truck", Location = new System.Drawing.Point(150, 20) };
            rbPoint.CheckedChanged += (s, e) => UpdateForm();
            rbTruck.CheckedChanged += (s, e) => UpdateForm();

            // Labels
            lblName = new Label() { Text = "Name:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            lblType = new Label() { Text = "Type:", Location = new System.Drawing.Point(20, 90), AutoSize = true };
            lblCapacity = new Label() { Text = "Capacity:", Location = new System.Drawing.Point(20, 120), AutoSize = true };
            lblInitialLoad = new Label() { Text = "Initial Load:", Location = new System.Drawing.Point(20, 150), AutoSize = true };

            // Controls
            tbName = new TextBox() { Location = new System.Drawing.Point(100, 55), Size = new System.Drawing.Size(200, 22) };
            cbType = new ComboBox() { Location = new System.Drawing.Point(100, 85), Size = new System.Drawing.Size(100, 22), DropDownStyle = ComboBoxStyle.DropDownList };
            cbType.Items.AddRange(new string[] { "General", "Organic", "Plastic", "Paper", "Glass" });
            cbType.SelectedIndex = 0;
            nudCapacity = new NumericUpDown() { Location = new System.Drawing.Point(100, 115), Size = new System.Drawing.Size(80, 22), Minimum = 100, Maximum = 10000, Value = 500 };
            nudInitialLoad = new NumericUpDown() { Location = new System.Drawing.Point(100, 145), Size = new System.Drawing.Size(80, 22), Minimum = 0, Maximum = 5000, Value = 0 };

            // Buttons
            btnAdd = new Button() { Text = "Add", Location = new System.Drawing.Point(100, 190), Size = new System.Drawing.Size(80, 30), DialogResult = DialogResult.OK };
            btnCancel = new Button() { Text = "Cancel", Location = new System.Drawing.Point(200, 190), Size = new System.Drawing.Size(80, 30), DialogResult = DialogResult.Cancel };

            btnAdd.Click += BtnAdd_Click;

            this.Controls.Add(rbPoint);
            this.Controls.Add(rbTruck);
            this.Controls.Add(lblName);
            this.Controls.Add(lblType);
            this.Controls.Add(lblCapacity);
            this.Controls.Add(lblInitialLoad);
            this.Controls.Add(tbName);
            this.Controls.Add(cbType);
            this.Controls.Add(nudCapacity);
            this.Controls.Add(nudInitialLoad);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnCancel);

            UpdateForm();
        }

        private void UpdateForm()
        {
            if (rbPoint.Checked)
            {
                lblType.Visible = true;
                cbType.Visible = true;
                lblCapacity.Text = "Capacity (units):";
                nudCapacity.Minimum = 100;
                nudCapacity.Maximum = 10000;
                nudCapacity.Value = 500;
                lblInitialLoad.Visible = false;
                nudInitialLoad.Visible = false;
            }
            else
            {
                lblType.Visible = false;
                cbType.Visible = false;
                lblCapacity.Text = "Capacity (kg):";
                nudCapacity.Minimum = 500;
                nudCapacity.Maximum = 5000;
                nudCapacity.Value = 1000;
                lblInitialLoad.Visible = true;
                nudInitialLoad.Visible = true;
                nudInitialLoad.Maximum = nudCapacity.Value;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var name = tbName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (rbPoint.Checked)
            {
                isPoint = true;
                newPoint = new PointCollecte(0, name)
                {
                    typeDechet = cbType.SelectedItem.ToString(),
                    capaciteSTD = nudCapacity.Value.ToString()
                };
            }
            else
            {
                isPoint = false;
                newTruck = new Camion(0, name, (double)nudCapacity.Value);
                newTruck.ChargeActuelle = (double)nudInitialLoad.Value;
            }
        }
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Camion.cs ===== 
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectX
{
    public class Camion
    {
        [Key]
        public int Id { get; set; }
        public string Immatriculation { get; set; } = string.Empty;
        public double CapacitéBenne { get; set; }
        public double ChargeActuelle { get; set; }
        public double NiveauCarburant { get; set; }
        public double KilometresParcourus { get; set; }
        public StatutCamion Statut { get; set; }

        public Camion()
        {
            Statut = StatutCamion.Disponible;
        }

        public Camion(int id, string immatriculation, double capaciteBenne)
        {
            Id = id;
            Immatriculation = immatriculation;
            CapacitéBenne = capaciteBenne;
            ChargeActuelle = 0;
            NiveauCarburant = 100; // Assume full tank
            Statut = StatutCamion.Disponible;
        }

        public double ChangerDechetSélectionné()
        {
            // Simulate changing waste type and returning capacity adjustment
            return CapacitéBenne * 0.1; // Example adjustment
        }

        public void ViderCamion()
        {
            ChargeActuelle = 0;
        }

        public void AjouterKilometres(double km)
        {
            // Simulate fuel consumption
            NiveauCarburant -= km * 0.01; // Example consumption rate
            if (NiveauCarburant < 0) NiveauCarburant = 0;
        }

        public override string ToString()
        {
            return $"{Immatriculation} (ID: {Id}, Charge: {ChargeActuelle}/{CapacitéBenne}, Fuel: {NiveauCarburant}%)";
        }
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\CentreDeTri.cs ===== 
using System;
using System.Collections.Generic;

namespace ProjectX
{
    public class CentreDeTri
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public double capacitéRemplissage { get; set; }
        public DateTime dateDerniereCollecte { get; set; }
        public string capaciteSTD { get; set; }
        public List<Camion> receptionDechetsDomaines { get; set; }
        public List<LstRecyclage> LstRecyclage { get; set; }

        public CentreDeTri()
        {
            receptionDechetsDomaines = new List<Camion>();
            LstRecyclage = new List<LstRecyclage>();
        }

        public List<DateTime> getHistoriqueRemplissage()
        {
            // Simulate returning history of filling dates
            return new List<DateTime> { DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-2) };
        }

        public double vidangeRemplissagePoubelle()
        {
            // Simulate emptying the bin and returning remaining capacity
            capacitéRemplissage -= 10.0; // Example reduction
            return capacitéRemplissage;
        }

        public bool viderCamion()
        {
            // Simulate emptying the truck
            return true; // Indicate success
        }
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\LstRecyclage.cs ===== 
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\MainForm.cs ===== 
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjectX.Services;

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
        private List<PointCollecte> points = new List<PointCollecte>();
        private List<Camion> camions = new List<Camion>();
        private List<Tournee> tournees = new List<Tournee>();
        private CentreDeTri centreDeTri = new CentreDeTri { id = 1, nom = "Centre Principal", adresse = "123 Rue de Tri" };

        public MainForm(ServicePlanification planification, ServiceMaintenance maintenance, ServiceImpactEnvironnemental impactService)
        {
            this.planification = planification;
            this.maintenance = maintenance;
            this.impactService = impactService;

            Text = "Waste Collection Simulator";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponents();
            SeedSampleData();
            RefreshLists();
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
            points.Add(new PointCollecte { id = 1, adresse = "123 Main St", typeDechet = "Plastic", capaciteSTD = "100", niveauRemplissagePoubelle = 50 });
            points.Add(new PointCollecte { id = 2, adresse = "456 Elm St", typeDechet = "Paper", capaciteSTD = "80", niveauRemplissagePoubelle = 30 });

            camions.Add(new Camion(1, "Truck1", 200));
            camions.Add(new Camion(2, "Truck2", 150));
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
                        id = points.Count + 1,
                        adresse = addForm.Name,
                        typeDechet = addForm.Type,
                        capaciteSTD = addForm.Capacity.ToString(),
                        niveauRemplissagePoubelle = (double)addForm.InitialLoad
                    };
                    points.Add(point);
                }
                else
                {
                    var truck = new Camion(camions.Count + 1, addForm.Name, (double)addForm.Capacity);
                    truck.ChargeActuelle = (double)addForm.InitialLoad;
                    camions.Add(truck);
                }
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\PointCollecte.cs ===== 
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectX
{
    public class PointCollecte
    {
        [Key]
        public int id { get; set; }
        public string adresse { get; set; } = string.Empty;
        public string? typeDechet { get; set; }
        public double niveauRemplissagePoubelle { get; set; }
        public DateTime dateDerniereCollecte { get; set; }
        public string? capaciteSTD { get; set; }

        public PointCollecte() { }

        public PointCollecte(int id, string adresse)
        {
            this.id = id;
            this.adresse = adresse;
            this.typeDechet = "General";
            this.niveauRemplissagePoubelle = 0;
            this.dateDerniereCollecte = DateTime.Now;
            this.capaciteSTD = "Standard";
        }
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Program.cs ===== 
using System;
using System.Windows.Forms;
using ProjectX.Services;
using ProjectX.IA;

namespace ProjectX
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize services
            var strategie = new AlgoGénétique();
            var moteurIA = new MoteurIA(strategie);
            var planification = new ServicePlanification(moteurIA);
            var maintenance = new ServiceMaintenance();
            var impactService = new ServiceImpactEnvironnemental();

            Application.Run(new MainForm(planification, maintenance, impactService));
        }
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Tournee.cs ===== 
using System;
using System.Collections.Generic;

namespace ProjectX
{
    public class Tournee
    {
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Enums\StatutCamion.cs ===== 
namespace ProjectX
{
    public enum StatutCamion
    {
        Disponible,
        EnRoute,
        EnMaintenance,
        HorsService
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Enums\StatutTournee.cs ===== 
namespace ProjectX
{
    public enum StatutTournee
    {
        Planifiée,
        EnCours,
        Terminée,
        Annulée
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\IA\AlgoG�n�tique.cs ===== 
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\IA\IStrategieOptimisation.cs ===== 
using System.Collections.Generic;

namespace ProjectX.IA
{
    public interface IStrategieOptimisation
    {
        List<PointCollecte> CalculerItineraire(List<PointCollecte> points);
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\IA\IStrategiePr�vision.cs ===== 
using System.Collections.Generic;

namespace ProjectX.IA
{
    public interface IStrategiePrévision
    {
        List<double> PredireRemplissage(List<double> historique);
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\IA\Mod�leARIMA.cs ===== 
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\IA\MoteurIA.cs ===== 
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\IA\StrategyDummy.cs ===== 
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\obj\Debug\net9.0-windows\.NETCoreApp,Version=v9.0.AssemblyAttributes.cs ===== 
// <autogenerated />
using System;
using System.Reflection;
[assembly: global::System.Runtime.Versioning.TargetFrameworkAttribute(".NETCoreApp,Version=v9.0", FrameworkDisplayName = ".NET 9.0")]
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\obj\Debug\net9.0-windows\ProjectX.AssemblyInfo.cs ===== 
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Reflection;

[assembly: System.Reflection.AssemblyCompanyAttribute("ProjectX")]
[assembly: System.Reflection.AssemblyConfigurationAttribute("Debug")]
[assembly: System.Reflection.AssemblyFileVersionAttribute("1.0.0.0")]
[assembly: System.Reflection.AssemblyInformationalVersionAttribute("1.0.0+57b023e9bbe5f8440ce8b7fab06c6273b60503db")]
[assembly: System.Reflection.AssemblyProductAttribute("ProjectX")]
[assembly: System.Reflection.AssemblyTitleAttribute("ProjectX")]
[assembly: System.Reflection.AssemblyVersionAttribute("1.0.0.0")]
[assembly: System.Runtime.Versioning.TargetPlatformAttribute("Windows7.0")]
[assembly: System.Runtime.Versioning.SupportedOSPlatformAttribute("Windows7.0")]

// Généré par la classe MSBuild WriteCodeFragment.

 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\obj\Debug\net9.0-windows\ProjectX.GlobalUsings.g.cs ===== 
// <auto-generated/>
global using global::System;
global using global::System.Collections.Generic;
global using global::System.Drawing;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
global using global::System.Windows.Forms;
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Services\ServiceImpactEnvironnemental.cs ===== 
using System;
using System.Collections.Generic;

namespace ProjectX.Services
{
    public class ServiceImpactEnvironnemental
    {
        public double CalculerCO2EmisMoyparJour(List<LstRecyclage> recyclages)
        {
            // Simulate calculating average daily CO2 emissions
            double totalCO2 = 0;
            foreach (var r in recyclages)
            {
                totalCO2 += r.poids * 0.5; // Example calculation
            }
            return totalCO2 / recyclages.Count;
        }

        public string GenererRapportRecyclage(DateTime dateDeb, DateTime dateFin)
        {
            // Simulate generating recycling report
            return $"Recycling Report from {dateDeb.ToShortDateString()} to {dateFin.ToShortDateString()}: Total recycled: 1000kg";
        }

        public string GenererRapport(Tournee tournee)
        {
            // Simulate generating environmental impact report for a tour
            double co2Emitted = tournee.Points.Count * 10.5; // Example calculation
            return $"Tour {tournee.Id}: CO2 emitted: {co2Emitted}kg, Distance: {tournee.Points.Count * 5}km";
        }
    }
}
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Services\ServiceMaintenance.cs ===== 
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
 
// ===== ProjectX/\Users\ASUS\Desktop\ProjectX\Services\ServicePlanification.cs ===== 
using System;
using System.Collections.Generic;
using ProjectX.IA;

namespace ProjectX.Services
{
    public class ServicePlanification
    {
        private MoteurIA moteurIA;

        public ServicePlanification(MoteurIA moteurIA)
        {
            this.moteurIA = moteurIA;
        }

        public List<Tournee> GenererTourneeQuotidienne()
        {
            // Simulate generating daily tours
            return new List<Tournee> { new Tournee(1, new Camion(), new List<PointCollecte>()) };
        }

        public Camion AssignerCamionTournee(Tournee tournee)
        {
            // Simulate assigning a truck to a tour
            return tournee.Camion ?? new Camion();
        }

        public Tournee PlanifierTournee(List<PointCollecte> points, Camion camion)
        {
            // Use IA to generate optimal tour
            var itineraire = moteurIA.CalculerItineraire(points);
            return new Tournee(1, camion, itineraire);
        }

        public string MonitorerRemplissage(Tournee tournee)
        {
            // Simulate monitoring fill levels
            return "No incidents detected.";
        }
    }
}
 
