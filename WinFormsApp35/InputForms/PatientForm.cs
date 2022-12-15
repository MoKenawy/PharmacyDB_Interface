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
        string query;
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
            query = "INSERT INTO Patient Values(@name,@address)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", nameTextBox.Text);
            command.Parameters.AddWithValue("@address", addressTextBox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public override void Update(int id, List<object> record)
        {
            int index = 0;
            connection.Open();
            query = "UPDATE Patient " +
                "SET patient_name = @name, patient_address = @address " +
                "WHERE patient_ID = "+ record[index++];    
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@address", record[index++]);
            command.Parameters.AddWithValue("@name", record[index++]);
            command.ExecuteNonQueryAsync();
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
