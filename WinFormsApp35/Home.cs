using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp35.Utilities;

namespace WinFormsApp35.Home
{
    public partial class Home : Form
    {
        SqlConnection connection;
        public Home()
        {
            InitializeComponent();

        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (ConnectToDB())
            {
                Form dataControllerForm = new WinFormsApp35.DataForms.DataControllerForm(connection);
                MainPanel.Controls.Clear();
                dataControllerForm.FormBorderStyle = FormBorderStyle.None;
                dataControllerForm.TopLevel = false;
                MainPanel.Controls.Add(dataControllerForm);
                dataControllerForm.Dock = DockStyle.Fill;
                dataControllerForm.Show();
            }
        }
        private bool ConnectToDB() {
            bool isConnected = false;
                ConnectionUtil connectionUtil = new ConnectionUtil("PharmacyDB");

                    connection = connectionUtil.Connect();
                if (connection != null)
                {
                    connection.Open();
                    connectionStatusLabel.Text += " Success";
                    isConnected = true;
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                    connectionStatusLabel.Text += " Couldn't connect";
                    isConnected = false;
                }

            return isConnected;
        }


    }
}
