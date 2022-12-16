namespace WinFormsApp35.DataForms
{
    partial class DataControllerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableSelectorCombobox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataShowPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataEntryPanel = new System.Windows.Forms.Panel();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.showDataButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.dataShowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tableSelectorCombobox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 35);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(18, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tables";
            // 
            // tableSelectorCombobox
            // 
            this.tableSelectorCombobox.FormattingEnabled = true;
            this.tableSelectorCombobox.Items.AddRange(new object[] {
            "Orders",
            "Medicine",
            "Patient",
            "Branch",
            "Med_Exist",
            "Manufacturer"});
            this.tableSelectorCombobox.Location = new System.Drawing.Point(75, 7);
            this.tableSelectorCombobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableSelectorCombobox.Name = "tableSelectorCombobox";
            this.tableSelectorCombobox.Size = new System.Drawing.Size(133, 23);
            this.tableSelectorCombobox.TabIndex = 5;
            this.tableSelectorCombobox.Text = "Orders";
            this.tableSelectorCombobox.SelectedIndexChanged += new System.EventHandler(this.tableSelectorCombobox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataShowPanel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 612);
            this.panel2.TabIndex = 1;
            // 
            // dataShowPanel
            // 
            this.dataShowPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataShowPanel.Controls.Add(this.dataGridView1);
            this.dataShowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataShowPanel.Location = new System.Drawing.Point(529, 0);
            this.dataShowPanel.Name = "dataShowPanel";
            this.dataShowPanel.Size = new System.Drawing.Size(583, 612);
            this.dataShowPanel.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(583, 612);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.dataEntryPanel);
            this.panel3.Controls.Add(this.controlsPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(529, 612);
            this.panel3.TabIndex = 2;
            // 
            // dataEntryPanel
            // 
            this.dataEntryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEntryPanel.Location = new System.Drawing.Point(0, 0);
            this.dataEntryPanel.Name = "dataEntryPanel";
            this.dataEntryPanel.Size = new System.Drawing.Size(529, 554);
            this.dataEntryPanel.TabIndex = 1;
            // 
            // controlsPanel
            // 
            this.controlsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.controlsPanel.Controls.Add(this.showDataButton);
            this.controlsPanel.Controls.Add(this.updateButton);
            this.controlsPanel.Controls.Add(this.insertButton);
            this.controlsPanel.Controls.Add(this.deleteButton);
            this.controlsPanel.Controls.Add(this.searchButton);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlsPanel.Location = new System.Drawing.Point(0, 554);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(529, 58);
            this.controlsPanel.TabIndex = 0;
            // 
            // showDataButton
            // 
            this.showDataButton.BackColor = System.Drawing.Color.Green;
            this.showDataButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.showDataButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.showDataButton.Location = new System.Drawing.Point(3, 13);
            this.showDataButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showDataButton.Name = "showDataButton";
            this.showDataButton.Size = new System.Drawing.Size(89, 36);
            this.showDataButton.TabIndex = 31;
            this.showDataButton.Text = "Show";
            this.showDataButton.UseVisualStyleBackColor = false;
            this.showDataButton.Click += new System.EventHandler(this.showDataButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.SteelBlue;
            this.updateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updateButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.updateButton.Location = new System.Drawing.Point(301, 12);
            this.updateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(86, 36);
            this.updateButton.TabIndex = 30;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.BackColor = System.Drawing.Color.SteelBlue;
            this.insertButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.insertButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.insertButton.Location = new System.Drawing.Point(209, 13);
            this.insertButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(86, 36);
            this.insertButton.TabIndex = 28;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = false;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Red;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.deleteButton.Location = new System.Drawing.Point(436, 12);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 38);
            this.deleteButton.TabIndex = 29;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.SteelBlue;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.searchButton.Location = new System.Drawing.Point(108, 13);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(95, 36);
            this.searchButton.TabIndex = 27;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // DataControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 647);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DataControllerForm";
            this.Text = "DataControllerForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.dataShowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.controlsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel dataShowPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel dataEntryPanel;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tableSelectorCombobox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button showDataButton;
    }
}