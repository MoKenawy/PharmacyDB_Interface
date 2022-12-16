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


        public override bool Delete(List<object> record)
        {
            try { 
            int id = (int) record[0];
            connection.Open();
            query = "DELETE FROM Patient WHERE patient_ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            return true;
            }
            catch (Exception exception) {
                return false;
            }
            finally {
                connection.Close();
            }
        }

        public override bool Insert()
        {
            try { 
            connection.Open();
            query = "INSERT INTO Patient Values(@name,@address)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", nameTextBox.Text);
            command.Parameters.AddWithValue("@address", addressTextBox.Text);
            command.ExecuteNonQuery();
            return true;

        }
            catch (Exception exception) {
                return false;
            }
            finally {
                connection.Close();
            }
        }


        public override bool Update(List<object> record)
        {   // Patient Table has patient_address before patient_name in DB
            try {
                int index = 0;
                connection.Open();
                query = "UPDATE Patient " +
                    "SET patient_name = @patient_name, patient_address = @patient_address " +
                    "WHERE patient_ID = " + record[index++];
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@patient_address", (string)record[index++]);
                command.Parameters.AddWithValue("@patient_name", (string)record[index++]);
                command.ExecuteNonQuery();
                return true;

            }
            catch (SqlException exception) {
                return false;
            }
            finally {
                connection.Close();
            }
        }

        public override SqlDataAdapter Search()
        {
            connection.Open();
            query = "SELECT * FROM Patient WHERE patient_ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", searchTextBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();
            return adapter;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
