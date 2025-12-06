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
