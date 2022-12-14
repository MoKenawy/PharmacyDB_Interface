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

        private async void Home_Load(object sender, EventArgs e)
        {
            await ConnectToDB();
            Form dataControllerForm = new WinFormsApp35.DataForms.DataControllerForm(connection);
            MainPanel.Controls.Clear();
            dataControllerForm.FormBorderStyle = FormBorderStyle.None;
            dataControllerForm.TopLevel = false;
            MainPanel.Controls.Add(dataControllerForm);
            dataControllerForm.Dock = DockStyle.Fill;
            dataControllerForm.Show();



        }
        private async Task ConnectToDB() {
            ConnectionUtil connectionUtil = new ConnectionUtil("PharmacyDB");
            if (connectionUtil.Connect()!= null)
            {
                connection = connectionUtil.getConnection();
                connectionStatusLabel.Text += " Success";
            }
            else
            {
                connectionStatusLabel.Text += " Couldn't connect";
            }
        }

        private void ordersFormButton_Click(object sender, EventArgs e)
        {
            Form dataControllerForm = new WinFormsApp35.DataForms.DataControllerForm(connection);
            dataControllerForm.Show();
        }

    }
}
