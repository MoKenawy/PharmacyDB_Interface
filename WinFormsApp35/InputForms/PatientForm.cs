using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.DataForms;
using WinFormsApp35.Tables;

namespace WinFormsApp35
{
    public partial class PatientForm : DataForm
    {
        SqlConnection connection;
        public PatientForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }


        public override void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public override void Insert()
        {
            connection.Open();
            string query = "INSERT INTO Patient Values(@name,@address)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", nameTextBox.Text);
            command.Parameters.AddWithValue("@address", addressTextBox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public override void Update(int index)
        {
            throw new NotImplementedException();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
