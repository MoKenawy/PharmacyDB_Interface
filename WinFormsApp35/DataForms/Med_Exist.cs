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
    public partial class Med_Exist : DataForm
    {
        SqlConnection connection;

        public Med_Exist(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }
        public override void Insert()
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO Med_Exist Values(@medID, @branchID, @quantity, @expiryDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@medID", medIDTextBox.Text);
                command.Parameters.AddWithValue("@branchID", branchIDTextBox.Text);
                command.Parameters.AddWithValue("@quantity", int.Parse(quantityTextBox.Text));
                command.Parameters.AddWithValue("@expiryDate", expiryDateTextBox.Text);
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally {
                connection.Close();
            }

        }
    }
}
