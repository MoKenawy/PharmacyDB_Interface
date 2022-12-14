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
    public partial class BranchForm : DataForm
    {
        SqlConnection connection;
        public BranchForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        public override void Insert()
        {
            connection.Open();
            string query = "INSERT INTO Branch Values(@name,@address)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", nameTextBox.Text);
            command.Parameters.AddWithValue("@address", addressTextBox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
