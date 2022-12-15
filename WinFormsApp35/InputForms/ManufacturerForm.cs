using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.Tables;

namespace WinFormsApp35.DataForms
{
    public partial class ManufacturerForm : DataForm
    {
        SqlConnection connection;

        public ManufacturerForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

        }
        public override void Insert()
        {
            connection.Open();
            string query = "INSERT INTO Manufacturer Values(@name,@address)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", nameTextBox.Text);
            command.Parameters.AddWithValue("@address", addressTextBox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
