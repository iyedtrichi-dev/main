using System;
using System.Windows.Forms;
using ProjectX.Services;
using ProjectX.IA;
using Microsoft.EntityFrameworkCore;

namespace ProjectX
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize database
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }

            // Initialize database context
            var dbContext = new AppDbContext();

            // Initialize services
            var strategie = new AlgoGénétique();
            var moteurIA = new MoteurIA(strategie);
            var planification = new ServicePlanification(moteurIA);
            var maintenance = new ServiceMaintenance();
            var impactService = new ServiceImpactEnvironnemental();

            Application.Run(new MainForm(planification, maintenance, impactService, dbContext));
        }
    }
}
