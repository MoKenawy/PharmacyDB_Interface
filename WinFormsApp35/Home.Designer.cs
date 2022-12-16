namespace WinFormsApp35.Home
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.connectionStatusLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1013, 608);
            this.MainPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(379, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pharmacy Database";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(458, 380);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(72, 15);
            this.connectionStatusLabel.TabIndex = 0;
            this.connectionStatusLabel.Text = "Connection:";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 608);
            this.Controls.Add(this.MainPanel);
            this.Name = "Home";
            this.Text = "PharmacyDB Manager";
            this.Load += new System.EventHandler(this.Home_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Label label1;
    }
}