namespace SimpleGuiApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Simple GUI App";
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(100, 100);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 50);
        this.button1.TabIndex = 0;
        this.button1.Text = "Click Me!";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(100, 200);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(100, 25);
        this.label1.TabIndex = 1;
        this.label1.Text = "Hello, World!";
        // 
        // Form1
        // 
        this.Controls.Add(this.button1);
        this.Controls.Add(this.label1);
    }

    #endregion
}
